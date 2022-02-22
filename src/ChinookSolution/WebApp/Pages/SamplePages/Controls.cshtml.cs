using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApp.Pages.SamplePages
{
    public class ControlsModel : PageModel
    {
        [TempData]
        public string Feedback { get; set; }


        [BindProperty]
        public string Email { get; set; }

        [BindProperty]
        public string PasswordText { get; set; }

        [BindProperty]
        public DateTime DateText { get; set; }

        [BindProperty]
        public TimeSpan TimeText { get; set; }
        public void OnGet()
        {
        }
    }
}
