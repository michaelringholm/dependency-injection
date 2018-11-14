using System;
using System.IO;

namespace samples.dependencyInjection
{
    public class CustomerFilePersister : ICustomerPersister
    {
        public Customer Get(string entityGuid)
        {
            return new Customer{Guid=entityGuid};
        }

        public Customer Upsert(Customer entity)
        {
           File.WriteAllText("customer.json",  "some json");
           return new Customer{Guid=Guid.NewGuid().ToString()};
        }
    }
}