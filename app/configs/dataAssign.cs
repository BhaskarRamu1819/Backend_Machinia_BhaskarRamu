using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace app.configs
{
    public class dataAssign //To store and pass structured data for crud operations and defined it's datatypes
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]

        public ObjectId _id = new ObjectId();

        public string CenterName { get; set; }
        public string CenterCode { get; set; }
        public long CreatedOn { get; set; }
        public int StudentCapacity { get; set; }

        public Dictionary<string, string> Address { get; set; }
        public List<string> CoursesOffered { get; set; }
        public string ContactEmail { get; set; }
        public string ContactPhone { get; set; }

    }
}
