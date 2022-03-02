
#nullable disable
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

#region Additional Namespaces
using ChinookSystem.BLL;
using ChinookSystem.ViewModels;
using WebApp.Helpers;  //contains the class Paginator

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

        #region Paginator Variables
        //my desire page size
        private const int PAGE_SIZE = 5;

        //instance for the paginator 
        public Paginator Pager { get; set; }
        #endregion


        //current page value will apear on your url as a  request parameter value
        //          url address... ? currentPage=n (number)



        public void OnGet(int? currentPage)
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
                //installition of the paginator setup
                //determine the page number to use with the paginator
                int PageNumber = currentPage.HasValue ? currentPage.Value : 1;


                //use the page state to setup data needed for the paging
                PageState current = new PageState(PageNumber, PAGE_SIZE);

                //total rows in te complete query collection (data needed for paging)
                int totalrows = 0;

                //for effeiciency of data being transfered we will pass the
                //      current page number and te desired page size to the backend query
                //the returned collection will only have the rows of the whole query
                //  collection that will actually be shown (PAGE_SIZE or less rows)

                //the total number of records for the whole query collection will be 
                //      returned as an out parameter.This value is needed by the PAginator
                //      to set up its display logic. 
            AlbumsByGenre = _albumServices.AlbumsByGenre((int)GenreId);


                //once the query is complete, use the returned total rows in instaiizating
                //      an instance of the Paginator
                Pager = new Paginator(totalrows, current);
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
