using System;
using System.IO;

namespace com.opusmagus
{
    public interface IOrderPersister
    {
        Order Get(string entityGuid);
        Order Upsert(Order entity);
    }
}
