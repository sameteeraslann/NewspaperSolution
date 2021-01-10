using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NewspaperSolution.UI.Areas.Admin.Data.DTOs
{
    public class CategoryDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Boş geçmeyiniz...!")]
        public string Name { get; set; }
    }
}