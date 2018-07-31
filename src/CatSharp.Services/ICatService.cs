using System;
using System.Collections.Generic;

using CatSharp.Services.Dtos;

namespace CatSharp.Services{
    public interface ICatService{
        IList<CatGetDto> GetAll();
        void Create(CatCreateDto cat);
        void Update(CatUpdateDto cat);
        void Delete(int catId);
        // void Save(CatDto cat);
    }
}