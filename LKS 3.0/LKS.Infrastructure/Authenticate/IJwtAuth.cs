using LKS.Data.Models;

namespace LKS.Infrastructure.Authenticate
{
    public interface IJwtAuth
    {
		AuthenticateModel CreateToken(User user);

	}
}
