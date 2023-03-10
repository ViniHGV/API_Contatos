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
        
        [HttpPost("CriarContato")]
        public IActionResult Create(Contato contato)
        {
            _context.Add(contato);
            _context.SaveChanges();
            return CreatedAtAction(nameof(ObterPorId), new{ id = contato.id}, contato);
        }

        [HttpGet("ObterPorID{id}")]
        public IActionResult ObterPorId(int id)
        {
            var contato = _context.Contatos.Find(id);

            if(contato == null)
                return NotFound();

            return Ok(contato);
        }

        [HttpGet("ObterPorNome")]
        public IActionResult ObterPorNome(string nome)
        {
            var contatos = _context.Contatos.Where(x => x.Nome.Contains(nome));
            return Ok(contatos);
        }

        [HttpGet("ObterPorTelefone")]
        public IActionResult ObterPorTelefone(string telefone)
        {
            var contatos = _context.Contatos.Where(x => x.Telefone.Contains(telefone));
            return Ok(contatos);
        }
        
        [HttpGet("ListarTodos")]
        public IActionResult ListarTodos()
        {
            var contatos = _context.Contatos.ToList();
            return Ok(contatos);
        }

        [HttpPut("AtualizarContato{id}")]
        public IActionResult Atualizar(int id, Contato contato)
        {
            var contatoBanco = _context.Contatos.Find(id);

            if(contatoBanco == null)
                return NotFound();

            contatoBanco.Nome= contato.Nome;
            contatoBanco.Telefone = contato.Telefone;
            contatoBanco.Ativo = contato.Ativo;
            contatoBanco.Url_Img = contato.Url_Img;

            _context.Contatos.Update(contatoBanco);
            _context.SaveChanges();

            return Ok(contatoBanco);
        }

        [HttpDelete("DeletarContato")]
        public IActionResult Deletar(int id)
        {
            var contatoBanco = _context.Contatos.Find(id);

            if(contatoBanco == null)
                return NotFound();

            _context.Contatos.Remove(contatoBanco);
            _context.SaveChanges();
            return Ok("Contato Deletado Com Sucesso !");
        }

            
                    

    }
}