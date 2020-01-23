using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EcommerceProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EcommerceProject
{
    public class CreateModel : PageModel
    {
        [BindProperty]
        public Models.Type Type { get; set; }


        public string Message { get; set; }
        public string Error { get; set; }

        public void OnGet()
        {
        }
        public void OnPost()
        {
            var db = new TestEcommerceContext();

            if (db.Type.Any(m=>m.Name== Type.Name))
            {
                Error= $"{Type.Name} already exists.";
            }
            else
            {
                db.Type.Add(Type);
                db.SaveChanges();

                Message = $"{Type.Name} saved successfully";

                Type = null;
                ModelState.Clear();
            }


        }
    }
}