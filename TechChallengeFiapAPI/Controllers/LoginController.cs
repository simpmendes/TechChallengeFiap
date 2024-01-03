using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TechChallengeFiap.Application.DTOs;
using TechChallengeFiap.Domain.Entities;
using TechChallengeFiap.Domain.Enums;
using TechChallengeFiap.Domain.Interfaces;

namespace TechChallengeFiapAPI.Controllers
{
    [ApiController]
    [Route("login")]
    public class LoginController: ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly ITokenService _tokenService;

        public LoginController(IUsuarioRepository usuarioRepository, ITokenService tokenService)
        {
            _usuarioRepository = usuarioRepository;
            _tokenService = tokenService;
        }
        [HttpPost]
        public async Task<IActionResult> Autenticar([FromBody] LoginDTO usuarioDto)
        {
            var usuario = await _usuarioRepository.ObterPorNomeUsuarioESenha(
                usuarioDto.NomeUsuario, usuarioDto.Senha);

            if (usuario == null)
                return NotFound(new { mensagem = "Usuario ou senha inválidos" });

            var token = _tokenService.GetToken(usuario);

            usuario.Senha = null;

            return Ok(new
            {
                Usuario = usuario,
                Token = token
            });
        }
    }
}
