using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace TuduManayer.Repository.Postgres.EntityFramework
{
    [Table("todos")]
    public class Todo
    {
        public int id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public DateTime creation_date { get; set; }
        public DateTime? updated_date { get; set; }
    }
    
}