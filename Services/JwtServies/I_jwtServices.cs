namespace baby_shop_backend.Services.JwtServies
{
    public interface I_jwtServices
    {
        int GetUserId(string token);
    }
}
