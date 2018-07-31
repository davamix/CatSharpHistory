using System;
using System.Linq;
using System.Collections.Generic;

using CatSharp.Services.Dtos;
using CatSharp.Data;
using CatSharp.Data.Entities;
using CatSharp.Services.Extensions;
using Microsoft.EntityFrameworkCore;

namespace CatSharp.Services
{
    public class CatService : ICatService
    {
        private readonly CatSharpContext _context;

        public CatService(CatSharpContext context)
        {
            _context = context;
        }
        
        public IList<CatDto> GetAll()
        {
            return _context.Cats.Include(x => x.Weights).Select<Cat, CatDto>(Map).ToList();
        }
        

        public void Save(CatDto cat)
        {
            _context.Cats.Add(Map(cat));
            _context.SaveChanges();
        }

        private CatDto Map(Cat cat)
        {
            return cat.ToDto();
        }

        private Cat Map(CatDto cat){
            return cat.ToEntity();
        }
    }
}
