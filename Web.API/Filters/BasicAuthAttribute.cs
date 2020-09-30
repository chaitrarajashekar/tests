using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.API.Filters
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class BasicAuthAttribute : Microsoft.AspNetCore.Mvc.TypeFilterAttribute
    {
        public BasicAuthAttribute() : base(typeof(BasicAuthFilter))
        {
            Arguments = new object[] { };
        }
    }
}
