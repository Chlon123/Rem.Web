using Remont.Web.Repositories;
using Remont.Web.Repositories.Persistance;
using Remont.Web.Repositories2.Repositories.EnumClasses;
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
                var allAccounts = _unitOfWork.AccountsRepository.GetAccounts();

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
                var oneAccount = _unitOfWork.AccountsRepository.GetAccountById(id);
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

                _unitOfWork.AccountsRepository.CreateAccount(accountToCreate);

                string id = _unitOfWork.AccountsRepository.GetAccountId(accountToCreate).ToString();

                if (_unitOfWork.AccountsRepository.IsAccountCreated(accountToCreate))
                {
                    return Created(Request.RequestUri + "/" + id, _unitOfWork.AccountsRepository.GetSingleAccount(accountToCreate));
                }
                return BadRequest();
            }
            catch (Exception)
            {
                return InternalServerError();                
            }
        }

        //PUT only for complete updates
        public IHttpActionResult Put(int id, [FromBody]Remont.Web.Models.Account account)
        {

            try
            {
                if (account == null)
                {
                    return BadRequest();
                }

                var acc =_unitOfWork.AccountsRepository.CreateAccount(account);
                var update = _unitOfWork.AccountsRepository.UpdateAccount(acc);

                if (update.Status == RepositoryActionStatus.Updated)
                {
                    var updatedAccounts = _unitOfWork.AccountsRepository.CreateAccount(update.Entity);
                    return Ok(updatedAccounts);
                }

                else if(update.Status == RepositoryActionStatus.NotFound)
                {
                    return NotFound();
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