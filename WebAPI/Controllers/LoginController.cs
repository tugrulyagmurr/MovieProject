using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Index(string returnUrl = "")
        {
            await HttpContext.SignOutAsync();

            return Challenge(new AuthenticationProperties { RedirectUri = returnUrl });
        }
    }
}
