using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApp.Pages.SamplePages
{
    public class ControlsModel : PageModel
    {
        [TempData]
        public string Feedback { get; set; }


        [BindProperty]
        public string EmailText { get; set; }

        [BindProperty]
        public string PasswordText { get; set; }

        [BindProperty]
        public string DateText { get; set; }

        //public DateTime DateText { get; set; } /= DateTime.Today;
        [BindProperty]
        public string TimeText { get; set; }
        //(if we need a default time from now)
        //public TimeSpan TimeText { get; set; } /= DateTime.Now.TimeOfDay;
        public void OnGet()
        {

        }

        public IActionResult OnPostTextBox()
        {

            Feedback = $"Email{ EmailText}; PasswordText {PasswordText };  Date {DateText}; Time{TimeText};";
            return Pages();
        }
    }
}
