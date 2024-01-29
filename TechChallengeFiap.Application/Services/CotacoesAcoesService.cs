using Microsoft.Extensions.Logging;
using TechChallengeFiap.Application.Interfaces;
using TechChallengeFiap.Domain.Entities;
using TechChallengeFiap.Domain.Interfaces;

namespace TechChallengeFiap.Application.Services
{
    public class CotacoesAcoesService: ICotacoesAcoesService
    {
        private readonly ILogger<CotacoesAcoesService> _logger;
        private readonly IApiExternaFinanceIntegration _apiExternaFinanceIntegration;
        private IConsultaAcoesRepository _consultaAcoesRepository;
        private IUsuarioRepository _usuarioRepository;

        public CotacoesAcoesService(ILogger<CotacoesAcoesService> logger,
                                    IApiExternaFinanceIntegration apiExternaFinanceIntegration,
                                    IConsultaAcoesRepository consultaAcoesRepository,
                                    IUsuarioRepository usuarioRepository)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _apiExternaFinanceIntegration = apiExternaFinanceIntegration;
            _consultaAcoesRepository = consultaAcoesRepository;
            _usuarioRepository = usuarioRepository;
        }
        public async Task<string> GetCotacao(string symbol, int idUsuario)
        {
            try
            {
                CadastrarConsulta(symbol, idUsuario);

                return await _apiExternaFinanceIntegration.GetCotacaoBySimbol(symbol);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro ao buscar cotação da ação {symbol}: {ex.Message}");
                throw;
            }
        }

        

        public async Task<string> GetTop10SubidasEDecidas(int idUsuario)
        {
            try
            {
                CadastrarConsulta("Top10", idUsuario);
                return await _apiExternaFinanceIntegration.GetTopGainerAndLosers();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro ao buscar as 10 ações que mais subiram no dia: {ex.Message}");
                throw;
            }
        }
        private void CadastrarConsulta(string symbol, int idUsuario)
        {
            var usuarioCadastrado = _usuarioRepository.ObterPorId(idUsuario);
            var consulta = new ConsultaAcoes(symbol, usuarioCadastrado);
            _consultaAcoesRepository.Cadastrar(consulta);
        }
    }
}
