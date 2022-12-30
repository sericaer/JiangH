using JiangH.Messages.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JiangH.Messages
{

    public class MessageBus : IMessageBus
    {
        Dictionary<Type, List<MessageProceItem>> dict = new Dictionary<Type, List<MessageProceItem>>();

        public void Register(IMessageIn messageIn)
        {
            foreach(var pair in messageIn.dict)
            {
                List<MessageProceItem> messageProcessList;
                if(!dict.TryGetValue(pair.Key, out messageProcessList))
                {
                    messageProcessList = new List<MessageProceItem>();
                    dict.Add(pair.Key, messageProcessList);
                }

                messageProcessList.Add(pair.Value);
            }
        }

        public void Register(IMessageOut messageOut)
        {
            messageOut.SendMessage = (msg) =>
            {
                foreach(var item in dict[msg.GetType()])
                {
                    item.Process(msg);
                }
            };
        }

        public void Register(IMessageInOut messageInOut)
        {
            Register((IMessageIn)messageInOut);
            Register((IMessageOut)messageInOut);
        }
    }

    public class MessageProceItem
    {
        public Action<MESSAGE> action;

        public MessageProceItem(Action<MESSAGE> action)
        {
            this.action = action;
        }

        internal void Process(MESSAGE msg)
        {
            action(msg);
        }
    }

    public abstract class MessageIn : IMessageIn
    {
        public Dictionary<Type, MessageProceItem> dict { get; } = new Dictionary<Type, MessageProceItem>();

        public void RegisterMsg<T>(Action<T> action) where T : MESSAGE
        {
            Register(typeof(T), new Action<MESSAGE>(msg => action(msg as T)));
        }

        private void Register(Type type, Action<MESSAGE> action)
        {
            dict.Add(type, new MessageProceItem(action));
        }
    }

    public abstract class MessageOut : IMessageOut
    {
        public Action<MESSAGE> SendMessage { get; set; }
    }

    public abstract class MessageInOut : IMessageInOut
    {
        public Action<MESSAGE> SendMessage { get; set; }
        public Dictionary<Type, MessageProceItem> dict { get; } = new Dictionary<Type, MessageProceItem>();

        public void RegisterMsg<T>(Action<T> action) where T : MESSAGE
        {
            Register(typeof(T), new Action<MESSAGE>(msg => action(msg as T)));
        }

        private void Register(Type type, Action<MESSAGE> action)
        {
            dict.Add(type, new MessageProceItem(action));
        }
    }
}
