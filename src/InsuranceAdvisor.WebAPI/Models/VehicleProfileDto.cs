using System.Text.Json.Serialization;

namespace InsuranceAdvisor.WebApi.Models
{
    public class VehicleProfileDto
    {
        [JsonPropertyName("year")]
        public int Year { get; set; }
    }
}