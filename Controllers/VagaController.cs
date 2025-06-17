using Atv_Cap7WebAPI.Helpers;
using Atv_Cap7WebAPI.Repository;
using Atv_Cap7WebAPI.Repository.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Atv_Cap7WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VagaController : ControllerBase
    {
        private readonly IVagaRepository _vagaRepository;

        public VagaController(IVagaRepository vagaRepository)
        {
            _vagaRepository = vagaRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetVagas([FromQuery] PaginationParameters paginationParams)
        {
            var vagas = await _vagaRepository.GetVagasAsync(paginationParams);
            return Ok(vagas);
        }
    }
}
