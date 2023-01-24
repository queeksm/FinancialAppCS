using Microsoft.AspNetCore.Mvc;

using FinanceApp.Controller;
using FinanceApp.Applications.Services;
using FinanceApp.Infrastructure.Data.Context;
using FinanceApp.Infrastructure.Data.Repositories;


namespace FinanceApp.Infrastructure.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        
        ClientSevices CreateService()
        {
            ClientContext db = new ClientContext();
            ClientsRepositories repo = new ClientsRepositories(db);
            ClientSevices clientSevices = new ClientSevices(repo);
            return clientSevices;
        }
        
        // GET: api/<ClientController>
        [HttpGet]
        public ActionResult<List<Clients>> Get()
        {
            var servicio = CreateService();
            return Ok(servicio.GetAll());
        }

        // GET api/<ClientController>/5
        [HttpGet("{id}")]
        public ActionResult<Clients> Get(Guid id)
        {
            var servicio = CreateService();
            return Ok(servicio.GetById(id));
        }

        // POST api/<ClientController>
        [HttpPost]
        public ActionResult Post([FromBody] Clients client)
        {
            var servicio = CreateService();
            servicio.Add(client);
            return Ok("Client Added");
        }

        // PUT api/<ClientController>/5
        [HttpPut("{id}")]
        public ActionResult Put(Guid id, [FromBody] Clients client)
        {
            var servicio = CreateService();
            client.CliId = id;
            servicio.Edit(client);
            return Ok("Client Edited");
        }

        // DELETE api/<ClientController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            var servicio = CreateService();
            servicio.Delete(id);
            return Ok("Client Deleted");
        }
    }
}
