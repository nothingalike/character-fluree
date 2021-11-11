using FlureeDotnetLibrary.FlureeCommand;
using FlureeDotnetLibrary.FlureeCommand.Model;
using FlureeDotnetLibrary.FlureeQuery;
using FlureeDotnetLibrary.FlureeQuery.Model;
using Newtonsoft.Json;

namespace BlazingFlureeCharacters.Data
{
    public interface ICharacterService
    {
        Task<IEnumerable<ACharacter>> GetCharactersAsync();
        Task<bool> CreateCharacter(ACharacter aCharacter);
    }

    public class CharacterService: ICharacterService
    {
        private readonly IExecuteFlureeQuery _executeFlureeQuery;
        private readonly IFlureeCommandService _flureeCommandService;

        public CharacterService(IExecuteFlureeQuery executeFlureeQuery, IFlureeCommandService flureeCommandService)
        {
            _executeFlureeQuery = executeFlureeQuery;
            _flureeCommandService = flureeCommandService;
        }

        public async Task<bool> CreateCharacter(ACharacter aCharacter)
        {
            try
            {
                aCharacter.CollectionId = "characters";
                var transactionCommandList = new List<FlureeTransactionDataParentBody>()
                {
                    aCharacter
                };

                await _flureeCommandService.InsertDataIntoFluree("bfc", "main", transactionCommandList);
                return true;
            }catch(Exception ex)
            {
                return false;
            }
        }

        public async Task<IEnumerable<ACharacter>> GetCharactersAsync()
        {
            try
            {
                var query = new BaseQuery()
                {
                    SqlSelect = new List<string>()
                {
                    "*"
                },
                    SqlFrom = "characters"
                };

                var result = await _executeFlureeQuery.ExectureSingleFlureeQuery("bfc", "main", query);
                var lCharacters = new List<ACharacter>();
                foreach (var c in result)
                {
                    lCharacters.Add(JsonConvert.DeserializeObject<ACharacter>(JsonConvert.SerializeObject(c)));
                }

                return lCharacters;
            }catch(Exception ex)
            {
                return new List<ACharacter>();
            }

        }
    }

    public class BaseQuery : QueryBuilder { }
}
