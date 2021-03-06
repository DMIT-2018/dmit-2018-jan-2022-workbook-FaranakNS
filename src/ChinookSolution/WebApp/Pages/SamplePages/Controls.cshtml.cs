using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
#region Additional namespaces

using ChinookSystem.ViewModels;
#endregion
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

        [BindProperty]
        public int MyRide { get; set; }
        //pretend that following collection is data from database
        //the collection is baed on 2 property based on 2 property class called SelectionList
        //the data for the list will created in a seprate method

        public List<SelectionList> Rides { get; set; }
        [BindProperty]
        public string VacationSpot { get; set; }
        public List<string> VacationSpots { get; set; }
        [BindProperty]
        public int ReviewRating { get; set; }



        public void OnGet()
        {
            PopulateList();
        }


        public void PopulateList()
        {
            //create a pretend collection from a database represents different types
            //of a transportation (rides)

            Rides = new List<SelectionList>();
            Rides.Add(new SelectionList() { ValueId = 1, DisplayText = "Car" });
            Rides.Add(new SelectionList() { ValueId = 2, DisplayText = "Bus" });
            Rides.Add(new SelectionList() { ValueId = 3, DisplayText = "Bike" });
            Rides.Add(new SelectionList() { ValueId = 4, DisplayText = "Motorcycle" });
            Rides.Add(new SelectionList() { ValueId = 5, DisplayText = "Board" });
            Rides.Sort((x, y) => x.DisplayText.CompareTo(y.DisplayText));

            VacationSpots = new List<string>();
            VacationSpots.Add("California");
            VacationSpots.Add("Caribean");
            VacationSpots.Add("Crusing");
            VacationSpots.Add("Europe");
            VacationSpots.Add("Florida");
            VacationSpots.Add("Mexico");

        }  

        public IActionResult OnPostTextBox()
        {

            Feedback = $"Email{ EmailText}; PasswordText {PasswordText };  Date {DateText}; Time{TimeText};";
            return Page();
        }

        public IActionResult OnPostRadioCheckArea()
        {

            Feedback = $"Meal{ Meal}; Acceptance {AcceptanceBox };  Message {MessageBody};";
            return Page();
        }



        public IActionResult OnPostListSlider()
        {

            Feedback = $"Ride{ MyRide}; Vacation {VacationSpot };  Reveiw Rating {ReviewRating};";
            PopulateList();
            return Page();
        }
    }
}


////public class SelectionList
////{
////    public int ValueId { get; set; }
////    public string DisplayText { get; set; }
////}