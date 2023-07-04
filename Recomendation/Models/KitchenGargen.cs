using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Data.Common;

namespace Recomendation.Models
{
    public class KitchenGargen
    {
        public Guid Id { get; set; }
        public string VegetableName { get; set; }
        public Guid InfoGarderingId { get; set; }
        public InfoGardering? InfoGardering { get; set; }

        [BindProperty, DataType("month")]
        public DateTime? Planting { get; set; }
        public DateTime? Watering { get; set; }
        public DateTime? Hoeing { get; set; }
        public DateTime? loosening { get; set; }
        public DateTime? Weeding { get; set; }
        public DateTime? Harvesting { get; set; }
    }
}
