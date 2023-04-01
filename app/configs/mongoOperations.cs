using Amazon.Runtime.Internal;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Core.Operations.ElementNameValidators;
using System.Linq;

namespace app.configs
{
    public class mongoOperations
    {
        private readonly IMongoCollection<dataAssign> trainingCenters;
        public mongoOperations(IOptions<mongoConnection> options) //Making MongoDB connection
        {
            var mongoClient = new MongoClient("mongodb://localhost:27017/");
            trainingCenters = mongoClient.GetDatabase(options.Value.DatabaseName)
                .GetCollection<dataAssign>(options.Value.CollectionNameInDb);
        }

        //Get the all saved training centers data
        public async Task<List<dataAssign>> Get() =>
            await trainingCenters.Find(_ => true).ToListAsync();

        //Get unique center data by fetching the CenterCode
        public async Task<dataAssign> Get(string CenterCode) =>
            await trainingCenters.Find(m => m.CenterCode == CenterCode).FirstOrDefaultAsync();

        //Insert Data into DB by POST call
        public async Task Create(dataAssign newCenter)
        {
            var currentEpochTimeInSeconds = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
            newCenter.CreatedOn = currentEpochTimeInSeconds;

            await trainingCenters.InsertOneAsync(newCenter);
        }
        
        //Email validation method
        public virtual bool ValidateEmail(string email)
        {
            var atTheRate = email.Contains("@");
            var endString = email.EndsWith(".com");
            return atTheRate & endString;
        }
        /*public async Task<dataAssign> getAddress(object address) =>
            await trainingCenters.Find(m =>
                    m.Address.DetailedAddress == ((dynamic)address).DetailedAddress &&
                    m.Address.City == ((dynamic)address).City &&
                    m.Address.State == ((dynamic)address).State &&
                    m.Address.Pincode == ((dynamic)address).Pincode).FirstOrDefaultAsync();
        return address*/
        //var filter2 = Builders<BsonDocument>.Filter.Eq("level", 2);
    }
}
