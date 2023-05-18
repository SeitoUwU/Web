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
        public ContenidoModel ReportesMascotasporFecha(PerRegistraMascModel persona, MascotaModel mascota)
        {
        
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

                                list.Add(new ContenidoModel
                                {
                                    PerRegistraMasc = new List<PerRegistraMascModel>
                            {
                                new PerRegistraMascModel
                                {
                                    PERREGISMASC_ID = Convert.ToInt32(reader["PERREGISTRAMASC_ID"]),
                                  PERREGISMASC_FechaRegistro = (DateOnly)reader["PERREGISMASC_FechaRegistro"],
                                  FKMASC_ID=Convert.ToInt32(reader["FKMASC_ID"])

                            }
                            },
                                    mascotas = new List<MascotaModel>
                            {
                                new MascotaModel
                                {
                                    MASC_ID = Convert.ToInt32(reader["MASC_ID"])
                                }
                            }
                                });
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
