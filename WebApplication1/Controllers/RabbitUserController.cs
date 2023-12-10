using Domain.Infrastructure.Abstract;
using Domain.Infrastructure.Abstract.InterfaceC;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;

namespace WebApplication1.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class RabbitUserController : BaseController
    {
        private readonly ITokenJwt TokenJwt;
        private readonly IUserRabbit UserRabbit;

        public RabbitUserController (ITokenJwt tokenJwt, IUserRabbit userRabbit)
        {
            this.TokenJwt = tokenJwt;
            this.UserRabbit = userRabbit;
        }

        [Authorize]
        [HttpGet]
        public async Task<JsonResult> GetTurnAsync()
        {
            string dataJ = "";

            var Identity = HttpContext.User.Identity as ClaimsIdentity;
            var ResopneToken = TokenJwt.ValidTokenWeb(Identity);
            if (ResopneToken.Result == "Token incorrect")
            {
                return new JsonResult("Error Token" + ResopneToken.Result);
            }
            else
            {
                var GetData = await UserRabbit.UserRabbitMQ(Identity);
                return new JsonResult(GetData);
            }
        }
    }
}
