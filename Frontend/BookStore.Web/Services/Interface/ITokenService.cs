namespace BookStore.Web.Services.Interface
{
    public interface ITokenService
    {
        void SetToken(string token);
        string? GetToken();
        void ClearToken();
    }
}
