using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TuduManayer.Repository.Postgres.EntityFramework.User.Models
{
    [Table("Users")]
    public class User
    {
        [Key]
        [Column("id")]
        public int id { get; set; }
        
        [Required]
        [StringLength(255)]
        [Column("email")]
        public string email { get; set; }

        [StringLength(255)]
        [Column("password")]
        public string password { get; set; }
        
        [Required]
        [Column("creation_date")]
        public DateTime creation_date { get; set; }
        
        [Column("updated_date")]
        public DateTime? updated_date { get; set; }
    }
}