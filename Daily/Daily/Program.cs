using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Daily
{
    class Program
    {
        static void Main(string[] args)
        {
            var person = new PersonModel
            {
                FirstName = "Ania",
                LastName = "Szczek",
                PrimaryAddress = new AddressModel
                {
                    StreetAddress = "Ziolowa",
                    City = "Mirkow"
                }
            };

            var db = new MongoCRUD("AddressBook");
            //INSERT
            db.InsertRecord("Users", person);

            //Find all
            var records = db.LoadRecords<PersonModel>("Users");
            foreach (var record in records)
            {
                Console.WriteLine(record.Id);
            }

            //Find One
            var id = records.First().Id;

            var rec = db.LoadRecordById<PersonModel>("Users", id);
            //Console.WriteLine((rec.Id.ToString()==id));

            //Update
            rec.FirstName = "Zofia";
            db.UpsertRecord("Users", id, rec);

            //Delete
            db.DeleteRecord<PersonModel>("Users", id);

        }
    }

    public class PersonModel
    {
        [BsonId]
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public AddressModel PrimaryAddress { get; set; }
    }

    public class AddressModel
    {
        public string StreetAddress { get; set; }
        public string City { get; set; }
    }

    public class MongoCRUD
    {
        public IMongoDatabase db;

        public MongoCRUD(string database)
        {
            var client = new MongoClient();
            db = client.GetDatabase(database);
        }

        public void InsertRecord<T>(string table, T record)
        {
            var collection = db.GetCollection<T>(table);

            collection.InsertOne(record);
        }

        public List<T> LoadRecords<T>(string table)
        {
            var collection = db.GetCollection<T>(table);

            return collection.Find(new BsonDocument()).ToList();

        }

        public T LoadRecordById<T>(string table, Guid id)
        {
            var collection = db.GetCollection<T>(table);

            return collection.Find(new BsonDocument("_id", id)).First();

        }

        public void UpsertRecord<T>(string table, Guid id, T record)
        {
            var collection = db.GetCollection<T>(table);
            collection.ReplaceOne(new BsonDocument("_id", id), record);
        }


        public void DeleteRecord<T>(string table, Guid id)
        {
            var collection = db.GetCollection<T>(table);
            collection.DeleteOne(new BsonDocument("_id", id));

        }

    }
}
