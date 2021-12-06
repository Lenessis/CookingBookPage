using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PrzepisyWeb.Data;
using PrzepisyWeb.Models;

namespace PrzepisyWeb.Pages.Recipes
{
    public class UserPageModel : PageModel
    {
        private readonly PrzepisyWeb.Data.RecipeContext _context;


        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public UserPageModel(PrzepisyWeb.Data.RecipeContext context, SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [BindProperty]
        public Recipe Recipe { get; set; }

        public string UsernameDisplay { get; set; }

        public IList<Recipe> RecipeList { get;set; }

        public IActionResult OnGet(string UserName)
        {
            UsernameDisplay = UserName;

            var UserList = from X in _context.Recipes where X.OwnerUserName == UserName select X;

            RecipeList = UserList.ToList();
            return Page();
        }

        public ActionResult OnPostAsync(int Like, string UserName)
        {

            if (ModelState.IsValid)
            {
                UsernameDisplay = UserName;
                var UserList = from X in _context.Recipes where X.OwnerUserName == UserName select X;


                RecipeList = UserList.ToList();

            }
            return Page();
        }
    }
}
