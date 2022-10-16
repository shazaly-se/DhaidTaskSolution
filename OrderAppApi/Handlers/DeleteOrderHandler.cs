using OrderAppApi.Commands;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;
using OrderAppApi.Models;

namespace CustomerAppApi.Handlers
{
    public class DeleteOrderHandler : IRequestHandler<DeleteOredrCommand, Order>
    {
        private readonly IMongoCollection<Order> _orderCollection;

        public DeleteOrderHandler()
        {
            var dbHost = Environment.GetEnvironmentVariable("DB_HOST");
            var dbName = Environment.GetEnvironmentVariable("DB_Order_NAME");
            var connectionString = $"mongodb://{dbHost}:27017/{dbName}";
            var mongoURL = MongoUrl.Create(connectionString);
            var mogoClient = new MongoClient(mongoURL);
            var database = mogoClient.GetDatabase(mongoURL.DatabaseName);
            _orderCollection = database.GetCollection<Order>("order");
        }
        public async Task<string> Handle(DeleteOredrCommand request, CancellationToken cancellationToken)
        {
            var filter = Builders<Order>.Filter.Eq(x => x.OrderId, request.orderId);
            await _orderCollection.DeleteOneAsync(filter);
            return
             request.orderId;
        }

        Task<Order> IRequestHandler<DeleteOredrCommand, Order>.Handle(DeleteOredrCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
