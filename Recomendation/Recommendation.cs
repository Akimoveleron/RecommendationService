using Microsoft.AspNetCore.Mvc.RazorPages;
using Recomendation.Models;
using Recommendation.Interfaces;
using System.Data.Common;
using System.Globalization;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Xml.Linq;

namespace Recommendation
{
    public class Recommendation 
    {

        ApplicationContext db;
        public Recommendation(ApplicationContext context)
        {
            db = context;
        }

        public string VegetableName { get; set; }
        private List<double> fiveDaysTemperatura = new List<double>();
        private List <bool> fiveDaysPrecipitation = new List<bool>();

        public List<string> GetAllRecommendations()
        {
            List<string> resultRecommendation = new List<string>();

          fiveDaysTemperatura  = WeatherForecast.GetFiveDaysTemperatura();
            fiveDaysPrecipitation = WeatherForecast.GetFiveDaysPrecipitation();
            List<KitchenGargen> kitchenGargens = db.KitchenGargen.ToList();
         

          var kitchenGardenInfo = db.KitchenGargen.Join(db.InfoGardering,
                k => k.InfoGarderingId,
                i => i.Id,
                (k, i) => new
                {
                    Name = k.VegetableName,
                    Id = i.Id,
                    Planting = k.Planting,
                    Watering = k.Watering,
                    Hoeing = k.Hoeing,
                    Loosening = k.loosening,
                    Weeding = k.Weeding,
                    Harvesting = k.Harvesting,
                    NumberMonchsPlanting = i.NumberMonchsPlanting,
                    MinTemperaaturaPlanting = i.MinTemperaaturaPlanting,
                    FirstWateringAfterPlating = i.FirstWateringAfterPlating,
                    WateringPeriod = i.WateringPeriod,
                    HoeingAfterPlanring = i.HoeingAfterPlanring,
                    looseningPeriod = i.looseningPeriod,
                    WeedingPeriod = i.WeedingPeriod,
                    HarvestingAfterPlanting = i.HarvestingAfterPlanting,

                }).ToList();


            foreach (var item in kitchenGardenInfo)
            {
                resultRecommendation.Add(item.Name);
                resultRecommendation.Add(GetRecommendationsForPlanting(item.Name,item.Planting, item.NumberMonchsPlanting, item.MinTemperaaturaPlanting));
                resultRecommendation.Add(GetRecommendationsForWatering(item.Name, item.Planting,item.Watering, item.FirstWateringAfterPlating, item.WateringPeriod));
                resultRecommendation.Add(GetRecommendationsForHoeing(item.Name, item.Planting,  item.HoeingAfterPlanring));
                resultRecommendation.Add(GetRecommendationsloosing(item.Name, item.Planting, item.Loosening, item.looseningPeriod));
                resultRecommendation.Add(GetRecommendationsWeeding(item.Name, item.Planting, item.Weeding, item.WeedingPeriod));
                resultRecommendation.Add(String.Empty);
            };
     
            return resultRecommendation;
        }

        public string GetRecommendationsForPlanting(string name, DateTime? planting, List<int> monthPlating, int minTemperaaturaPlanting)
        {
            

            if (planting is null)
            {
                if (monthPlating.Contains(int.Parse(DateTime.Now.Month.ToString())) && minTemperaaturaPlanting > fiveDaysTemperatura.Min())
                {
                    return $"Рекомендуется посадить {name} в ближайшие дни   ";
                }else if(minTemperaaturaPlanting > fiveDaysTemperatura.Min())
                {
                    return $"Сажать {name} не следует, подожди когда станет потеплее";
                }
                else
                {
                    return $"Сажать {name} рановато, потерпи до {CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(monthPlating.Min())} ";
                }
            }
            else
            {
                return $"Отлично, {name} посажен";
            }

        }

        public string GetRecommendationsForWatering(string name, DateTime? planting, DateTime? watering, int firstWateringAfterPlating, int wateringPeriod)
        {
            if (planting is null) return String.Empty;
            int daysAfterPlanting = DateTime.Now.Subtract((DateTime)planting).Days;
            int daysAfterLastWatering = DateTime.Now.Subtract((DateTime)watering).Days;
            if (daysAfterPlanting<firstWateringAfterPlating)
            {
                return $"Рекомендуется полив {name} осуществить через {firstWateringAfterPlating-daysAfterPlanting} дней ";
            }
            else if (daysAfterLastWatering<wateringPeriod)
            {
                return $"Было бы круто, если бы вы полили {name} через {wateringPeriod-daysAfterLastWatering} дней";
            }
            else
            {
                return $"Бедный {name} засыхает от жажды, полей быстро!! ";
            }
           
        }

        public string GetRecommendationsForHoeing(string name, DateTime? planting, List<int> hoeingAfterPlanring)
        {
            if (planting is null) return String.Empty;
            int daysAfterPlanting = DateTime.Now.Subtract((DateTime)planting).Days;
            int daysBeforeHoeining = int.MinValue;

            if (daysAfterPlanting > hoeingAfterPlanring.Max()) return $"Окучивание {name} не требуется";
           
            for (int i = hoeingAfterPlanring.Count-1; i >=0; i--)
            {
                if (daysAfterPlanting > hoeingAfterPlanring[i])
                {
                    daysBeforeHoeining = hoeingAfterPlanring[i + 1] - daysAfterPlanting;
                }
            }

            return $"Окучить {name} необходимо через {daysBeforeHoeining} дней";
        }


        public string GetRecommendationsloosing(string name, DateTime? planting, DateTime? loosening, int looseningPeriod)
        {
            if (planting is null) return String.Empty;
            int daysAfterLoosening = DateTime.Now.Subtract((DateTime)loosening).Days;
            if (daysAfterLoosening<looseningPeriod)
            {
                return $"Рекомендуется рыхление через {looseningPeriod-daysAfterLoosening} дней";
            }
            else
            {
                return $"Лучше порыхлить RIGHT NOW!!!";
            }

        }

        public string GetRecommendationsWeeding(string name, DateTime? planting, DateTime? weeding, int weedingPeriod)
        {
            if (planting is null) return String.Empty;
            int daysAfterWeeding = DateTime.Now.Subtract((DateTime)weeding).Days;
            if (daysAfterWeeding < weedingPeriod)
            {
                return $"Рекомендуется прополка через {weedingPeriod - daysAfterWeeding} дней";
            }
            else
            {
                return $"Всё заросло сорняками - быстро полоть!!!";
            }
        }


        public string GetRecommendationsHarvesting(string name, DateTime? planting, int harvestingAfterPlanting)
        {
            if (planting is null) return String.Empty;
            int daysAfterPlanting = DateTime.Now.Subtract((DateTime)planting).Days;
            if (daysAfterPlanting < harvestingAfterPlanting)
            {
                return $"Рекомендуется уборка урожая {name} через {harvestingAfterPlanting-daysAfterPlanting} дней";
            }
            else
            {
                return $"Время пришло собрать урожая {name}";
            }
        }
    }
}
