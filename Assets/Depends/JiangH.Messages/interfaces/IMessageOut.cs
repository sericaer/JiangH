using System;

namespace JiangH.Messages.Interfaces
{
    public interface IMessageOut
    {
        Action<MESSAGE> SendMessage { get; set; }
    }
}
