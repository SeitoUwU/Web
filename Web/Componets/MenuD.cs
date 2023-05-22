using Web.Models;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using Web.Data;


namespace Web.Componets
{
    public class MenuD : ViewComponent
    {
        private readonly Contexto contexto;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public MenuD(Contexto contexto, IHttpContextAccessor httpContextAccessor)
        {
            this.contexto = contexto;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {

            List<Vistas> menu = ListaVistas(int.Parse(_httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(c => c.Type == System.Security.Claims.ClaimTypes.NameIdentifier)?.Value));

            return View(menu);
        }


        public List<Vistas> ListaVistas(int identidi)
        {
            List<Vistas> vistas = new List<Vistas>();

            try
            {
                using (MySqlConnection cone = new(contexto.Conexion))
                {
                    cone.Open();
                    using (MySqlCommand cmd = new("menu dinamico", cone))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@d_ingresado", identidi);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Vistas vis = new Vistas();

                                vis.nombrevista = reader.GetString(0);
                                vis.Controlador = reader.GetString(1);
                                vis.Accion = reader.GetString(2);

                                vistas.Add(vis);
                            }
                        }
                        cone.Close();
                    }
                }


            }
            catch (Exception)
            {

                throw;
            }

            return vistas;
        }
    }
}
