using Layers_DI_Identity.Models;
using Layers_DI_Identity.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Data;
using System.Security.Claims;

namespace Layers_DI_Identity.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public UserController(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
        }
        
        public IActionResult Index()
        {
            List<ApplicationUser> users = userManager.Users.ToList();
            List<RegistrationVM> usersDisplay = new List<RegistrationVM>();
            foreach(var item in users)
            {
                usersDisplay.Add(new RegistrationVM()
                {
                    UserName = item.UserName,
                    Email = item.Email,
                    PhoneNumber = item.PhoneNumber,
                    RegisterDate = item.RegisterDate,
                    Address = item.Address,
                    Age = item.Age,
                });
            }
            return View(usersDisplay);
        }

        public async Task<IActionResult> Profile()
        {
           bool isAuthenticated =  User.Identity.IsAuthenticated;
            string userName = User.Identity.Name;
            bool isInRole = User.IsInRole("Admin");
            string id = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value;
            string role = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role).Value;
            string Address = User.Claims.FirstOrDefault(c => c.Type == "Address").Value;
            string Age = User.Claims.FirstOrDefault(c => c.Type == "Age").Value;
            ApplicationUser user = await userManager.FindByIdAsync(id);
            return View(user);
        }
        [AllowAnonymous]
        [HttpGet]
        public IActionResult Registration()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Registration(RegistrationVM registrationVM)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser user = new()
                {
                    UserName = registrationVM.UserName,
                    Email = registrationVM.Email,
                    PhoneNumber = registrationVM.PhoneNumber,
                    RegisterDate = registrationVM.RegisterDate,
                    Address = registrationVM.Address,
                    Age = registrationVM.Age,
                };
                IdentityResult result = await userManager.CreateAsync(user, registrationVM.Password);
                if (result.Succeeded)
                {
                    return RedirectToAction(nameof(Index));
                }
                foreach(var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return View(registrationVM);
            }
            return View(registrationVM);
        }

        [Authorize(Roles ="Admin")]
        [HttpGet]
        public IActionResult AddUserToRole()
        {
            UserToRoleVM userRole = new()
            {
                Users = new SelectList(userManager.Users.ToList(),"Id",nameof(ApplicationUser.UserName)),
                Roles = new SelectList(roleManager.Roles.ToList(),"Name","Name")
            };
            return View(userRole);
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
       public async Task<IActionResult> AddUserToRole(UserToRoleVM userToRole)
        {
            ApplicationUser user = await userManager.FindByIdAsync(userToRole.UserId);
            IdentityResult result = await userManager.AddToRoleAsync(user, userToRole.RoleName);
            if (result.Succeeded)
            {
                return RedirectToAction(nameof(Index));
            }
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }
            userToRole.Users = new SelectList(userManager.Users, "Id", "UserName");
            userToRole.Roles = new SelectList(roleManager.Roles, "Name", "Name");
            return View();
        }
    }
}
