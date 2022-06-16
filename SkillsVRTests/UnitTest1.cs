using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;

namespace SkillsVRTests
{
    public class Tests
    {
        private readonly TestServer _server;
        private readonly HttpClient _client;
        [SetUp]
        public void Setup()
        {
            _server = new TestServer(new WebHostBuilder()
                .UseStartup<Startup>());
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
    }
}