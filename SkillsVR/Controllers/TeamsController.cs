using Microsoft.AspNetCore.Http;
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
        public IEnumerable<Team> GetTeams()
        {
            return _context.Teams.ToList();
        }

        [HttpPost]
        public Team CreateTeam(Team team)
        {
            _context.Teams.Add(team);
            _context.SaveChanges();
            return team;
        }

        [HttpGet("{teamId}/players")]
        public ActionResult<IEnumerable<Player>> GetPlayers(int teamId)
        {
            var team = _context.Teams.FirstOrDefault(team => team.Id == teamId);
            if (team == null)
            {
                return NotFound($"No team with id: {teamId} found");
            }
            return Ok(team.Players);
        }
    }
}
