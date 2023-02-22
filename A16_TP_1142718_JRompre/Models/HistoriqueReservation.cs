namespace A16_TP_1142718_JRompre.Models
{
    public class HistoriqueReservation
    {
        public int Id { get; set; }
        public int AutomobileId { get; set; }
        public DateTime DateReservation { get; set; }
        public DateTime DateSortie { get; set; }
        public DateTime DateRetour { get; set; }

        public Client? Client { get; set; }
    }
}
