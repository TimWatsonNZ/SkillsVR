using Microsoft.AspNetCore.Mvc;
using SkillsVR.Data;

namespace SkillsVR.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamsController : ControllerBase
    {
        private DatabaseContext _context;
        public TeamsController(DatabaseContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Team>> GetTeams()
        {
            return Ok(_context.Teams.ToList());
        }

        [HttpPost]
        public ActionResult<Team> CreateTeam(Team team)
        {
            _context.Teams.Add(team);
            _context.SaveChanges();
            return Ok(team);
        }

        [HttpGet("{teamId}/players")]
        public ActionResult<IEnumerable<Player>> GetPlayers(int teamId)
        {
            var team = _context.Teams.FirstOrDefault(team => team.Id == teamId);
            if (team == null)
            {
                return NotFound($"No team with id: {teamId} found");
            }
            var players = _context.Players.Where(player => player.TeamId == teamId);
            return Ok(players);
        }

        [HttpPatch("{teamId}/players/{playerId}")]
        public ActionResult<Player> AddPlayerToTeam(int playerId, int teamId)
        {
            var team = _context.Teams.FirstOrDefault(team => team.Id == teamId);
            if (team == null)
            {
                return NotFound($"Team with id: {teamId} not found.");
            }

            var player = _context.Players.FirstOrDefault(player => player.Id == playerId);
            if (player == null)
            {
                return NotFound($"Player with id: {playerId} not found.");
            }
            player.TeamId = teamId;
            _context.SaveChanges();
            return Ok(player);
        }
    }
}
