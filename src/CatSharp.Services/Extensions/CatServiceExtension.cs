
using System;
using System.Collections.Generic;

using CatSharp.Services.Dtos;

namespace CatSharp.Services.Extensions
{
    public static class CatServiceExt
    {
        public static IList<CatGetDto> GetAllExt(this CatService service)
        {
            return service.GetAll();
        }
    }
}
