using Miki.GraphQL.Queries;
using Newtonsoft.Json;

namespace Miki.Anilist.Internal.Queries
{
	internal class CharacterQuery
	{
		[JsonProperty("Character")]
		internal AnilistCharacter Character;
	}

    internal class StaffQuery
    {
        [JsonProperty("Staff")]
        internal AnilistCharacter Staff;
    }

	internal class MediaQuery
	{
		[GraphQLField("media")]
		[JsonProperty("Media")]
		internal AnilistMedia Media;
	}
}
