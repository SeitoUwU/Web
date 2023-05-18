using Microsoft.AspNetCore.Identity;
using MySql.Data.MySqlClient;
using NuGet.Protocol.Plugins;
using System.Data;
using Web.Models;

namespace Web.Datos
{
   
    public class ReportesDatos
    {
        private readonly MySqlConnection connection;
        public ReportesDatos(MySqlConnection connection)
        {
            this.connection = connection;
        }
        public List<PerRegistraMascModel> ReportesMascotasporFecha()
        {
            List<PerRegistraMascModel> list = new List<PerRegistraMascModel>();

            try
            {
                using (connection)
                {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand("mascota_por_fecha", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                           
                            while (reader.Read())
                            {
                                PerRegistraMascModel  persona = new PerRegistraMascModel();
                                persona.PERREGISMASC_ID = reader.GetInt32(reader.GetOrdinal("PERREGISMASC_ID"));
                                persona.PERREGISMASC_FechaRegistro = reader.GetString(reader.GetOrdinal("PERREGISMASC_FechaRegistro"));
                                persona.FKMASC_ID = reader.GetInt32(reader.GetOrdinal("FKMASC_ID"));
                                persona.cantidad_mascotas = reader.GetInt32(3);
                                list.Add(persona);  
                          
                            }
                            

                        }
                    }
                }
                connection.Close();

            }
            catch (Exception ex)
            {
                return list;

            }
            return list;

        }
    }
}
