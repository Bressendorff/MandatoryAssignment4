using ManadatoryAssignment1;
using MandatoryAss4.Managers;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MandatoryAss4.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class FootballPlayersController : ControllerBase
    {
        private static readonly FootballPlayersManager Manager = new FootballPlayersManager();
        // GET: api/<FootballPlayersController>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [HttpGet]
        public ActionResult<IEnumerable<FootballPlayer>> Get()
        {
            var list = Manager.GetAll();
            if (list.Count == 0)
            {
                return NoContent();
            }

            return Ok(list);
        }

        // GET api/<FootballPlayersController>/5

        [ProducesResponseType((StatusCodes.Status200OK))]
        [ProducesResponseType((StatusCodes.Status404NotFound))]
        [HttpGet("{id}")]
        public ActionResult<FootballPlayer> Get(int id)
        {
            FootballPlayer player = Manager.GetById(id);
            if (player == null) return NotFound();
            return Ok(player);
        }

        // POST api/<FootballPlayersController>
        [ProducesResponseType((StatusCodes.Status201Created))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public ActionResult<FootballPlayer> Post([FromBody] FootballPlayer newPlayer)
        {
            try
            {
                newPlayer.Validate();
                FootballPlayer player = Manager.Add(newPlayer);
                return Created($"/{player.Id}", newPlayer);
            }
            catch (Exception e)
            {
                return BadRequest("Invalid FootballPlayer.");
            }
        }

        // PUT api/<FootballPlayersController>/5
        [ProducesResponseType((StatusCodes.Status200OK))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType((StatusCodes.Status404NotFound))]
        [HttpPut("{id}")]
        public ActionResult<FootballPlayer> Put(int id, [FromBody] FootballPlayer updatePlayer)
        {
            if (Manager.GetById(id) == null) return NotFound($"No FootballPlayer with id: {id}");
            try
            {
                updatePlayer.Validate();
                FootballPlayer player = Manager.Update(id, updatePlayer);
                return Ok(player);
            }
            catch (Exception e)
            {
                return BadRequest("Invalid FootballPlayer.");
            }
        }

        // DELETE api/<FootballPlayersController>/5
        [ProducesResponseType((StatusCodes.Status200OK))]
        [ProducesResponseType((StatusCodes.Status404NotFound))]
        [HttpDelete("{id}")]
        public ActionResult<FootballPlayer> Delete(int id)
        {
            FootballPlayer player = Manager.Delete(id);
            if (player == null) return NotFound($"No FootballPlayer with id: {id}");
            return Ok(player);

        }
    }
}
