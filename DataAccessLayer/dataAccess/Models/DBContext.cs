using System;
using MongoDB.Driver;

namespace DAL.dataAccess.Models
{
	public class DBContext
	{
		public DBContext()
		{
            MongoClient dbClient = new MongoClient("mongodb://localhost:27017");

            var dbList = dbClient.ListDatabaseNames().ToList();

            Console.WriteLine("The list of databases on this server is: ");
            foreach (var db in dbList)
            {
                Console.WriteLine(db);
            }
        }
    }
}

