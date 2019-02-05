using Remont.Web.Repositories;
using Remont.Web.Repositories.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Remont.Web.Controllers
{
    public class AccountsController : ApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly RepositoryDbContext _dbContext;


        public AccountsController()
        {
            _dbContext = new RepositoryDbContext();
            _unitOfWork = new UnitOfWork(_dbContext);
        }

        public AccountsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IHttpActionResult Get()
        {
            try
            {
                var allAccounts = _unitOfWork.Accounts.GetAccounts();

                return Ok(allAccounts);
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

        public IHttpActionResult Get(int id)
        {
            try
            {
                var oneAccount = _unitOfWork.Accounts.GetAccountById(id);
                if (oneAccount == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(oneAccount);
                }
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

        [HttpPost]
        public IHttpActionResult Post([FromBody] Remont.Web.Models.Account accountToCreate)
        {
            try
            {
                if (accountToCreate == null)
                {
                    return BadRequest();
                }

                _unitOfWork.Accounts.AddAccount(accountToCreate);

                string id = _unitOfWork.Accounts.GetAccountId(accountToCreate).ToString();

                if (_unitOfWork.Accounts.IsAccountCreated(accountToCreate))
                {
                    return Created(Request.RequestUri + "/" + id, _unitOfWork.Accounts.GetSingleAccount(accountToCreate));
                }
                return BadRequest();
            }
            catch (Exception)
            {
                return InternalServerError();                
            }
        }

    }
}
//private static void RegisterServices(IKernelConfiguration kernel)
//{
//    kernel.Bind<IUnitOfWork>().To<UnitOfWork>();
//}