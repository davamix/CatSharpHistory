using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace CatSharp.Data.Entities{
    [Table("weights")]
    public class Weight{
        public int WeightId{get;set;}
        public DateTime Date{get;set;}
        public int Grams{get;set;}

        public int CatId{get;set;}
        public Cat Cat{get;set;}
    }
}