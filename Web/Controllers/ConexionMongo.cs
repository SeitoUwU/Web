using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
namespace Web.Controllers
{
    public class ConexionMongo
    {
        static string servidor;
        static string puerto = "27017";
        public static MongoClient cliente = new MongoClient("Mongodb:" + servidor + puerto);
        public static MongoClient establecerconexion()
        {

            try
            {
                List<String> NombresBasesDatos = cliente.ListDatabaseNames().ToList();
                foreach (var db in NombresBasesDatos)
                {

                }

            }
            catch (MongoClientException e)
            {



            }
            return cliente;
        }
    }
}
