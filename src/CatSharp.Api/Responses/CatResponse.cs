using System;
using Microsoft.AspNetCore.Mvc;

using CatSharp.Services.Dtos;

namespace CatSharp.Api.Responses
{
    public class CatResponse : ObjectResult
    {
        public CatResponse(object o) : base(o)
        {
            if(!(o is null)){
                this.Value = o;
                this.StatusCode = 200;
            }else{
                this.Value = "Error";
                this.StatusCode = 418;
            }
        }
    }
}