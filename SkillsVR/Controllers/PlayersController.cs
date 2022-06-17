using Microsoft.AspNetCore.Mvc;
using SkillsVR.Data;

namespace SkillsVR.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayersController : ControllerBase
    {
        private DatabaseContext _context;

        public PlayersController(DatabaseContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Player>> Get([FromQuery] int? age, [FromQuery] int? weight, [FromQuery] int? height)
        {
            var query = _context.Players.AsQueryable();
            
            if (age.HasValue)
            {
                query = query.Where(player => player.Birthdate.Year == (DateTime.Now.Year - age));
            }

            if (weight.HasValue)
            {
                query = query.Where(player => player.Weight == weight);
            }

            if (height.HasValue)
            {
                query = query.Where(player => player.Height == height);
            }


            return Ok(query);
        }

        [HttpPost]
        public ActionResult<Player> CreatePlayer(Player player)
        {
            if (player.TeamId != null)
            {
                var team = _context.Teams.FirstOrDefault(team => team.Id == player.TeamId);
                if (team == null)
                {
                    return NotFound($"No team with id {player.TeamId} found");
                }
            }
            _context.Players.Add(player);
            _context.SaveChanges();
            return Ok(player);
        }

        [HttpGet("{playerId}/team")]
        public ActionResult<Team> GetPlayersTeam(int playerId)
        {
            var player = _context.Players.FirstOrDefault(player => player.Id == playerId);

            if (player== null)
            {
                return NotFound($"No player found with id ${playerId}");
            }
            var team = _context.Teams.FirstOrDefault(team => team.Id == player.TeamId);
            return Ok(team);
        }

        [HttpGet("coach/{coachName}")]
        public ActionResult<IEnumerable<Player>> GetByCoach(string coachName)
        {
            var team = _context.Teams.Where(team => team.Coach == coachName).FirstOrDefault();

            if (team == null)
            {
                return Ok(new List<Player>());
            }
            var players = _context.Players.Where(player => player.TeamId == team.Id);
            return Ok(players);
        }
    }
}
