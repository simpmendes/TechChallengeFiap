namespace TechChallengeFiap.Application.Interfaces
{
    public interface ICotacoesAcoesService
    {
        Task<string> GetCotacao(string simbolo, int idUsuario);
        Task<string> GetTop10SubidasEDecidas(int idUsuario);

    }
}
