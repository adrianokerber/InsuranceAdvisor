using System.Text.Json.Serialization;

namespace InsuranceAdvisor.WebApi.Models
{
    public class ClientProfileDto
    {
        [JsonPropertyName("age")]
        public int Age { get; set; }
        [JsonPropertyName("dependents")]
        public int Dependents { get; set; }
        [JsonPropertyName("house")]
        public HouseProfileDto? House { get; set; }
        [JsonPropertyName("income")]
        public decimal Income { get; set; }
        [JsonPropertyName("marital_status")]
        public string MartialStatus { get; set; }
        [JsonPropertyName("risk_questions")]
        public List<int> RiskQuestions { get; set; }
        [JsonPropertyName("vehicle")]
        public VehicleProfileDto? Vehicle { get; set; }
    }
}
