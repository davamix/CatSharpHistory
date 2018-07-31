using System;
using System.Collections.Generic;

using CatSharp.Services.Dtos;

namespace CatSharp.Services{
    public interface ICatService{
        IList<CatDto> GetAll();
    }
}