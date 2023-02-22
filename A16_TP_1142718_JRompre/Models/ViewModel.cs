using System.ComponentModel.DataAnnotations;

namespace A16_TP_1142718_JRompre.Models
{
    public class ViewModel
    {
        public Automobile Automobile { get; set; }
        public Client Client { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM-dd-yyyy}")]
        public DateTime DateReservation { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM-dd-yyyy}")]
        public DateTime DateSortie { get; set; }
    }
}
