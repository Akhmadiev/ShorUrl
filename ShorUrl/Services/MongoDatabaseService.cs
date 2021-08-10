namespace ShorUrl.Services
{
    using ShorUrl.Interfaces;
    using System.Threading.Tasks;

    using MongoDB.Driver;
    using System.Linq.Expressions;
    using System;
    using MongoDB.Bson;
    using System.Collections.Generic;

    public class MongoDatabaseService : IDbService
    {
        private readonly IMongoDatabase _db;

        public MongoDatabaseService(string connectionString)
        {
            var mangoClient = new MongoClient();
            _db = mangoClient.GetDatabase(connectionString);
        }

        public async Task InsertRecordAsync<T>(string table, T record)
        {
            var collection = _db.GetCollection<T>(table);
            await collection.InsertOneAsync(record);
        }

        public async Task<List<T>> GetRecordsAsync<T>(string table, Expression<Func<T, bool>> filter = null)
        {
            var collection = _db.GetCollection<T>(table);
            var records = await collection.Find(filter ?? (x => true)).ToListAsync();

            return records;
        }
    }
}
