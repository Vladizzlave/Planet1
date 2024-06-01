using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.IdentityModel.Tokens;
using System.Collections.Generic;
using Планеты.Data.ApplicationDbContext;
using Планеты.Model;

namespace Планеты.Pages
{
    public class IndexModel : PageModel
    {
        public List<Planet> Planets { get; set; }
        public IndexModel(ApplicationDbContext context) 
        {
            _context = context;
        }
        private ApplicationDbContext _context;

        public void OnGet()
        {
            Planets = _context.Planets.ToList();
          /*  Planets = new List<Planet>
{
new  Planet { Id = 1, Name = "Mercury", Description = "The smallest planet", Diameter = 4879, DistanceFromSun = 57.9 },
new Planet { Id = 2, Name = "Venus", Description = "The second planet from the Sun", Diameter = 12104, DistanceFromSun = 108.2 },
new Planet { Id = 3, Name = "Earth", Description = "Our home planet", Diameter = 12742, DistanceFromSun = 149.6 },
new Planet { Id = 4, Name = "Mars", Description = "The Red Planet", Diameter = 6779, DistanceFromSun = 227.9 },
new Planet { Id = 5, Name = "Jupiter", Description = "The largest planet", Diameter = 139820, DistanceFromSun = 778.3 },
new Planet { Id = 6, Name = "Saturn", Description = "Known for its rings", Diameter = 116460, DistanceFromSun = 1427 },
new Planet { Id = 7, Name = "Uranus", Description = "An ice giant", Diameter = 50724, DistanceFromSun = 2871 },
new Planet { Id = 8, Name = "Neptune", Description = "The farthest planet from the Sun", Diameter = 49244, DistanceFromSun = 4495 }
};
          */
        }
    }
}
