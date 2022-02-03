using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FamManager.Server.Interfaces;
using FamManager.Shared.Models;

namespace FamManager.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActionController : ControllerBase
    {
         private readonly IAction _IAction;
        public ActionController(IAction iAction)
        {
            _IAction = iAction;
        }
        [HttpGet]
        public async Task<List<Shared.Models.Action>> Get()
        {
            return await Task.FromResult(_IAction.GetAction());
        }
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            Shared.Models.Action action = _IAction.GetAction(id);
            if (action != null)
            {
                return Ok(action);
            }
            return NotFound();
        }
        [HttpPost]
        public void Post(Shared.Models.Action action)
        {
            _IAction.AddAction(action);
        }
        [HttpPut]
        public void Put(Shared.Models.Action action)
        {
            _IAction.UpdateAction(action);
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            _IAction.DeleteAction(id);
            return Ok();
        }
    }

}

