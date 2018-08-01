using System;
using System.Linq;
using System.Collections.Generic;

using CatSharp.Services.Dtos;
using CatSharp.Services.Dtos.Extensions;
using CatSharp.Data;
using CatSharp.Data.Entities;

using Microsoft.EntityFrameworkCore;

namespace CatSharp.Services
{
    public class CatService : ICatService
    {
        private readonly CatSharpContext _context;

        public CatService(CatSharpContext context)
        {
            _context = context;
            _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public IList<CatGetDto> GetAll()
        {
            return _context.Cats.Include(x => x.Weights).Select<Cat, CatGetDto>(Map).ToList();
        }

        public void Create(CatCreateDto cat)
        {
            _context.Add(Map(cat));
            _context.SaveChanges();
        }

        public void Update(CatUpdateDto cat)
        {
            _context.Update(Map(cat));
            _context.SaveChanges();
        }

        public void Delete(int catId)
        {
            _context.Cats.Remove(new Cat { CatId = catId });
            _context.SaveChanges();
        }

        private CatGetDto Map(Cat cat)
        {
            return cat.ToDto();
        }

        private Cat Map(CatCreateDto cat)
        {
            return cat.ToEntity();
        }

        private Cat Map(CatUpdateDto cat)
        {
            return cat.ToEntity();
        }
    }
}
