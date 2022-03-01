using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Hangman.Data;
using Hangman.Data.Models;
using Hangman.infrastructure.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Hangman.Web.Controllers
{
    public class ApiUsersController : ControllerBase
    {

        private readonly IRepository<Users> _Users;

        public ApiUsersController(IRepository<Users> user)
        {
            _Users = user;
        }

        [HttpGet]
        [Route("api/users")]
        public async Task<IActionResult> RetrieveAllUsers()
        {
            IAsyncEnumerable<Users> users;
            try
            {
                users = await _Users.GetAllAsync();
            }
            catch(Exception ex)
            {
                return BadRequest($"Couldn't access the clients. Ex: {ex}");
            }

            return Ok(users);
        }
        [HttpPost]
        [Route("api/create")]
        public async Task<IActionResult> Create([FromBody] Users user)
        {
            try
            {
                await _Users.InsertAsync(user);
            }
            catch(Exception ex)
            {
                return BadRequest($"Error when creating a user. Ex: {ex}");
            }

            return Ok($"Successfully created user: {user}");
        }

        [HttpPut]
        [Route("api/update")]
        public async Task<IActionResult> Update([FromBody] Users user)
        {
            try
            {
                await _Users.UpdateAsync(user);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error when updating a user. Ex: {ex}");
            }
            return Ok($"Successfully updated user: {user}");
        }

        [HttpDelete]
        [Route("api/delete")]
        public async Task<IActionResult> Delete([FromBody] Users user)
        {
            try
            {
                await _Users.DeleteAsync(user.Id);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error when deleting a user. Ex: {ex}");
            }
            return Ok($"Successfully deleted user: {user}");
        }
    }
}
