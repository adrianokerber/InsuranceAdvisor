using Newtonsoft.Json;

namespace InsuranceAdvisor.WebApi.Models
{
    public class VehicleProfileDto
    {
        [JsonProperty("year")]
        public int Year { get; set; }
    }
}