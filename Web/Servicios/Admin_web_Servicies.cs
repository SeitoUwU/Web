using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Models;

namespace Web.Servicios
{
    public class Admin_web_Servicies
    {
        private IMongoCollection<Admin_Web> beers;
        public Admin_web_Servicies(IBarSenttings senttings)
        {
            var cliente = new MongoClient(senttings.Server);
            var database = cliente.GetDatabase(senttings.Database);
            beers = database.GetCollection<Admin_Web>(senttings.Collection);
        }
        public List<Admin_Web> Get()
        {
            return beers.Find(d => true).ToList();
        }
        public Admin_Web Create(Admin_Web admin_Web)
        {
            beers.InsertOne(admin_Web);
            return admin_Web;
        }
        public void Update(int id,Admin_Web admin_Web)
        {
            beers.ReplaceOne(admin_Web => admin_Web.Id == id, admin_Web);
        }
        public void Delete (int id,Admin_Web admin_Web)
        {
            beers.DeleteOne(d => d.Id == id);
        }
    }
}
