using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using dotnetThree.Models;
using dotnetThree.Models.AccountViewModels;

namespace dotnetThree.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<dotnetThree.Models.Article> Article { get; set; }
        public DbSet<dotnetThree.Models.Comment> Comment { get; set; }


    
    }
}
