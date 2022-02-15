using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApp.Pages.SamplePages
{
    public class BasicsModel : PageModel
    {
        public string MyName;

        //basically this is an object, treat it as such

        //data fields

        //properties
        //the annotation BindProperty ties a property in the pageModel class
        //Directly to a..
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
    }
}
