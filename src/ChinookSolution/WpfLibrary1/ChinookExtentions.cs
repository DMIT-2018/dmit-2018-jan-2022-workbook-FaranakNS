using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namespaces
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace WpfLibrary1
{
    public class ChinookExtentions
    {
        public static void ChinookSystemBackendDependencies(this IServiceCollection services,
            Action<DbContectOptionsBuilder> options)
        {
            services.AddDbContext<ChinookContext>(options);

        }
    }
}
