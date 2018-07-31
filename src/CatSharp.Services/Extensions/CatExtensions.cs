using System;
using System.Linq;
using CatSharp.Data.Entities;
using CatSharp.Services.Dtos;


namespace CatSharp.Services.Extensions
{
    public static class CatExtensions
    {
        public static CatDto ToDto(this Cat cat)
        {
            return new CatDto(cat.CatId, cat.Name, cat.BirthDate, cat.Weights.ToDictionary(x => x.Date, x => x.Grams));
        }

        public static Cat ToEntity(this CatDto cat)
        {
            return new Cat
            {
                CatId = cat.Id,
                Name = cat.Name,
                BirthDate = cat.BirthDate,
                Weights = cat.Weights.Select(x => new Weight { Date = x.Key, Grams = x.Value }).ToList()
            };
        }
    }
}