using Microsoft.AspNetCore.Http;
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
        public IEnumerable<Player> Get([FromQuery] int? age)
        {
            var players = _context.Players;
            
            if (age.HasValue)
            {
                return players.Where(player => player.Birthdate.Year == (DateTime.Now.Year - age));
            }
            return players;
        }

        [HttpPost]
        public Player CreatePlayer(Player player)
        {
            _context.Players.Add(player);
            _context.SaveChanges();
            return player;
        }

        [HttpPatch("/{playerId}/team/{teamId}")]
        public ActionResult AddPlayerToTeam(int playerId, int teamId)
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

            player.Team = team;
            _context.SaveChanges();
            return Ok();
        }

        [HttpGet("/{playerId}/team")]
        public ActionResult<Team> GetPlayersTeam(int playerId)
        {
            var playerTeam = _context.Players.FirstOrDefault(player => player.Id == playerId)?.Team;

            if (playerTeam == null)
            {
                return NotFound();
            }

            return Ok(playerTeam);
        }

        [HttpGet("coach/{coachName}")]
        public ActionResult<IEnumerable<Player>> GetByCoach(string coachName)
        {
            //  Need a unique verify on coach -> team name. this makes it even better to have a coach table.
            var team = _context.Teams.Where(team => team.Coach == coachName).FirstOrDefault();

            if (team == null)
            {
                return NotFound();
            }

            var players = _context.Players.Where(player => player.Team.Id == team.Id);

            return Ok(players);
        }
    }
}
