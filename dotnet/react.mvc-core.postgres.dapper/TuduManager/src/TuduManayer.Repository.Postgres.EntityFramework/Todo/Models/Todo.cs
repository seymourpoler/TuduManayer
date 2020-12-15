using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TuduManayer.Repository.Postgres.EntityFramework.Todo.Models
{
    [Table("Todos")]
    public class Todo
    {
        [Key]
        [Column("id")]
        public int id { get; set; }
        
        [Required]
        [StringLength(255)]
        [Column("title")]
        public string title { get; set; }

        [StringLength(255)]
        [Column("description")]
        public string description { get; set; }
        
        [Required]
        [Column("creation_date")]
        public DateTime creation_date { get; set; }
        
        [Column("updated_date")]
        public DateTime? updated_date { get; set; }
    }
}