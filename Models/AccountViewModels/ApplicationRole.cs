using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace dotnetThree.Models.AccountViewModels
{
    public class ApplicationRole : IdentityRole
    {
        public string Description{get; set;}
        
        // constructors 
        public ApplicationRole() :base() {}

        public ApplicationRole(string roleName) :base(roleName) 
        {

        }
        public ApplicationRole(string roleName, string description ) :base(roleName)
        {
            this.Description = description;   
        }
    }
}