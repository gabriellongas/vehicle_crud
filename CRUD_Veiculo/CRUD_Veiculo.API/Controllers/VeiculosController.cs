using CRUD_Veiculo.API.Data.Context;
using CRUD_Veiculo.API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CRUD_Veiculo.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VeiculosController : ControllerBase
    {
        private readonly ILogger<VeiculosController> _logger;
        private readonly CRUDContext _context;
        public VeiculosController(ILogger<VeiculosController> logger, CRUDContext context)
        {
            _logger = logger;
            _context = context;
        }

        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<Veiculo>>> GetVeiculos()
        //{
        //    // Exemplo de como chamar uma stored procedure
        //    var veiculos = await _context.Veiculo.FromSqlRaw("EXEC sp_LerTodosVeiculos").ToListAsync();

        //    return veiculos;
        //}


        [HttpGet(Name = "GetVeiculos")]
        public IEnumerable<Veiculo> Get()
        {
            return _context.Veiculos;
        }
    }
}
