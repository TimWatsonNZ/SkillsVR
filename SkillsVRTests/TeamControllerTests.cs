
using SkillsVR.Data;
using System.Net.Http.Json;

namespace SkillsVRTests
{
    public class TeamControllerTests
    {
        private SkillsVRApplication _application;

        [Test]
        public async Task AddTeamTest()
        {
            _application = new SkillsVRApplication();
            var client = _application.CreateClient();

            var team = new Team()
            {
                Coach = "Coach",
                FoundedYear = DateTime.Now,
                Ground = "Auckland",
                Name = "Spiders",
                Region = "Auckland"
            };

            await client.PostAsJsonAsync("api/teams", team);
            var teams = await client.GetFromJsonAsync<List<Team>>("api/teams");

            Assert.IsNotNull(teams[0]);
            Assert.IsTrue(teams[0].Coach == team.Coach);
            Assert.IsTrue(teams[0].FoundedYear == team.FoundedYear);
            Assert.IsTrue(teams[0].Ground == team.Ground);
            Assert.IsTrue(teams[0].Name == team.Name);
            Assert.IsTrue(teams[0].Region == team.Region);
        }

        [Test]
        public async Task DisplayTeamsPlayersTest()
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

            var response = await client.PostAsJsonAsync("api/players", player1);
            var p1 = await response.Content.ReadFromJsonAsync<Player>();

            response = await client.PostAsJsonAsync("api/players", player2);
            var p2 = await response.Content.ReadFromJsonAsync<Player>();
            
            response = await client.PostAsJsonAsync("api/players", player3);
            var p3 = await response.Content.ReadFromJsonAsync<Player>();

            var team = new Team()
            {
                Coach = "Coach",
                FoundedYear = DateTime.Now,
                Ground = "Auckland",
                Name = "Spiders",
                Region = "Auckland"
            };

            response = await client.PostAsJsonAsync<Team>("api/teams", team);
            var t1 = await response.Content.ReadFromJsonAsync<Team>();

            response = await client.PatchAsync($"api/teams/{t1.Id}/players/{p1.Id}", null);
            var r = await response.Content.ReadFromJsonAsync<Player>();

            await client.PatchAsync($"api/teams/{t1.Id}/players/{p1.Id}", null);
            await client.PatchAsync($"api/teams/{t1.Id}/players/{p2.Id}", null);
            await client.PatchAsync($"api/teams/{t1.Id}/players/{p3.Id}", null);

            await client.GetFromJsonAsync<List<Player>>("api/players");

            var teamPlayers = await client.GetFromJsonAsync<List<Player>>($"/api/teams/1/players");
            Assert.IsTrue(teamPlayers.Count() == 3);
        }
    }
}