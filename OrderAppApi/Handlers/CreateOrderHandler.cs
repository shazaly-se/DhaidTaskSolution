using OrderAppApi.Commands;

using MediatR;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using OrderAppApi.Models;

namespace CustomerAppApi.Handlers
{
    public class CreateOrderHandler : IRequestHandler<CreateOrderCommand, Order>
    {
        private readonly IMongoCollection<Order> _orderCollection;

        public CreateOrderHandler()
        {
            var dbHost = Environment.GetEnvironmentVariable("DB_HOST");
            var dbName = Environment.GetEnvironmentVariable("DB_Order_NAME");
            var connectionString = $"mongodb://{dbHost}:27017/{dbName}";
            var mongoURL = MongoUrl.Create(connectionString);
            var mogoClient = new MongoClient(mongoURL);
            var database = mogoClient.GetDatabase(mongoURL.DatabaseName);
            _orderCollection = database.GetCollection<Order>("order");
        }
        public async Task<Order> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            await _orderCollection.InsertOneAsync(request.order);
            return request.order;
        }
    }
}
