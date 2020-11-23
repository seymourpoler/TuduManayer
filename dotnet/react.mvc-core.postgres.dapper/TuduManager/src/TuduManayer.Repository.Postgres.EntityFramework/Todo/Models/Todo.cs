using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TuduManayer.Repository.Postgres.EntityFramework.Todo.Models
{
    [Table("todos")]
    public class Todo
    {
        [Key]
        public int id { get; set; }
        
        [Required]
        [StringLength(255)]
        public string title { get; set; }

        [StringLength(255)]
        public string description { get; set; }
        
        [Required]
        public DateTime creation_date { get; set; }
        
        public DateTime? updated_date { get; set; }
    }
}