using FlureeDotnetLibrary.FlureeCommand.Model;
using Newtonsoft.Json;

namespace BlazingFlureeCharacters.Data
{
    public class ACharacter: FlureeTransactionDataParentBody
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("class")]
        public string Class { get; set; }
        [JsonProperty("race")]
        public string Race { get; set; }
        [JsonProperty("hp")]
        public int HP { get; set; }
        [JsonProperty("strength")]
        public int Strength { get; set; }
        [JsonProperty("dexterity")]
        public int Dexterity { get; set; }
        [JsonProperty("constitution")]
        public int Constitution { get; set; }
        [JsonProperty("intelligence")]
        public int Intelligence { get; set; }
        [JsonProperty("wisdom")]
        public int Wisdom { get; set; }
        [JsonProperty("charisma")]
        public int Charisma { get; set; }
    }
}
