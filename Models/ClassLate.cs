using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
namespace PhatT1808A.Models
{
    public class ClassLate
    {
        [Key]
        public int StudentId { get; set; }
        public int Type { get; set; }
        public double Price { get; set; }
        public long Date { get; set; }
        public ClassLate()
        {
            Date = DateTime.Now.Millisecond;
        }
    }
    
}