namespace A16_TP_1142718_JRompre.Models
{
    public class Reservation
    {
        public int Id { get; set; }
        public int AutomobileId { get; set; }
        public string DateReservation { get; set; }
        public string DateSortie { get; set; }

        public Client? Client { get; set; }

        public override string? ToString()
        {
            return Id+" | "+AutomobileId+" | "+DateReservation+" | "+DateSortie;
        }
    }
}
