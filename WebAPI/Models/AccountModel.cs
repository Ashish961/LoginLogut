using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class AccountModel
    {
        [Key]
        public int userId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string password { get; set; }
        public string FirstName { get; internal set; }
    }
}