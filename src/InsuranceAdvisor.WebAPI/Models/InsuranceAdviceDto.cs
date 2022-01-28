using System.Text.Json.Serialization;

namespace InsuranceAdvisor.WebApi.Models
{
    public class InsuranceAdviceDto
    {
        [JsonPropertyName("auto")]
        public string Auto { get; }
        [JsonPropertyName("disability")]
        public string Disability { get; }
        [JsonPropertyName("home")]
        public string Home { get; }
        [JsonPropertyName("life")]
        public string Life { get; }

        public InsuranceAdviceDto(string auto,
                                  string disability,
                                  string home,
                                  string life)
        {
            Auto = auto;
            Disability = disability;
            Home = home;
            Life = life;
        }
    }
}
