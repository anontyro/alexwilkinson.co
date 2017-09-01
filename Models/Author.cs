using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace websites
{
    public partial class Author
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public int AuthorActive { get; set; }
        [ForeignKey("AuthorAccess")]
        public int AuthorAccess { get; set; }
        [Required]
        public string AuthorEmail { get; set; }
        public string AuthorFirstname { get; set; }
        public string AuthorLastname { get; set; }
        [Required]
        public string AuthorPassword { get; set; }
        public string AuthorUsername { get; set; }
    }
}
