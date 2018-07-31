using System;
using System.Collections.Generic;

namespace CatSharp.Services.Dtos
{
    public class CatUpdateDto
    {
        public int Id{get;}
        public string Name { get; }
        public DateTime BirthDate { get; }
        public Dictionary<DateTime, int> Weights { get; }

        public CatUpdateDto(int id, string name, DateTime birthDate, Dictionary<DateTime, int> weights)
        {
            Id = id;
            Name = name;
            BirthDate = birthDate;
            if(weights == null)
                Weights = new Dictionary<DateTime, int>();
            else
                Weights = weights;
        }
    }
}