using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code.Domain.Entities
{
    public class Usermodel
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        [ValidateNever]
        public string EmailAddress { get; set; }
        [ValidateNever]
        public string Role { get; set; }
        [ValidateNever]
        public int UserId { get; set; }
        [ValidateNever]
        public DateTime DateofJoining { get; set; }
        [ValidateNever]
        public string Status { get; set; }
    }
}
