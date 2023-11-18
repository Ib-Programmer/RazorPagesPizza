using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MessagePack;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesPizza.Data;
using RazorPagesPizza.Models;

namespace RazorPagesPizza.Pages
{
    public class PizzaListModel : PageModel
    {
        private readonly RazorPagesPizza.Data.RazorPagesPizzaContext _context;

        public PizzaListModel(RazorPagesPizza.Data.RazorPagesPizzaContext context)
        {
            _context = context;
        }

        public IList<Pizza> PizzaList { get; set; } = default!;

        [BindProperty]
        public Pizza NewPizza {  get; set; } = new Pizza();
        public async Task  OnGetAsync()
        {
            if (_context.Pizza != null)
            {
                PizzaList = await _context.Pizza.ToListAsync();
            }
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || NewPizza == null)
            {
                return Page();
            }
                _context.Add(NewPizza);
                await _context.SaveChangesAsync();
                return RedirectToAction("Get");
         }
        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            var pizzaToDelete = await _context.Pizza.FindAsync(id);
            if(pizzaToDelete != null)
            {
                _context.Remove(pizzaToDelete);
                await _context.SaveChangesAsync();
            }  
          return RedirectToAction("Get");
        }
    }
}