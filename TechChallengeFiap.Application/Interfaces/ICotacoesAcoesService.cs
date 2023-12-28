namespace TechChallengeFiap.Application.Interfaces
{
    public interface ICotacoesAcoesService
    {
        Task<string> GetCotacao(string simbolo);
        Task<string> GetTop10SubidasEDecidas();

    }
}
