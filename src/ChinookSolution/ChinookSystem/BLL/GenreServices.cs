using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



#region Additional Namespaces
using ChinookSystem.ViewModels;
using ChinookSystem.Entities;
using ChinookSystem.BLL;
using ChinookSystem.DAL;
#endregion
namespace ChinookSystem.BLL
{


    public class GenreServices
    {
        #region Constructor and Context Dependency
        private readonly ChinookContext _context;

        //obtain the context link from IServiceCollection when this
        //  set of service is injected into the "outside user"
        internal GenreServices(ChinookContext context)
        {
            _context = context;
        }

        #endregion
        #region Services: Queries
        //obtain a list of Genres to used in a select list

        public List<SelectionList> GetAllGenres()
        {
            IEnumerable<SelectionList> info = _context.Genres
                                        .Select(g => new SelectionList
                                        {
                                            ValueId = g.GenreId,
                                            DisplayText=g.Name
                                        });
            //OrderBy(g=> g.DisplayText); this sort is in sql
         return info.ToList();
            //return info.OrderBy(g => g.DisplayText).ToList();  this sort is in RAM

        }
        #endregion
    }
}
