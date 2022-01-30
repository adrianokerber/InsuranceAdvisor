using System.Text.Json.Serialization;

namespace InsuranceAdvisor.WebApi.Models
{
    public class HouseProfileDto
    {
        [JsonPropertyName("ownership_status")]
        public string OwnershipStatus { get; set; }
    }
}