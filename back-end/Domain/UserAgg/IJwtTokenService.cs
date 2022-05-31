public interface IJwtTokenService
{
    public string GenerateJwtToken(User user);
    public Guid? ValidateJwtToken(string token);

}
