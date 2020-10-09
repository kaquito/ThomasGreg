using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ThomasGreg.Entidade;
using ThomasGreg.Site.Services;

namespace ThomasGreg.Site.Controllers
{
    public class ClienteControle : Controller
    {
        private string _RouteSite = string.Empty;
        public ClienteControle()
        {
            _RouteSite = "https://localHost:44377/Api/Cliente/";
        }
                
        public IActionResult Index()
        {
            var ret = new WebApiService<Cliente>().GetTAsync($"{_RouteSite}Index");
            return View(ret);
        }

        [HttpPost]
        public IActionResult Add()
        {            
            return View(new Cliente());
        }

        [HttpPost]
        public IActionResult Add(Cliente cliente)
        {
            var ret = new WebApiService<Cliente>().PutTAsync($"{_RouteSite}Add/", cliente);
            return View(ret);
        }

        [HttpPut]
        public IActionResult Update(Cliente cliente)
        {
            var ret = new WebApiService<Cliente>().PutTAsync($"{_RouteSite}Update/", cliente);
            return View(ret);
        }
    }
}
