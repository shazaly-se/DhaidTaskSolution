using OrderAppApi.Commands;

using MediatR;
using MongoDB.Driver;
using OrderAppApi.Models;

namespace CustomerAppApi.Handlers
{
    public class UpdateOrderHandler : IRequestHandler<UpdateOrderCommand, Order>
    {
        private readonly IMongoCollection<Order> _orderCollection;

        public UpdateOrderHandler()
        {
            var dbHost = Environment.GetEnvironmentVariable("DB_HOST");
            var dbName = Environment.GetEnvironmentVariable("DB_Order_NAME");
            var connectionString = $"mongodb://{dbHost}:27017/{dbName}";
            var mongoURL = MongoUrl.Create(connectionString);
            var mogoClient = new MongoClient(mongoURL);
            var database = mogoClient.GetDatabase(mongoURL.DatabaseName);
            _orderCollection = database.GetCollection<Order>("order");
        }
        public async Task<Order> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
        {
            var order = request.order;
            var filter = Builders<Order>.Filter.Eq(x => x.OrderId, order.OrderId);
            await _orderCollection.ReplaceOneAsync(filter, order);
            return request.order;
            //return Ok();
        }
    }
}
