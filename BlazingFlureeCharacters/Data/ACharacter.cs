using FlureeDotnetLibrary.FlureeCommand.Model;
using Newtonsoft.Json;

namespace BlazingFlureeCharacters.Data
{
    public class ACharacter: FlureeTransactionDataParentBody
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("characters/name")]
        public string Name1
        {
            set
            {
                Name = value;
            }
        }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("characters/description")]
        public string Description1
        {
            set
            {
                Description = value;
            }
        }
        [JsonProperty("class")]
        public string Class { get; set; }

        [JsonProperty("characters/class")]
        public string Class1
        {
            set
            {
                Class = value;
            }
        }
        [JsonProperty("race")]
        public string Race { get; set; }

        [JsonProperty("characters/race")]
        public string Race1
        {
            set
            {
                Race = value;
            }
        }
        [JsonProperty("hp")]
        public int HP { get; set; }

        [JsonProperty("characters/hp")]
        public int HP1
        {
            set
            {
                HP = value;
            }
        }
        [JsonProperty("strength")]
        public int Strength { get; set; }

        [JsonProperty("characters/strength")]
        public int Strength1
        {
            set
            {
                Strength = value;
            }
        }
        [JsonProperty("dexterity")]
        public int Dexterity { get; set; }

        [JsonProperty("characters/dexterity")]
        public int Dexterity1
        {
            set
            {
                Dexterity = value;
            }
        }
        [JsonProperty("constitution")]
        public int Constitution { get; set; }

        [JsonProperty("characters/constitution")]
        public int Constitution1
        {
            set
            {
                Constitution = value;
            }
        }
        [JsonProperty("intelligence")]
        public int Intelligence { get; set; }

        [JsonProperty("characters/intelligence")]
        public int Intelligence1
        {
            set
            {
                Intelligence = value;
            }
        }
        [JsonProperty("wisdom")]
        public int Wisdom { get; set; }

        [JsonProperty("characters/wisdom")]
        public int Wisdom1
        {
            set
            {
                Wisdom = value;
            }
        }
        [JsonProperty("charisma")]
        public int Charisma { get; set; }

        [JsonProperty("characters/charisma")]
        public int Charisma1
        {
            set
            {
                Charisma = value;
            }
        }
    }
}
