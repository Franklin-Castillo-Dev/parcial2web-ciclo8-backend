using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using elecciones_api.Models;

namespace elecciones_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EleccionesController : ControllerBase
    {
        private readonly Cc101020Mm102120Context _context;

        public EleccionesController(Cc101020Mm102120Context context)
        {
            _context = context;
        }

        // GET: api/Elecciones
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Elecciones2019>>> GetElecciones2019s()
        {
          if (_context.Elecciones2019s == null)
          {
              return NotFound();
          }
            return await _context.Elecciones2019s.ToListAsync();
        }

        // GET: api/Elecciones/CantidadVotos
        [HttpGet("CantidadVotos")]
        public async Task<ActionResult<int>> GetCantidadVotos()
        {
            try
            {

                var sumaTotalVotos = await _context.Elecciones2019s
                    .SumAsync(e => e.Votos);

                var resultados = await _context.Elecciones2019s
                    .GroupBy(e => e.Candidato)
                    .Select(g => new
                    {
                        Candidato = g.Key,
                        CantidadDeVotos = g.Sum(e => e.Votos),
                        Porcentaje = Math.Round((decimal)(g.Sum(e => e.Votos) * 100.0 / sumaTotalVotos), 2)
                    })
                    .OrderByDescending(r => r.Porcentaje)
                    .ToListAsync();


                return Ok(resultados);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

    }
}
