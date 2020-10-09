using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ThomasGreg.API.Cliente.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private ThomasGreg.DAL.Repository.Cliente.ClienteRepository _repository;
        public ClienteController()
        {
            _repository = new DAL.Repository.Cliente.ClienteRepository();
        }

        [HttpGet]
        public IActionResult Index()
        {
            _repository = new DAL.Repository.Cliente.ClienteRepository();
            var cliente = _repository.BuscarTodos();
            return Ok(cliente);
        }

        [HttpPost]
        public IActionResult Add(ThomasGreg.Entidade.Cliente cliente)
        {
            try
            {
                _repository = new DAL.Repository.Cliente.ClienteRepository();
                return Ok(_repository.Add(cliente));
            }
            catch (Exception ex)
            {
                return Ok(false);
            }
        }

        [HttpPost]
        public IActionResult Update(ThomasGreg.Entidade.Cliente cliente)
        {
            try
            {
                _repository = new DAL.Repository.Cliente.ClienteRepository();
                return Ok(_repository.Update(cliente));
            }
            catch (Exception ex)
            {
                return Ok(false);
            }

        }

        [HttpPost]
        public IActionResult Delete(string email)
        {
            try
            {
                _repository = new DAL.Repository.Cliente.ClienteRepository();
                return Ok(_repository.Delete(email));
            }
            catch (Exception ex)
            {
                return Ok(false);
            }

        }

        [HttpGet("BuscarPorEmail/{email}")]
        public IActionResult BuscarPorEmail(string email)
        {
            try
            {
                _repository = new DAL.Repository.Cliente.ClienteRepository();
                return Ok(_repository.Buscar(email));
            }
            catch (Exception ex)
            {
                return Ok(false);
            }
        }
    }
}
