
#nullable disable
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

#region Additional Namespaces
using ChinookSystem.BLL;
using ChinookSystem.ViewModels;

#endregion
namespace WebApp.Pages.SamplePages
{
    public class AlbumByGenreQueryModel : PageModel
    {

        #region Private Variable & DI Constructor

        private readonly ILogger<IndexModel> _logger;
        private readonly AlbumServices _albumServices;
       
        private readonly GenreServices _genreServices;
     

        public AlbumByGenreQueryModel(ILogger<IndexModel> logger,

            AlbumServices albumservices,
            GenreServices genreservices)
        {
            _logger = logger;
            _albumServices = albumservices;
            _genreServices = genreservices;
        }
        #endregion

        #region FeedBack and ErrorHandling
        [TempData]

        public string FeedBack { get; set; }
        public bool HasFeedBack => !string.IsNullOrWhiteSpace(FeedBack);

        [TempData]
        public string ErrorMessage { get; set; }
        
        public bool HasErrorMessage => !string.IsNullOrWhiteSpace(ErrorMessage);
        
        #endregion
        [BindProperty]
        public List<SelectionList> GenreList { get; set; }
        public void OnGet()
        {
            GenreList = _genreServices.GetAllGenres();
        }
    }
}
