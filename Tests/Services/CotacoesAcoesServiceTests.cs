using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting.Logging;
using Moq;
using TechChallengeFiap.Application.DTOs;
using TechChallengeFiap.Application.Interfaces;
using TechChallengeFiap.Application.Services;
using TechChallengeFiap.Domain.Entities;
using TechChallengeFiap.Domain.Interfaces;

namespace Tests.Services;

[TestClass]
public sealed class CotacoesAcoesServiceTests
{
    private Mock<ILogger<CotacoesAcoesService>> _logger;
    private Mock<IApiExternaFinanceIntegration> _apiExternalFinanceIntegrationMock;

    [TestInitialize]
    public void Setup()
    {
        _logger = new Mock<ILogger<CotacoesAcoesService>>();
        _apiExternalFinanceIntegrationMock = new Mock<IApiExternaFinanceIntegration>();
    }

    public CotacoesAcoesService CreateServiceInstance()
    {
        return new CotacoesAcoesService(
            logger: _logger.Object,
            apiExternaFinanceIntegration: _apiExternalFinanceIntegrationMock.Object);
    }

    [TestMethod]
    public async Task GetCotacoes_ShoudReturnNotNull()
    {
        var cotacao = "teste";

        var service = CreateServiceInstance();
        var response = service.GetCotacao(cotacao);

        Assert.IsNotNull(response);
    }

    [TestMethod]
    public async Task GetTop10Cotacoes_ShoudReturnNotNull()
    {
        var cotacao = "teste cotacoes";

        var service = CreateServiceInstance();
        var response = service.GetTop10SubidasEDecidas();

        Assert.IsNotNull(response);
    }

}
