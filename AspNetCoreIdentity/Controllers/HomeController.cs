using AspNetCoreIdentity.Extensions;
using AspNetCoreIdentity.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreIdentity.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }
        
        public IActionResult Privacy()
        {
            throw new Exception("Error");
            
            return View();
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Secret()
        {
            return View();
        }

        [Authorize(Policy = "CanDelete")]
        public IActionResult SecretClaim()
        {
            return View("Secret");
        }

        [Authorize(Policy = "CanWrite")]
        public IActionResult SecretClaimWrite()
        {
            return View("Secret");
        }

        [ClaimsAuthorizeAttribute("Products", "Read")]
        public IActionResult ClaimsCustom()
        {
            return View("Secret");
        }

        [Route("error/{id:length(3,3)}")]
        public IActionResult Error(int id)
        {
            var modelError = new ErrorViewModel();

            if (id == 500)
            {
                modelError.Message = "Occurred an error! Try again later or contact our suport.";
                modelError.Title = "Occured an error!";
                modelError.ErrorCode = id;
            }

            else if (id == 404)
            {
                modelError.Message = "The page that you search not exist! <br />In case doubt contact our support.";
                modelError.Title = "Ops! Page not found.";
                modelError.ErrorCode = id;
            }

            else if (id == 403)
            {
                modelError.Message = "You haven't permission for to do it.";
                modelError.Title = "Access denied.";
                modelError.ErrorCode = id;
            }
            else
            {
                return StatusCode(404);
            }

            return View("Error", modelError);
        }
    }
}
