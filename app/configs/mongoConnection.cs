using MongoDB.Bson;
using MongoDB.Driver;

namespace app.configs
{
    public class mongoConnection //To store and pass around MongoDB connection configuration information
    {
        public string ConnectionSring { get; set; } = string.Empty;
        public string DatabaseName { get; set; } = string.Empty;
        public string CollectionNameInDb { get; set; } = string.Empty;
    }
}
