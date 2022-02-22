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

        [BindProperty]
        public string Meal { get; set; }
        //assumes this array is actuallt data retrieve from the database
        public string[] Meals { get; set; } = new[] { "breakfast", "lunch", "dinner", "snacks"};
        [BindProperty]
        public bool AcceptanceBox { get; set; }

        [BindProperty]
        public string MessageBody { get; set; }
        public void OnGet()
        {

        }

        public IActionResult OnPostTextBox()
        {

            Feedback = $"Email{ EmailText}; PasswordText {PasswordText };  Date {DateText}; Time{TimeText};";
            return Pages();
        }

        public IActionResult OnPostRadioCheckArea()
        {

            Feedback = $"Meal{ Meal}; Acceptance {AcceptanceBox };  Message {MessageBody};";
            return Pages();
        }
    }
}
