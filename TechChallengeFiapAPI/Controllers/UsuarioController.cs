using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TechChallengeFiap.Application.DTOs;
using TechChallengeFiap.Application.Interfaces;
using TechChallengeFiap.Application.Services;
using TechChallengeFiap.Domain.Entities;
using TechChallengeFiap.Domain.Enums;

namespace TechChallengeFiapAPI.Controllers
{
    [ApiController]
    [Route("Usuario")]
    public class UsuarioController : ControllerBase
    {

        private readonly ILogger<UsuarioController> _logger;
        private readonly IUsuarioService _usuarioService;

        public UsuarioController(ILogger<UsuarioController> logger,
                                 IUsuarioService usuarioService)
        {
            _logger = logger;
            _usuarioService = usuarioService;
        }
        [Authorize]
        [Authorize(Roles = $"{Permissoes.Administrador}")]
        [HttpGet("obter-todos-com-pedidos/{id}")]
        public async Task<IActionResult> ObterComConsultas(int id)
        {
            try
            {
                _logger.LogInformation("Executando método ObterComConsultas");
                return Ok(await _usuarioService.UsuarioComConsultas(id));
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro ao buscar todos os usuários com consultas- Exception Forçada: {ex.Message}");
                return StatusCode(500, "Erro interno ao processar a solicitação.");
            }
            
        }
        [Authorize]
        [Authorize(Roles = $"{Permissoes.Administrador}")]
        [HttpGet()]
        public async Task<IActionResult> ObterTodosUsuarios()
        {
            try
            {
                _logger.LogInformation("Executando método ObterTodosUsuarios");
                
                return Ok(await _usuarioService.ObterTodos());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"{DateTime.Now} - Exception Forçada: {ex.Message}");
                return BadRequest();
            }

        }
        [Authorize]
        [Authorize(Roles = $"{Permissoes.Administrador}")]
        [HttpGet("obter-por-usuario-id/{id}")]
        public IActionResult ObterPorUsuarioId(int id)
        {
            try
            {
                _logger.LogInformation("Executando método ObterPorUsuarioId");
                return Ok(_usuarioService.ObterPorId(id));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"{DateTime.Now} - Exception Forçada: {ex.Message}");
                return BadRequest();
            }
            
        }
        [HttpPost()]
        public IActionResult CriarUsuario(CadastrarUsuarioDTO usuarioDto)
        {
            try
            {
                _logger.LogInformation("Executando método CriarUsuario");
                _usuarioService.CriarUsuario(usuarioDto);
                var mensagem = $"Usuário criado com sucesso! | Nome: {usuarioDto.Nome}";
                _logger.LogInformation("mensagem");
                return Ok(mensagem);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"{DateTime.Now} - Exception Forçada: {ex.Message}");
                return BadRequest();
            }
        }
        [HttpPut()]
        public IActionResult AlterarUsuario(AlterarUsuarioDTO usuarioDto)
        {
            try
            {
                _logger.LogInformation("Executando método AlterarUsuario");
                _usuarioService.AlterarUsuario(usuarioDto);
                var mensagem = $"Usuário alterado com sucesso! | Nome: {usuarioDto.Nome}";
                _logger.LogInformation(mensagem);
                return Ok(mensagem);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"{DateTime.Now} - Exception Forçada: {ex.Message}");
                return BadRequest();
            }

        }
        [HttpDelete("{id}")]
        public IActionResult DeletarUsuario(int id)
        {
            try
            {
                _logger.LogInformation("Executando método DeletarUsuario");
                _usuarioService.DeletarUsuario(id);
                var mensagem = $"Usuário deletado com sucesso! | Id: {id}";
                _logger.LogInformation(mensagem);
                return Ok(mensagem);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"{DateTime.Now} - Exception Forçada: {ex.Message}");
                return BadRequest();
            }
        }
    }
}
