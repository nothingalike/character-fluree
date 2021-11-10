using FlureeDotnetLibrary.FlureeQuery;
using FlureeDotnetLibrary.FlureeQuery.Model;

namespace BlazingFlureeCharacters.Data
{
    public interface ICharacterService
    {
        Task<IEnumerable<ACharacter>> GetCharactersAsync();
    }

    public class CharacterService: ICharacterService
    {
        private readonly IExecuteFlureeQuery _executeFlureeQuery;

        public CharacterService(IExecuteFlureeQuery executeFlureeQuery)
        {
            _executeFlureeQuery = executeFlureeQuery;
        }

        public async Task<IEnumerable<ACharacter>> GetCharactersAsync()
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
            foreach(var c in result)
            {
                lCharacters.Add((ACharacter)c);
            }

            return lCharacters;
        }
    }

    public class BaseQuery : QueryBuilder { }
}
