using System.ComponentModel.DataAnnotations;

namespace A16_TP_1142718_JRompre.Models
{
    public class Automobile
    {
        public int Id { get; set; }
        public int Annee { get; set; }
        public string Marque { get; set; }
        public string Model { get; set; }
        public string Motopropulsion { get; set; }
        public string Transmission { get; set; }
        public string Licence { get; set; }
        [DataType(DataType.Currency)]
        public double Prix { get; set; }

    }
}
