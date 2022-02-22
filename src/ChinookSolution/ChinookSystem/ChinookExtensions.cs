using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namespaces
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
#endregion

namespace ChinookSystem
{
    public static class ChinookExtensions
    {

        public static void ChinookSystemBackendDependencies(this IServiceCollection services, 
            
            Action<DbContextOptionsBuilder> options)
        {


        }
    }
}
