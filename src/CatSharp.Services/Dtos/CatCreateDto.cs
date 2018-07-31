using System;
using System.Collections.Generic;

namespace CatSharp.Services.Dtos
{
    public class CatCreateDto
    {
        public string Name { get; }
        public DateTime BirthDate { get; }
        public Dictionary<DateTime, int> Weights { get; }

        public CatCreateDto(string name, DateTime birthDate, Dictionary<DateTime, int> weights)
        {
            Name = name;
            BirthDate = birthDate;
            if(weights == null)
                Weights = new Dictionary<DateTime, int>();
            else
                Weights = weights;
        }
    }
}