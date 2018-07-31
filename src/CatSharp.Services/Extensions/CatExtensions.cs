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
    }
}