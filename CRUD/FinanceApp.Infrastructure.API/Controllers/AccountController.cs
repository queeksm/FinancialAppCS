using Microsoft.AspNetCore.Mvc;

using FinanceApp.Controller;
using FinanceApp.Applications.Services;
using FinanceApp.Infrastructure.Data.Context;
using FinanceApp.Infrastructure.Data.Repositories;


namespace FinanceApp.Infrastructure.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        AccountServices CreateService()
        {
            ClientContext db = new ClientContext();            
            ClientsRepositories repoClient = new ClientsRepositories(db);
            AccountRepositories repoAccount = new AccountRepositories(db);
            AccountServices AccountSevices = new AccountServices(repoAccount,repoClient);
            return AccountSevices;
        }

        ClientSevices CreateClientService()
        {
            ClientContext db = new ClientContext();
            ClientsRepositories repo = new ClientsRepositories(db);
            ClientSevices clientSevices = new ClientSevices(repo);
            return clientSevices;
        }

        // GET: api/<AccountController>
        [HttpGet]
        public ActionResult<List<Accounts>> Get()
        {
            var servicio = CreateService();
            return Ok(servicio.GetAll());
        }

        // GET api/<AccountController>/5
        [HttpGet("{id}")]
        public ActionResult<Accounts> Get(Guid id)
        {
            var servicio = CreateService();
            return Ok(servicio.GetById(id));
        }

        // POST api/<AccountController>
        [HttpPost]
        public ActionResult Post(Guid clientId,[FromBody] Accounts account)
        {
            var servicio = CreateService();            
            
            servicio.AccAdd(account,clientId);
            return Ok("Yessssszzzzz");
        }               

        // PUT api/<AccountController>/5
        [HttpPut("{id}")]
        public ActionResult Put(Guid id)
        {
            var servicio = CreateService();
            servicio.ChangeStatus(id);
            return Ok("The Account status was changed succesfully");

        }        

        // DELETE api/<AccountController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            var servicio = CreateService();
            servicio.CancelAccount(id);
            return Ok("The account was cancelled succesfully");
        }
    }
}
