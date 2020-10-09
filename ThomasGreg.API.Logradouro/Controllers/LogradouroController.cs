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
    public class LogradouroController : ControllerBase
    {
        private DAL.Repository.Logrdouro.LogradouroRepository _repository;
        public LogradouroController()
        {

            _repository = new DAL.Repository.Logrdouro.LogradouroRepository();
        }

        [HttpGet]
        public IActionResult Index()
        {
            return Ok("Pagina Index");
        }

        [HttpPost]
        public IActionResult Add(ThomasGreg.Entidade.Logradouro logradouro)
        {
            try
            {
                return Ok(_repository.Add(logradouro));
            }
            catch (Exception ex)
            {
                return Ok(false);
            }
        }

        [HttpPut]
        public IActionResult Update(ThomasGreg.Entidade.Logradouro logradouro)
        {
            try
            {
                return Ok(_repository.Update(logradouro));
            }
            catch (Exception ex)
            {
                return Ok(false);
            }
        }

        [HttpGet]
        public IActionResult BuscarPorIdCliente(int idCliente)
        {
            try
            {
                return Ok(_repository.Buscar(idCliente));
            }
            catch (Exception ex)
            {
                return Ok(false);
            }
        }

        [HttpDelete]
        public IActionResult ApagarPorIdLogradouro(int idLogradouro)
        {
            try
            {
                return Ok(_repository.Delete(idLogradouro));
            }
            catch (Exception ex)
            {
                return Ok(false);
            }
        }
    }
}
