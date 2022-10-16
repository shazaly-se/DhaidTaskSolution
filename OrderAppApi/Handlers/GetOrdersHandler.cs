
using OrderAppApi.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;
using OrderAppApi.Models;

namespace CustomerAppApi.Handlers
{
    public class GetOrdersHandler : IRequestHandler<GetOrderQuery, List<Order>>
    {
        private readonly IMongoCollection<Order> _orderCollection;

        public GetOrdersHandler()
        {
            var dbHost = Environment.GetEnvironmentVariable("DB_HOST");
            var dbName = Environment.GetEnvironmentVariable("DB_Order_NAME");
            var connectionString = $"mongodb://{dbHost}:27017/{dbName}";
            var mongoURL = MongoUrl.Create(connectionString);
            var mogoClient = new MongoClient(mongoURL);
            var database = mogoClient.GetDatabase(mongoURL.DatabaseName);
            _orderCollection = database.GetCollection<Order>("order");
        }
        public async Task<List<Order>> Handle(GetOrderQuery request, CancellationToken cancellationToken)
        {
            return await _orderCollection.Find(Builders<Order>.Filter.Empty).ToListAsync();
        }
    }
}
