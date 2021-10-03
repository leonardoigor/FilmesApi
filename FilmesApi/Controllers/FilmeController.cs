using FilmesApi.Data;
using FilmesApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmesApi.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class FilmeController : ControllerBase
    {
        private FilmeContext _ctx;

        public FilmeController(FilmeContext ctx)
        {
            _ctx = ctx;
        }
        private static List<Filme> filmes = new List<Filme>();

        [HttpPost]
        public IActionResult AdicionarFilme([FromBody] Filme filme)
        {
            _ctx.Filmes.Add(filme);
            _ctx.SaveChanges();
            return CreatedAtAction(nameof(PegarFilme), new { Id = filme.Id }, filme);
        }

        [HttpGet]
        public async Task<IActionResult> PegarFilmes()
        {
            filmes = await _ctx.Filmes.ToListAsync();

            return Ok(filmes);
        }


        [HttpGet("{id}")]

        public IActionResult PegarFilme(int? id)
        {


            Filme filme = _ctx.Filmes.FirstOrDefault(f => f.Id == id);

            if (filme != null)
            {
                return Ok(filme);
            }
            else
            {
                return NotFound();
            }
        }
    }
}
