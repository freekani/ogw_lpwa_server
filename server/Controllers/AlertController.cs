using System;
using System.Text.Json;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using server.Models;

namespace server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlertController : ControllerBase
    {
        private readonly AlertContext _context;

        public AlertController(AlertContext context)
        {
            _context = context;
        }

        // GET: api/Alert
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AlertModel>>> GetAlertModels()
        {
            return await _context.AlertModels.ToListAsync();
        }

        // GET: api/Alert/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AlertModel>> GetAlertModel(ulong id)
        {
            var alertModel = await _context.AlertModels.FindAsync(id);

            if (alertModel == null)
            {
                return NotFound();
            }

            return alertModel;
        }

        [HttpGet("latest")]

        public async Task<ActionResult<AlertModel>> GetLatestAlertModel()
        {
            var alertModel = await _context.AlertModels.LastOrDefaultAsync();

            if (alertModel == null)
            {
                return NotFound();
            }

            return alertModel;
        }

        [Produces("application/json")]
        [HttpGet("latestforsigfox")]
        public async Task<ActionResult<Dictionary<string, ReturnForSigfoxModel>>> GetLatestAlertforSigfox()
        {
            var alertModel = await _context.AlertModels.LastOrDefaultAsync();

            if (alertModel == null)
            {
                return NotFound();
            }
            var returnModel = new Dictionary<string, ReturnForSigfoxModel>();
            returnModel.Add("764462", new ReturnForSigfoxModel() { downlinkData = alertModel.Head + alertModel.Body });
            //var returnModel = new ReturnForSigfoxModel() { downlinkData = alertModel.Head + alertModel.Body };

            //return JsonSerializer.Deserialize<new{string a =""}>("{\"" + "764462" + "\":" + JsonSerializer.Serialize(returnModel) + "}");
            return returnModel;
        }

        [HttpPost("latestforsigfox")]
        public async Task<ActionResult<Dictionary<string, ReturnForSigfoxModel>>> GetLatestAlertforSigfox_forPost(CallbackForSigfoxModel callback)
        {
            var alertModel = await _context.AlertModels.LastOrDefaultAsync();

            if (alertModel == null)
            {
                return NotFound();
            }
            var returnModel = new Dictionary<string, ReturnForSigfoxModel>();
            returnModel.Add(callback.DeviceId, new ReturnForSigfoxModel() { downlinkData = alertModel.Head + alertModel.Body });
            //var returnModel = new ReturnForSigfoxModel() { downlinkData = alertModel.Head + alertModel.Body };

            //return JsonSerializer.Deserialize<new{string a =""}>("{\"" + "764462" + "\":" + JsonSerializer.Serialize(returnModel) + "}");
            return returnModel;
        }
        /*
        [HttpPost("latestforsigfox")]
        public async Task<ActionResult<String>> GetLatestAlertforSigfox(CallbackForSigfoxModel callback)
        {
            var alertModel = await _context.AlertModels.LastOrDefaultAsync();

            if (alertModel == null)
            {
                return NotFound();
            }
            var returnModel = new ReturnForSigfoxModel() { downlinkData = alertModel.Head + alertModel.Body };


            return "{\"" + callback.DeviceId + "\":" + JsonSerializer.Serialize(returnModel) + "}";
        }
*/
        // PUT: api/Alert/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAlertModel(ulong id, AlertModel alertModel)
        {
            if (id != alertModel.Id)
            {
                return BadRequest();
            }

            _context.Entry(alertModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AlertModelExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Alert
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<AlertModel>> PostAlertModel(AlertModel alertModel)
        {
            _context.AlertModels.Add(alertModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetAlertModel), new { id = alertModel.Id }, alertModel);
        }

        [HttpGet("addtest")]
        public async Task<ActionResult<AlertModel>> AddTest()
        {
            AlertModel alertModel;
            if (_context.AlertModels.Count() == 0)
            {
                alertModel = new AlertModel() { Id = 1, Head = "7b1048c9", Body = "4283db0a" };
            }
            else
            {
                alertModel = new AlertModel() { Id = _context.AlertModels.Last().Id + 1, Head = "7b1048c9", Body = "4283db0a" };
            }
            _context.AlertModels.Add(alertModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetAlertModel), new { id = alertModel.Id }, alertModel);
        }

        // DELETE: api/Alert/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<AlertModel>> DeleteAlertModel(ulong id)
        {
            var alertModel = await _context.AlertModels.FindAsync(id);
            if (alertModel == null)
            {
                return NotFound();
            }

            _context.AlertModels.Remove(alertModel);
            await _context.SaveChangesAsync();

            return alertModel;
        }

        private bool AlertModelExists(ulong id)
        {
            return _context.AlertModels.Any(e => e.Id == id);
        }
    }
}
