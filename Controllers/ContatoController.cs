using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRUD_API.Context;
using CRUD_API.Models;
using Microsoft.AspNetCore.Mvc;

namespace CRUD_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContatoController : ControllerBase
    {
        private readonly AgendaContext _context;
        public ContatoController(AgendaContext context)
        {
            _context = context;
        }
        public IActionResult Create(Contato contato)
        {

        }
    }
}