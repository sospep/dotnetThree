using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace dotnetThree.Models.AccountViewModels
{
    public class ApplicationUser : IdentityUser
    {
        public string NameFirst{get; set;}
        public string NameLast{get; set;}
        public string Telephone {get; set;}


    }
}