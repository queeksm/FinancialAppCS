using Microsoft.AspNetCore.Mvc;

using FinanceApp.Controller;
using FinanceApp.Applications.Services;
using FinanceApp.Infrastructure.Data.Context;
using FinanceApp.Infrastructure.Data.Repositories;


namespace FinanceApp.Infrastructure.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionsController : ControllerBase
    {
        TransactionServices CreateService()
        {
            ClientContext db = new ClientContext();            
            AccountRepositories repo = new AccountRepositories(db);
            TransactionRepositories transactions = new TransactionRepositories(db);
            TransactionServices TransactionSevices =  new TransactionServices(repo,transactions);
            return TransactionSevices;
        }

        // GET: api/<TransactionsController>
        [HttpGet]
        public ActionResult<List<Transactions>> Get()
        {
            var servicio = CreateService();
            return Ok(servicio.GetAll());
        }

        // GET api/<TransactionsController>/5
        [HttpGet("{id}")]
        public ActionResult<Transactions> Get(Guid id)
        {
            var servicio = CreateService();
            return Ok(servicio.GetById(id));
        }

        // POST api/<TransactionsController>
        [HttpPost]
        public ActionResult Post([FromBody] Transactions transaction, Guid account)
        {
            var servicio = CreateService();

            switch(transaction.TransactionType)
            {
                case "Deposit":
                    servicio.Deposit(transaction, account, transaction.Amount);
                    return Ok("Deposit completed");
                case "Withdraw":
                    servicio.Withdraw(transaction, account, transaction.Amount);
                    return Ok("Withdraw completed");
                case "Transfer":
                    servicio.Transfer(transaction, account, transaction.ReceiverAccount, transaction.Amount);
                    return Ok("Transaction Completed");
                default:
                    return Ok("incorrect type of transaction, please choose one of the correct types");
            }
                
        }
    }
}
