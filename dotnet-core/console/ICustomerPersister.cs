using System;
using System.IO;

namespace samples.dependencyInjection
{
    public interface ICustomerPersister
    {
        Customer Get(string entityGuid);
        Customer Upsert(Customer entity);
    }
}