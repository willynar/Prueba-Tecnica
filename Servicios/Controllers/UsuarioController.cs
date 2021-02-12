using Entities.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaTecnica.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {

        private readonly IUserService IUserService;

        public UsuarioController(IUserService iUserService)
        {
            IUserService = iUserService;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]        
        public IActionResult get()
        {
            return Ok(IUserService.Consulta());
        }
    }
}
