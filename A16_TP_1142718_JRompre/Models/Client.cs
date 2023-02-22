namespace A16_TP_1142718_JRompre.Models
{
    public class Client
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Email { get; set; }

        public ICollection<Automobile>? Automobiles { get; set; }
        public ICollection<Reservation>? Reservations { get; set; }
        public ICollection<HistoriqueReservation>? HistoriqueReservations { get; set; }
    }
}
