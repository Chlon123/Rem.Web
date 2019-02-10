using Marvin.JsonPatch;
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
    public class UsersController : ApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly RepositoryDbContext _dbContext;


        public UsersController()
        {
            _dbContext = new RepositoryDbContext();
            _unitOfWork = new UnitOfWork(_dbContext);
        }

        public UsersController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IHttpActionResult Get()
        {
            try
            {
                var allUsers = _unitOfWork.UsersRepository.GetUsers();

                return Ok(allUsers);
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
                var singleUser = _unitOfWork.UsersRepository.GetUserById(id);
                if (singleUser == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(singleUser);
                }
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

        [HttpPost]
        public IHttpActionResult Post([FromBody] Remont.Web.Models.User userToCreate)
        {
            try
            {
                if (userToCreate == null)
                {
                    return BadRequest();
                }

                var userCreated = _unitOfWork.UsersRepository.CreateUser(userToCreate);

                string id = _unitOfWork.UsersRepository.GetUserId(userCreated).ToString();

                if (_unitOfWork.UsersRepository.IsUserCreated(userToCreate))
                {
                    return Created(Request.RequestUri + "/" + id, _unitOfWork.UsersRepository.GetUserById(userToCreate.UserId));
                }
                return BadRequest();
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

        //PUT only for complete updates
        [HttpPut]
        public IHttpActionResult Put(int id, [FromBody]Remont.Web.Models.User user)
        {
            try
            {
                if (user == null)
                {
                    return BadRequest();
                }

                var usr = _unitOfWork.UsersRepository.CreateUser(user);
                var update = _unitOfWork.UsersRepository.UpdateUser(usr);

                if (update.Status == RepositoryActionStatus.Updated)
                {
                    var updatedUser = _unitOfWork.UsersRepository.CreateUser(update.Entity);
                    return Ok(updatedUser);
                }

                else if (update.Status == RepositoryActionStatus.NotFound)
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

        [HttpPatch]
        public IHttpActionResult Patch(int id, [FromBody]JsonPatchDocument<Remont.Web.Models.User> accountPatchDocument)
        {
            try
            {
                if (accountPatchDocument == null)
                {
                    return BadRequest();
                }
                var user = _unitOfWork.UsersRepository.GetUserById(id);
                if (user == null)
                {
                    return NotFound();
                }

                var usr = _unitOfWork.UsersRepository.CreateUser(user);

                accountPatchDocument.ApplyTo(usr);

                var result = _unitOfWork.UsersRepository.UpdateUser(_unitOfWork.UsersRepository.CreateUser(usr));
                if (result.Status == RepositoryActionStatus.Updated)
                {
                    var patchedAccount = _unitOfWork.UsersRepository.CreateUser(result.Entity);
                    return Ok(patchedAccount);
                }
                return BadRequest();
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            try
            {
                var result = _unitOfWork.UsersRepository.DeleteUser(id);

                if (result.Status == RepositoryActionStatus.Deleted)
                {
                    return StatusCode(HttpStatusCode.NoContent);
                }
                else if (result.Status == RepositoryActionStatus.NotFound)
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

