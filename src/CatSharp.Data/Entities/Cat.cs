using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CatSharp.Data.Entities
{
    [Table("cats")]
    public class Cat
    {
        public int CatId{get;set;}
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public List<Weight> Weights { get; set; }
    }
}