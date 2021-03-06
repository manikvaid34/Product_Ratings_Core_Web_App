﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Product_Ratings_Core_Web_App.Models;
using Product_Ratings_MVC.Models;

namespace Product_Ratings_Core_Web_App.Pages.Products
{
    //creates a product
    public class CreateModel : PageModel
    {
        private readonly Product_Ratings_Core_Web_App.Models.Product_Ratings_Core_Web_AppDataContext _context;

        public CreateModel(Product_Ratings_Core_Web_App.Models.Product_Ratings_Core_Web_AppDataContext context)
        {
            _context = context;
        }

        //Gets the product create form.
        public IActionResult OnGet()
        {
            return Page();
        }

        //Binds the product model.
        [BindProperty]
        public Product Product { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        //Creates a product.
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Product.Add(Product);
             _context.SaveChanges();

            return RedirectToPage("./Index");
        }
    }
}
