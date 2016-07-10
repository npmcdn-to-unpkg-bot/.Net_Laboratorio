using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALayer.Contexts
{
    public class MongoCtx
    {
        MongoClient client;
        IMongoDatabase database;
        IMongoCollection<BsonDocument> collection;
        BsonDocument document;
        static MongoCtx currentInstance = null;
        public MongoCtx(string tenantID) {
            client = new MongoClient("mongodb://localhost");
            database = client.GetDatabase(tenantID);
            collection = database.GetCollection<BsonDocument>("IntState");
        }
        public void SaveCurrent(BsonDocument doc) {
            collection.InsertOne(doc);
        }
        public BsonDocument GetIntState(int interactionId) {
            var filter = Builders<BsonDocument>.Filter.Eq("interactionId", interactionId);
            return this.collection.Find(filter).ToList().Last();
        }
        public List<BsonDocument> GetAllIntState(int interactionId)
        {
            var filter = Builders<BsonDocument>.Filter.Eq("interactionId", interactionId);
            return this.collection.Find(filter).ToList();
        }
    }
}
