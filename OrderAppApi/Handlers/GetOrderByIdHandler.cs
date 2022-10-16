
using OrderAppApi.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;
using OrderAppApi.Models;

namespace CustomerAppApi.Handlers
{
    public class GetOrderByIdHandler : IRequestHandler<GetOrderByIdQuery, Order>
    {

        private readonly IMongoCollection<Order> _orderCollection;
        public GetOrderByIdHandler()
        {
            var dbHost = Environment.GetEnvironmentVariable("DB_HOST");
            var dbName = Environment.GetEnvironmentVariable("DB_Order_NAME");
            var connectionString = $"mongodb://{dbHost}:27017/{dbName}";
            var mongoURL = MongoUrl.Create(connectionString);
            var mogoClient = new MongoClient(mongoURL);
            var database = mogoClient.GetDatabase(mongoURL.DatabaseName);
            _orderCollection = database.GetCollection<Order>("order");
        }
        public async Task<Order> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
        {
            var filter = Builders<Order>.Filter.Eq(x => x.OrderId, request.orderId);
            return await _orderCollection.Find(filter).SingleOrDefaultAsync();
        }
    }
}
