using System.Collections.Generic;

namespace Recomendation.Models
{
    public class InfoGardering
    {
        public Guid Id { get; set; }
        public string VegetableName { get; set; }

        public List<int> NumberMonchsPlanting { get; set; }
        public int MinTemperaaturaPlanting { get; set; }
        public int FirstWateringAfterPlating { get; set; }
        public int WateringPeriod { get; set; }
        public List <int> HoeingAfterPlanring { get; set; }
        public int looseningPeriod { get; set; }
        public int WeedingPeriod { get; set; }
        public int HarvestingAfterPlanting { get; set; }

    }
}
//INSERT INTO public."InfoGardering"(
//    "Id", "VegetableName", "NumberMonchsPlanting", "MinTemperaaturaPlanting", "FirstWateringAfterPlating", "WateringPeriod", "HoeingAfterPlanring", "looseningPeriod", "WeedingPeriod", "HarvestingAfterPlanting")

//    VALUES('F9168C5E-CEB2-4faa-B6BF-329BF39FA1E4', 'potato', '{4,5}', 9, 25, 10, '{25,40}', 10, 10, 90);