namespace Recomendation.Models
{
    public class Gardering
    {
        public Guid Id { get; set; }
        public string NameVegetable { get; set; }
        public DateTime Planting { get; set; } //Посадка
        public DateTime LastWatering { get; set; } //Последний полив
        public DateTime LastHoeing { get; set; } //Последние окучивание
        public DateTime LastLoosening { get; set; } //Последние рыхление
        public DateTime LastWeeding { get; set; } //Последняя прополка
        public DateTime Harvesting { get; set; } //Сбор урожая

    }
}
