using BuildingCore.Constant;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingCore.Data.Model
{
    public class User : IdentityUser<int>
    {
        [Required]
        [Column(TypeName = "Date")]
        public DateTime BirthDate { get; set; }
        [Required]
        public Gender Gender { get; set; }
        [Required]
        public string Address { get; set; }

        [Required]
        [MaxLength(100)]
        public string FullName { get; set; } = null!;
    }
}
