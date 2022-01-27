using Newtonsoft.Json;

namespace InsuranceAdvisor.WebApi.Models
{
    public class HouseProfileDto
    {
        [JsonProperty("ownership_status")]
        public string OwnershipStatus { get; set; }
    }
}