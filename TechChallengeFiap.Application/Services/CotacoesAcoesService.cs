using Microsoft.Extensions.Logging;
using TechChallengeFiap.Application.Interfaces;
using TechChallengeFiap.Domain.Interfaces;

namespace TechChallengeFiap.Application.Services
{
    public class CotacoesAcoesService: ICotacoesAcoesService
    {
        private readonly ILogger<CotacoesAcoesService> _logger;
        private readonly HttpClient _httpClient;
        private readonly IApiExternaFinanceIntegration _apiExternaFinanceIntegration;

        public CotacoesAcoesService(ILogger<CotacoesAcoesService> logger,
                                    IApiExternaFinanceIntegration apiExternaFinanceIntegration)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _apiExternaFinanceIntegration = apiExternaFinanceIntegration;
        }
        public async Task<string> GetCotacao(string symbol)
        {
            try
            {
                
                return await _apiExternaFinanceIntegration.GetCotacaoBySimbol(symbol);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro ao buscar cotação da ação {symbol}: {ex.Message}");
                throw;
            }
        }

        public async Task<string> GetTop10SubidasEDecidas()
        {
            try
            {
                return await _apiExternaFinanceIntegration.GetTopGainerAndLosers();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro ao buscar as 10 ações que mais subiram no dia: {ex.Message}");
                throw;
            }
        }
    }
}
