using System;
using System.IO;

namespace samples.dependencyInjection
{
    public class OrderFilePersister : IOrderPersister
    {
        public Order Get(string entityGuid)
        {
            return new Order{Guid=entityGuid};
        }

        public Order Upsert(Order entity)
        {
           File.WriteAllText("order.json",  "some json");
           return new Order{Guid=Guid.NewGuid().ToString()};
        }
    }
}