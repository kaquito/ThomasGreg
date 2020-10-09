using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ThomasGreg.API.Logradouro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private ThomasGreg.DAL.Repository.Cliente.ClienteRepository _repository;
        public HomeController()
        {
            _repository = new DAL.Repository.Cliente.ClienteRepository();
        }

        [HttpGet]
        public IActionResult Index()
        {
            var cliente = _repository.BuscarTodos();
            return Ok(cliente);// Json(new { cliente = cliente });
        }
    }
}
