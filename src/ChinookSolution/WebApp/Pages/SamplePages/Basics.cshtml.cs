using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApp.Pages.SamplePages
{
    public class BasicsModel : PageModel
    {
        public void OnGet()
        {
            //Executes in response to a Get Request from the browser
            //When the page is "First" accessed, the browser issues the get request
            //When the page is refreshed, Without a Post request the browser issues a get request
            //when the page is retrived in response to a form's Posting using RedirectToPage()
            //If Not RedirectToPage() is used on the POST, there is no Get Request
        }
    }
}
