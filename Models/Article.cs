using System;
using System.ComponentModel.DataAnnotations;

namespace dotnetThree.Models
{
    public class Article
    {
        public int Id { get; set; }

        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string Title { get; set; }
        
        [Display(Name = "Created Date")]
        [DataType(DataType.Date)]
        public DateTime CreatedAt { get; set; }
        
        [StringLength(1024, MinimumLength = 3)]
        [Required]
        public string Content { get; set; }
        
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }
    }
}