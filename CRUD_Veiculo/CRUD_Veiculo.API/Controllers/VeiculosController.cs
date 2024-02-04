using CRUD_Veiculo.API.Data.Context;
using CRUD_Veiculo.API.Data.Repository.Interface;
using CRUD_Veiculo.API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CRUD_Veiculo.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VeiculosController : ControllerBase
    {
        private readonly ILogger<VeiculosController> _logger;
        private readonly IVeiculoRepository _veiculoRepository;
        public VeiculosController(ILogger<VeiculosController> logger, IVeiculoRepository veiculoRepository)
        {
            _logger = logger;
            _veiculoRepository = veiculoRepository;
        }

        [HttpGet]
        [Route("GetVeiculos")]
        public async Task<ActionResult<IEnumerable<Veiculo>>> GetVeiculos()
        {
            try
            {
                var result = await _veiculoRepository.GetAll();
                return Ok(result);
            }
            catch (Exception e)
            { return BadRequest(e.Message); }
        }

        [HttpGet]
        [Route("GetVeiculoById")]
        public async Task<ActionResult<Veiculo>> GetVeiculoById(int id)
        {
            try
            {
                var result = await _veiculoRepository.GetById(id);
                return Ok(result);
            }
            catch (Exception e)
            { return BadRequest(e.Message); }
        }

        [HttpPost]
        [Route("CreateVeiculo")]
        public async Task<ActionResult<int>> CreateVeiculo(Veiculo veiculo)
        {
            try
            {
                var result = await _veiculoRepository.Create(veiculo);
                return Ok(result);
            }
            catch (Exception e)
            { return BadRequest(e.Message); }
        }

        [HttpPut]
        [Route("UpdateVeiculo")]
        public async Task<ActionResult<int>> UpdateVeiculo(Veiculo veiculo)
        {
            try
            {
                var result = await _veiculoRepository.Update(veiculo);
                return Ok(result);
            }
            catch (Exception e)
            { return BadRequest(e.Message); }
        }

        [HttpDelete]
        [Route("DeleteVeiculo")]
        public async Task<ActionResult<int>> DeleteVeiculo(int id)
        {
            try
            {
                var result = await _veiculoRepository.Delete(id);
                return Ok(result);
            }
            catch (Exception e)
            { return BadRequest(e.Message); }
        }
    }
}
