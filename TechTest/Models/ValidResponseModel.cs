using System.ComponentModel.DataAnnotations;

namespace Tfl.API.ConsoleClientApp.Models
{
    public class ValidResponseModel
    {
        
        //[JsonProperty(PropertyName = "Display Name")]
        [Display(Name ="The status of the")]
        public string displayName { get; set; }

        //[JsonProperty(PropertyName = "Road Status")]
        public string statusSeverity { get; set; }

        //[JsonProperty(PropertyName = "Road Status Description")]
        public string statusSeverityDescription { get; set; }
    }
}
