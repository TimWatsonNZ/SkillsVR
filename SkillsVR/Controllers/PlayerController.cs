using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SkillsVR.Data;

namespace SkillsVR.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        private DatabaseContext _context;

        public PlayerController(DatabaseContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Player> Get()
        {
            return _context.Players;
        }

        [HttpPost]
        public Player AddPlayer(Player player)
        {
            _context.Players.Add(player);
            return player;
        }

        [HttpGet]
        public void GetByAge()
        {

        }

        [HttpGet]
        public void GetByCoach()
        {

        }
    }
}
