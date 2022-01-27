using Newtonsoft.Json;

namespace InsuranceAdvisor.WebApi.Models
{
    public class InsuranceAdviceDto
    {
        [JsonProperty("auto")]
        public string Auto { get; }
        [JsonProperty("disability")]
        public string Disability { get; }
        [JsonProperty("home")]
        public string Home { get; }
        [JsonProperty("life")]
        public string Life { get; }

        public InsuranceAdviceDto(string auto, string disability, string home, string life)
        {
            Auto = auto;
            Disability = disability;
            Home = home;
            Life = life;
        }
    }
}
