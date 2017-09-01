using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace alexwilkinson.Models
{
    public partial class AuthorAccess
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public string AuthAccessName { get; set; }
        public bool AuthorAbleToCreate { get; set; }
        public bool AuthorAbleToUpdate { get; set; }
        public bool AuthorAbleToDelete { get; set; }
        public bool AccessEnabled { get; set; }
    }
}
