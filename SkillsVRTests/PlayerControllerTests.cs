
using SkillsVR.Data;
using System.Net.Http.Json;

namespace SkillsVRTests
{
    public class PlayerControllerTests
    {
        private SkillsVRApplication _application;


        [Test]
        public async Task AddPlayerTest()
        {
            _application = new SkillsVRApplication();
            var client = _application.CreateClient();

            var player = new Player()
            {
                Name = "Test",
                Birthdate = DateTime.Now,
                Height = 100,
                Weight = 100,
                PlaceOfBirth = "Auckland",
            };

            await client.PostAsJsonAsync("api/players", player);
            var players = await client.GetFromJsonAsync<List<Player>>("api/players");

            Assert.IsNotNull(players[0]);
            Assert.IsTrue(players[0].Name == player.Name);
            Assert.IsTrue(players[0].Birthdate == player.Birthdate);
            Assert.IsTrue(players[0].Height == player.Height);
            Assert.IsTrue(players[0].Weight == player.Weight);
            Assert.IsTrue(players[0].PlaceOfBirth == player.PlaceOfBirth);
        }

        [Test]
        public async Task SearchPlayerTest()
        {
            _application = new SkillsVRApplication();
            var client = _application.CreateClient();

            var player1 = new Player()
            {
                Name = "string",
                Birthdate = DateTime.Now,
                Height = 100,
                Weight = 100,
                PlaceOfBirth = "string",
            };

            var player2 = new Player()
            {
                Name = "string",
                Birthdate = DateTime.Now,
                Height = 100,
                Weight = 200,
                PlaceOfBirth = "string",
            };

            var player3 = new Player()
            {
                Name = "string",
                Birthdate = new DateTime(1986, 6, 19),
                Height = 200,
                Weight = 100,
                PlaceOfBirth = "string",
            };

            await client.PostAsJsonAsync("api/players", player1);
            await client.PostAsJsonAsync("api/players", player2);
            await client.PostAsJsonAsync("api/players", player3);

            var players = await client.GetFromJsonAsync<List<Player>>("api/players");

            Assert.IsTrue(players.Count() == 3);

            var searchByAge = await client.GetFromJsonAsync<List<Player>>("api/players?age=0");
            Assert.IsTrue(searchByAge.Count() == 2);

            var searchByWeight = await client.GetFromJsonAsync<List<Player>>("api/players?weight=100");
            Assert.IsTrue(searchByWeight.Count() == 2);

            var searchByHeight = await client.GetFromJsonAsync<List<Player>>("api/players?height=100");
            Assert.IsTrue(searchByHeight.Count() == 2);
        }
    }
}