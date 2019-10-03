using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace dotnetThree.Models
{
    public class ArticleComment{
        public Article Article{get; set;}
        public Comment Comment{get; set;}
        public List<Comment> comments = new List<Comment>();

    }
}