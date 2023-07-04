using Microsoft.AspNetCore.Mvc;
using Recomendation.Models;
using Recommendation.Interfaces;
using System.Collections.Generic;

namespace Recommendation.Controllers
{
    public class RecommendationController: Controller
    {
        ApplicationContext db;
        public RecommendationController(ApplicationContext context)
        {
            db = context;
        }
        public IActionResult GetAllRecommendations()
        {
            Recommendation recommendation = new Recommendation(db);
          ViewBag.result = recommendation.GetAllRecommendations();
            return View();
        }
    }
}
