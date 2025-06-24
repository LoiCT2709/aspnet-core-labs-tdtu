using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Bai3.Models
{
    public class Student
    {
        public string? Name { get; set; }
        [EmailAddress]
        public string? Email { get; set; }
        public string? Country {  get; set; }

        public List<SelectListItem> Countries { get; } = new List<SelectListItem>
        {
            new SelectListItem { Value = "DE", Text = "Germany" },
            new SelectListItem { Value = "US", Text = "USA" },
            new SelectListItem {Value = "FR", Text = "France" },
        };
    }
}
