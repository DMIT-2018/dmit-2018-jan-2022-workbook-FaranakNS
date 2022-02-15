using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApp.Pages.SamplePages
{
    public class BasicsModel : PageModel
    {
        public string MyName;

        //basically this is an object, treat it as such

        //properties

        //data fields
        //the annotation [TempData] stores data untill its read in another imidiate request
        //this annotation attirbute has 2 methods called Keep(string) and Peek(string) (used on Content Page)
        //Keep in a dictionary (name/value pair)
        //useful to redirect when data is required for more than a single request
        //Implemented by Tempdata providers using either cookies or session state
        //Tempdata is Not bound to any particular control like BindProperty

        [TempData]
        public string Feedback { get; set; }

        //the annotation BindProperty ties a property in the pageModel class
        //Directly to a control on the content page
        //data is transfered between the 2 automatically
        //on the Content page,the control to use this property will have s helper-tag called asp-for
        [BindProperty]
        public int id { get; set; }
        //constructors

        //behaviors(AKA methods)
        public void OnGet()
        {
            //Executes in response to a Get Request from the browser
            //When the page is "First" accessed, the browser issues the get request
            //When the page is refreshed, Without a Post request the browser issues a get request
            //when the page is retrived in response to a form's Posting using RedirectToPage()
            //If Not RedirectToPage() is used on the POST, there is no Get Request

            //server-side processing
            //contains no html


            Random rnd=new Random();
            int oddeven=rnd.Next(0,25);
            if(oddeven% 2==0){
                    MyName=$"Don is even {oddeven}";
            }
            else
            {
                MyName= null;
            }

        }

        //processing in response to a request from a form on a web page
        //this request is referred to as a Post(method="Post")

        //General Post occures when a asp-page-handler is NOT used
        //the return datatype can be void, however,your will randomly encounter the datatype IActionResult

        //the IActionResult requires some type of request action on the return statement of the method OnPost()

        //Page()
        // :does not issue a OnGet request
        // :remains on the current page
        // : a good action for form processing involving validation
        //  : and with the catch of a try/catch
    }

}
