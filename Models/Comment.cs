using System;
using System.ComponentModel.DataAnnotations;

namespace dotnetThree.Models
{
    public class Comment
    {
        public int Id { get; set; }

        [StringLength(30, MinimumLength = 2)]
        [Required]
        public string Title { get; set; }

        [Display(Name = "Created Date")]
        [DataType(DataType.Date)]
        public DateTime CreatedAt { get; set; }
        
        // [StringLength(1024, MinimumLength = 3)]
        [Required]
        // [MinLength(3)]
        public string Content { get; set; }
        
        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Please enter valid integer Number")]
        public int Article_Id{get; set;}
    }
}