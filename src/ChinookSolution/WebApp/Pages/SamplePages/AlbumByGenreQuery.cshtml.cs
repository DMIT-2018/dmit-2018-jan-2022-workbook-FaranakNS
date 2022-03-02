
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

        [BindProperty(SupportsGet =true)]
        public int? GenreId { get; set; }

        [BindProperty]
        public List<AlbumsListBy> AlbumsByGenre { get; set; }


        public void OnGet()
        {
            //OnGet is executed as the page first is proceed (as it comes up)

            //consume a service: GetAllGenres in register services of _genreServices
            GenreList = _genreServices.GetAllGenres();

            //sort the List<T> using the method .sort
            GenreList.Sort((x,y) => x.DisplayText.CompareTo(y.DisplayText));


            //remember that this method execute as the page FIRST come up before
            // anyting has happened on the page (including first display)
            // any code ub this method MUST handle the possibilty of missing data for the query arguement


            if(GenreId.HasValue && GenreId.Value > 0)
            {
                
            AlbumsByGenre = _albumServices.AlbumsByGenre((int)GenreId);
            }


        }

        public IActionResult OnPost()
        {
            if(GenreId==0)
            {
                //propmt line test
                FeedBack = "You did not select a genre";
            }
            else
            {
                FeedBack = $"You select genre id of {GenreId}";
            }
            return RedirectToPage(new {GenreId=GenreId}); //cause a get request which forces OnGet execution
        }
    }
}
