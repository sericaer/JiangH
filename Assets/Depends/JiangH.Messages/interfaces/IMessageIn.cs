using System;
using System.Collections.Generic;

namespace JiangH.Messages.Interfaces
{
    public interface IMessageIn
    {
        Dictionary<Type, MessageProceItem> dict { get; }
    }

    public interface IMessageBus
    {
        void Register(IMessageIn messageIn);
        void Register(IMessageOut messageIn);
        void Register(IMessageInOut messageIn);

        void SendMessage(MESSAGE msg);
    }
}
