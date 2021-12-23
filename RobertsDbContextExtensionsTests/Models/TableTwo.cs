using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RobertsDbContextExtensionsTests.Models
{
    public class TableTwo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int TwoId { get; set; }
        public int OneId { get; set;}
        public string FieldOne { get; set; }
    }
}
