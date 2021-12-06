using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PrzepisyWeb.Models;


namespace PrzepisyWeb.Pages
{
    public class RecipiesModel : PageModel
    {
        private readonly PrzepisyWeb.Data.RecipeContext _context;

        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public RecipiesModel(PrzepisyWeb.Data.RecipeContext context, SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _signInManager = signInManager;
            _userManager = userManager;
        }


        //foricz ()

        [BindProperty]
        public Recipe Recipe { get; set; }

        [BindProperty]
        public string SearchString { get; set; }

        public IList<Recipe> SearchList { get; set; }


        public int CategoriesID { get; set; }

        public int CategoryRecipeID { get; set; }

        public List<Recipe> SearchCategegoryRecipe { get; set; }

        public  IActionResult OnGet()
        {
            var GetFullList = from X in _context.Recipes orderby X.Date descending select X;

            SearchList =  GetFullList.ToList();

            return Page();
        }

        
        public ActionResult OnPostAsync(int Like)
        {

            if (ModelState.IsValid)
            {

                if (SearchString != "" && SearchString != null)
                {
                    var SearchQuery = from X in _context.Recipes
                                      where (X.Name.Contains(SearchString) ||
                                      X.Owner.UserName.Contains(SearchString) ||
                                      X.Ingredients.Contains(SearchString) ||
                                      X.Description.Contains(SearchString))
                                      orderby X.Date descending
                                      select X;

                    SearchList = SearchQuery.ToList();
                }
                else
                {
                    var GetFullList = from X in _context.Recipes select X;
                    SearchList = GetFullList.ToList();
                }

            }
            return Page();
        }  
    }

}
