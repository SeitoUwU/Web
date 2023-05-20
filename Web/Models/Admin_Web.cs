using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Models
{
    public class Admin_Web
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public int Id { get; set; }
        [BsonElement("nombre_imagen")]
        public string nombre_imagen { get; set; }
        [BsonElement("url")]
        public int sise { get; set; }
        public byte[] Imagen { get; set; }
        public String url { get; set; }


    }
}

