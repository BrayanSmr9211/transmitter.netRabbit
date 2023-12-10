using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Infrastructure.Abstract.InterfaceC
{
    public interface IUserRabbit
    {
    Task<object> UserRabbitMQ
      (
        ClaimsIdentity identity
      );
    }
}
