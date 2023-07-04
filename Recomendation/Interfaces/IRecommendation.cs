using Recomendation.Models;

namespace Recommendation.Interfaces
{
    public interface IRecommendation <T> 
    {
        public string VegetableName { get; set; }

        public string GetRecommendationsForPlanting(IEnumerable<T> kitchenGardenInfo, List<double> fiveDaysTemperatura);
        public string GetRecommendationsForWatering(KitchenGargen kitchenGargen);
        public string GetRecommendationsForHoeing(KitchenGargen kitchenGargen);
        public string GetRecommendationsloosing(KitchenGargen kitchenGargen);
        public string GetRecommendationsWeeding(KitchenGargen kitchenGargen);
        public string GetRecommendationsHarvesting(KitchenGargen kitchenGargen);
        public string GetAllRecommendations ();
    }
}
