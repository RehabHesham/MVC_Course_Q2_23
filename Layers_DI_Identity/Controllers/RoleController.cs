using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Layers_DI_Identity.Controllers
{
    [Authorize(Roles ="Admin")]
    public class RoleController : Controller
    {
        private readonly RoleManager<IdentityRole> roleManager;

        public RoleController(RoleManager<IdentityRole> roleManager)
        {
            this.roleManager = roleManager;
        }
        public IActionResult Index()
        {
            List<IdentityRole> roles = roleManager.Roles.ToList();
            return View(roles);
        }

        [HttpGet]
        public IActionResult Add() {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(string? Name) {
            if (Name == null) {
                ModelState.AddModelError("Name", "Name is required");
                return View(); 
            }
            IdentityRole role = new IdentityRole(Name);
           IdentityResult result =  await roleManager.CreateAsync(role);
            if (result.Succeeded)
            {
                return RedirectToAction(nameof(Index));
            }
            foreach(var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }
            return View();
        }
    }
}
