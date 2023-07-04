namespace Recomendation.Models
{
    public class GarderingCondition
    {
        public Guid Id { get; set; }
        public string? NameVageteble { get; set; }

        public List<int>? MonthOfPlanting { get; set; } // Месяц посадки
        public double TemperaturaPlating { get; set; } //Температура посадки
        public int FirstWatering { get; set; } //Первый полив
        public int WateringPeriod { get; set; } //Период полива
        public List<int>? HoeingDaysAfterPLating { get; set; } //Окучивание, дни после посадки
        public int LooseningPeriod { get; set; } //период рыхления
        public int WeedingPeriod { get; set; } //период прополки
        public int HarverstingDaysAfterPlating { get; set; } //Уборка урожая полсе посалки

        public Guid GarderingID { get; set; }
        public Gardering? Gardering { get; set; }
    }
}
