using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ThomasGreg.API.Usuario.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        public UsuarioController()
        {

            //_repository = new DAL.Repository.Cliente.ClienteRepository();
        }

        [HttpGet]
        public IActionResult Index()
        {
            //_repository = new DAL.Repository.Cliente.ClienteRepository();
            //var cliente = _repository.BuscarTodos();
            //return Ok(cliente);// Json(new { cliente = cliente });
            return Ok("Marivaldo Test logradouro");
        }
    }
}
