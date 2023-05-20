using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web.Models;
using Web.Servicios;

namespace WEB_Mongo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Admin_WebController : ControllerBase
    {
        public Admin_WebController _beerServicie;

        public Admin_WebController(Admin_web_Servicies _beerServicie)
        {
            _beerServicie = _beerServicie;

        }
        [HttpGet]
        public ActionResult<List<Admin_Web>> Get()
        {
            return _beerServicie.Get();

        }
        [HttpPost]
        public ActionResult<Admin_Web> Create(Admin_Web admin_Web)
        {
            _beerServicie.Create(admin_Web);
            return Ok(admin_Web);
        }
        [HttpPut]
        public ActionResult Update(int id, Admin_Web admin_Web)
        {
            _beerServicie.Update(admin_Web.Id, admin_Web);
            return Ok();
        }
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _beerServicie.Delete(id);
            return Ok();
        }
        [HttpPost]
        public async Task<IActionResult> Crear(Admin_Web admin_Web, IFormFile imagen)
        {
            if (imagen != null && imagen.Length > 0)
            {
                using (var ms = new MemoryStream())
                {
                    await imagen.CopyToAsync(ms);
                    admin_Web.Imagen = ms.ToArray();
                }
            }

            _beerServicie.Create(admin_Web);
            return RedirectToAction("Index");
        }

    }
}
