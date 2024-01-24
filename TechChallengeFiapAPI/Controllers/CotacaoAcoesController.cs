using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TechChallengeFiap.Application.Interfaces;
using TechChallengeFiap.Domain.Enums;

namespace TechChallengeFiap.Controllers
{
    [ApiController]
    [Route("api/CotacaoAcoes")]
    public class CotacaoAcoesController : ControllerBase
    {
        private readonly ILogger<CotacaoAcoesController> _logger;
        private readonly ICotacoesAcoesService _cotacaoAcoesService;

        public CotacaoAcoesController(ILogger<CotacaoAcoesController> logger,
                                      ICotacoesAcoesService cotacoesAcoesService)
        {
            _logger = logger;
            _cotacaoAcoesService = cotacoesAcoesService;
        }
        [Authorize(Roles = $"{Permissoes.Administrador}, {Permissoes.Usuario}")]
        [HttpGet("{simbolo}")]
        public async Task<IActionResult> GetCotacao(string simbolo)
        {
            try
            {
                var content = await _cotacaoAcoesService.GetCotacao(simbolo);
                return Ok(content);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro ao buscar cotação da ação {simbolo}: {ex.Message}");
                return StatusCode(500, "Erro interno ao processar a solicitação.");
            }
        }
        [Authorize(Roles = $"{Permissoes.Administrador}, {Permissoes.Usuario}")]
        [HttpGet("top10")]
        public async Task<IActionResult> GetTop10SubidasEDecidas()
        {
            try
            {
                var content = await _cotacaoAcoesService.GetTop10SubidasEDecidas();
                return Ok(content);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro ao buscar as 10 ações que mais subiram no dia: {ex.Message}");
                return StatusCode(500, "Erro interno ao processar a solicitação.");
            }
        }


    }
}
