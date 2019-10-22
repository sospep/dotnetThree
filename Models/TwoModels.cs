using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using dotnetThree.Models.AccountViewModels;


namespace dotnetThree.Models
{
    public class ArticleComment{
        public Article Article{get; set;}
        public Comment Comment{get; set;}
        public List<Comment> comments = new List<Comment>();
        public ApplicationUser currentUser {get; set;}
    }
}