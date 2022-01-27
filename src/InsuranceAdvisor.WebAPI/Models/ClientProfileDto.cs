using Newtonsoft.Json;

namespace InsuranceAdvisor.WebApi.Models
{
    public class ClientProfileDto
    {
        [JsonProperty("age")]
        public int Age { get; set; }
        [JsonProperty("dependents")]
        public int Dependents { get; set; }
        [JsonProperty("house")]
        public HouseProfileDto? House { get; set; }
        [JsonProperty("income")]
        public decimal Income { get; set; }
        [JsonProperty("marital_status")]
        public string MartialStatus { get; set; }
        [JsonProperty("risk_questions")]
        public List<int> RiskQuestions { get; set; }
        [JsonProperty("vehicle")]
        public VehicleProfileDto? Vehicle { get; set; }
    }
}
