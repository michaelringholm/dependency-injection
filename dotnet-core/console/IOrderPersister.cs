using System;
using System.IO;

namespace samples.dependencyInjection
{
    public interface IOrderPersister
    {
        Order Get(string entityGuid);
        Order Upsert(Order entity);
    }
}