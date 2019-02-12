using Marvin.JsonPatch;
using Remont.Web.ControllerHelpers;
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

        [VersionedRoute("api/accounts", 2)]
        public IHttpActionResult GetVer2(string sort = "userid", string fields = null)
        {
            try
            {
                var listOfFIelds = _unitOfWork.ListOfFields.CreateListOfFields(fields);

                var sortedUsersWithFields = _unitOfWork.UsersRepository.GetSortedUsersWithFields(sort, listOfFIelds);

                if (sortedUsersWithFields == null)
                {
                    return NotFound();
                }

                return Ok(sortedUsersWithFields);
            }
            catch (Exception)
            {

                return InternalServerError();
            }
        }



        [VersionedRoute("api/users", 1)]
        public IHttpActionResult Get(string sort = "userid", string fields = null)
        {
            try
            {
                var listOfFIelds = _unitOfWork.ListOfFields.CreateListOfFields(fields);

                var sortedUsersWithFields = _unitOfWork.UsersRepository.GetSortedUsersWithFields(sort, listOfFIelds);

                if (sortedUsersWithFields == null)
                {
                    return NotFound();
                }

                return Ok(sortedUsersWithFields);
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
        public IHttpActionResult Patch(int id, [FromBody]JsonPatchDocument<Remont.Web.Models.User> userPatchDocument)
        {
            try
            {
                if (userPatchDocument == null)
                {
                    return BadRequest();
                }
                var user = _unitOfWork.UsersRepository.GetUserById(id);
                if (user == null)
                {
                    return NotFound();
                }

                var usr = _unitOfWork.UsersRepository.CreateUser(user);

                userPatchDocument.ApplyTo(usr);

                var result = _unitOfWork.UsersRepository.UpdateUser(_unitOfWork.UsersRepository.CreateUser(usr));
                if (result.Status == RepositoryActionStatus.Updated)
                {
                    var patchedUser = _unitOfWork.UsersRepository.CreateUser(result.Entity);
                    return Ok(patchedUser);
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

