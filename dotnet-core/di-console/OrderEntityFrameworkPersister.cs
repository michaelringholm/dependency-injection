namespace samples.dependencyInjection
{
    public class OrderEntityFrameworkPersister : IOrderPersister
    {
        dynamic _efClient;
        public OrderEntityFrameworkPersister() {
            _efClient = new object();
        }

        public Order Get(string entityGuid)
        {
            return _efClient.Get(entityGuid);
        }

        public Order Upsert(Order entity)
        {
            return _efClient.Upsert(entity);
        }
    }
}