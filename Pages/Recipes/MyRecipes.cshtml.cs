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
    public class MyRecipesModel : PageModel
    {
        private readonly PrzepisyWeb.Data.RecipeContext _context;

        public MyRecipesModel(PrzepisyWeb.Data.RecipeContext context)
        {
            _context = context;
        }

        public IList<Recipe> Recipe { get; set; }

        public async Task OnGetAsync()
        {
            Recipe = await _context.Recipes.ToListAsync();
        }
    }
}
