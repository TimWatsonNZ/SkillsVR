using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SkillsVR.Data;

namespace SkillsVR.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamController : ControllerBase
    {
        private DatabaseContext _context;
        public TeamController(DatabaseContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Team> GetTeams()
        {
            return _context.Teams.ToList();
        }

        [HttpPost]
        public Team AddTeams(Team team)
        {
            _context.Teams.Add(team);
            _context.SaveChanges();
            return team;
        }
    }
}
