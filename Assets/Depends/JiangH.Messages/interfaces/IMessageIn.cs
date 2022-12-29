using System;
using System.Collections.Generic;

namespace JiangH.Messages.Interfaces
{
    public interface IMessageIn
    {
        Dictionary<Type, MessageProceItem> dict { get; }
    }
}
