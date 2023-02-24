namespace A16_TP_1142718_JRompre.Models
{
    public class HistoriqueReservation
    {
        public int Id { get; set; }
        public int AutomobileId { get; set; }
        public string DateReservation { get; set; }
        public string DateSortie { get; set; }
        public string DateRetour { get; set; }

        public Client? Client { get; set; }
    }
}
