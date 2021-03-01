using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CS.Api.Facade.Models.Home
{
    public class Home
    {
        public class UserProfileModel
        {
            [Required]
            [Display(Name = "User Name")]
            public string UserName { get; set; }
            [Required]
            [Display(Name = "Password")]
            public string Password { get; set; }
            [Display(Name = "Remember Me")]
            public bool RememberMe { get; set; }
        }

        public class CustomSerializeModel
        {
            public int UserId { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public int RoleId { get; set; }
            public string RoleName { get; set; }

        }
    }
}