using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LKS.Infrastructure.Authenticate
{
    public class AuthenticateModel
    {
        public string Name { get; set; }

        public string Token { get; set; }

		public string Role { get; set; }

		public string TroopId { get; set; }
    }
}
