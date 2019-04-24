using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Miki.Anilist.Tests
{
	public class Queries
	{
		[Fact]
		public async Task GetCharacter()
		{
			AnilistClient client = new AnilistClient();
			var ch = await client.GetCharacterAsync("rem");

			Assert.NotNull(ch);

			ch = await client.GetCharacterAsync(37832);

			Assert.NotNull(ch);
		}

        [Fact]
        public async Task GetStaff()
        {
            AnilistClient client = new AnilistClient();
            var ch = await client.GetStaffAsync("Shinichi Fukuda");

            Assert.NotNull(ch);

            ch = await client.GetStaffAsync(105350);

            Assert.NotNull(ch);
        }

        [Fact]
		public async Task FindCharacters()
		{
			AnilistClient client = new AnilistClient();
			var ch = await client.SearchCharactersAsync("miki");

			Assert.NotNull(ch);
			Assert.NotEmpty(ch.Items);
		}

		[Fact]
		public async Task GetManga()
		{
			AnilistClient client = new AnilistClient();
			var ch = await client.GetMediaAsync("miki", MediaFormat.MANGA);

			Assert.NotNull(ch);

			ch = await client.GetMediaAsync(104747);

			Assert.NotNull(ch);
			Assert.Equal(104747, ch.Id);
		}

		[Fact]
		public async Task GetAnime()
		{
			AnilistClient client = new AnilistClient();
			var ch = await client.GetMediaAsync("miki", MediaFormat.TV);

			Assert.NotNull(ch);
		}

        [Fact]
        public async Task FindAnimesAndMangas()
        {
            AnilistClient client = new AnilistClient();
            var ch = await client.SearchMediaAsync("miki");

            Assert.True(ch.Items.Select(i => i.Type).Distinct().Count() == 2);
            Assert.NotNull(ch);
            Assert.NotEmpty(ch.Items);
        }

		[Fact]
		public async Task FindAnimes()
		{
			AnilistClient client = new AnilistClient();
			var ch = await client.SearchMediaAsync("miki", type: MediaType.ANIME);

            Assert.All(ch.Items, i => Assert.Equal(MediaType.ANIME, i.Type));
			Assert.NotNull(ch);
			Assert.NotEmpty(ch.Items);
		}

		[Fact]
		public async Task FindMangas()
		{
			AnilistClient client = new AnilistClient();
			var ch = await client.SearchMediaAsync("miki", type: MediaType.MANGA);

            Assert.All(ch.Items, i => Assert.Equal(MediaType.MANGA, i.Type));
			Assert.NotNull(ch);
			Assert.NotEmpty(ch.Items);
		}
	}
}
