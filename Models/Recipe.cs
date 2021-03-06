using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PrzepisyWeb.Models
{
    public class Recipe
    {

        //dodać inta do zliczania 

        //params
        [Key]
        public int RecipeID { get; set; }
        public string Name { get; set; }
        [JsonPropertyName("img")]
        public string Image { get; set; }
        public string Ingredients { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }

        //Owner
        public ApplicationUser Owner { get; set; }

        public string OwnerUserName { get; set; }


        // polubienia i listy użytkowników którzy polublili
        public int LikeCounter { get; set; }

        [NotMapped]
        public ICollection<ApplicationUser> LikeUsers { get; set; }

        [NotMapped]
        public ICollection<ApplicationUser> DislikeUsers { get; set; }

        //Constructors

        public Recipe(string name, DateTime date, string description, string ingredients)
        {
            Name = name;
            Date = date;
            Description = description;
            Ingredients = ingredients;
        }
        public Recipe()
        { }

        public override string ToString() => JsonSerializer.Serialize<Recipe>(this);

    }
}
