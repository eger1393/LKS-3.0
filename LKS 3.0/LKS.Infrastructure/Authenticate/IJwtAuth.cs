namespace LKS.Infrastructure.Authenticate
{
    public interface IJwtAuth
    {
		AuthenticateModel CreateToken(string id, string role);

	}
}
