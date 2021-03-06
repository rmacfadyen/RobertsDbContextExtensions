using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuickDirtyBenchmark.Models
{
    public class TableOne
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int OneId { get; set; }

        public byte byte1 { get; set; }
        public sbyte sbyte1 { get; set; }
        public short short1 { get; set; }
        public short ushort1 { get; set; } // dapper can't handle ushort
        public int int1 { get; set; }
        public int uint1 { get; set; } // dapper can't handle uint?
        public long long1 { get; set; }
        public ulong ulong1 { get; set; }
        public float float1 { get; set; }
        public double double1 { get; set; }
        
        [Column(TypeName = "decimal(18,4)")] 
        public decimal decimal1 { get; set; }
        public bool bool1 { get; set; }
        
        [MaxLength(128)] 
        public string string1 { get; set; }
        
        public char char1 { get; set; }
        public Guid guid1 { get; set; }
        public DateTime datetime1 { get; set; }
        public DateTimeOffset datetimeoffset1 { get; set; }
        
        [Column(TypeName = "timestamp")]
        public byte[] bytearray1 { get; set; }
    }
}
