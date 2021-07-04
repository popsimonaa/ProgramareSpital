using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProgramareSpital.Models;
using ProgramareSpital.Models.ViewModels;
using ProgramareSpital.Utility;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProgramareSpital.Controllers
{
    public class ContUtilizatorController : Controller
    {
        private readonly ApplicationDbContext _db; //adaugarea utilizatorilor in bd.
        //build-in methods from Identity. (helper method)
        UserManager<ApplicationUser> _userManager;
        SignInManager<ApplicationUser> _signInManager;
        RoleManager<IdentityRole> _roleManager;

        //creez dependency injection pentru ceea ce am definit mai sus;
        public ContUtilizatorController (ApplicationDbContext db, UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager, SignInManager<ApplicationUser> signInManager)
        {
            _db = db;
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
        }
       
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false); //helper method
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Programare");
                }
                ModelState.AddModelError("", "Cererea de conectare este invalida!");
            }
            return View(model);
        }
        public async Task<IActionResult> Register()
        {
            if (!_roleManager.RoleExistsAsync(Helper.Admin).GetAwaiter().GetResult())
            {  //pentru a-mi crea rolurile in bd
               await _roleManager.CreateAsync(new IdentityRole(Helper.Admin));
               await _roleManager.CreateAsync(new IdentityRole(Helper.Pacient));
               await  _roleManager.CreateAsync(new IdentityRole(Helper.Medic));
            }
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task< IActionResult> Register(RegisterViewModel model)
        {
            if(ModelState.IsValid)
            {
                var user = new ApplicationUser
                {
                    UserName = model.Email,
                    Email = model.Email,
                    Name = model.Name
                }; //pt a popula bd
                var result = await _userManager.CreateAsync(user, model.Password); //helper methods
                if (result.Succeeded)
                {    
                    //logare automata, dupa crearea contului
                    await _userManager.AddToRoleAsync(user, model.RoleName);
                    await _signInManager.SignInAsync(user, isPersistent: false); 

                    return RedirectToAction("Index", "Home");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> LogOff()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
