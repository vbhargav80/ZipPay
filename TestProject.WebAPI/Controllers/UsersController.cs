using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using TestProject.WebAPI.Commands;
using TestProject.WebAPI.Queries;
using TestProject.WebAPI.Responses;

namespace TestProject.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Gets all the users
        /// </summary>
        /// <returns>List of UserResponse</returns>
        /// <response code="200">Returns all the users</response>
        [ProducesResponseType(typeof(List<UserResponse>), StatusCodes.Status200OK)]
        [HttpGet()]
        public async Task<ActionResult<List<UserResponse>>> GetAllUsers()
        {
            var userResponse = await _mediator.Send(new GetAllUsersQuery());
            
            return Ok(userResponse);
        }

        /// <summary>
        /// Gets a user with the given id
        /// </summary>
        /// <param name="id">id of the user</param>
        /// <returns>UserResponse</returns>
        /// <response code="200">Returns the user</response>
        /// <response code="400">User could not be found</response>
        [ProducesResponseType(typeof(UserResponse), StatusCodes.Status200OK)]
        [HttpGet("{id}")]
        public async Task<ActionResult<UserResponse>> GetUser(int id)
        {
            var userResponse = await _mediator.Send(new GetUserQuery { Id = id });
            if (userResponse == null)
            {
                return NotFound();
            }

            return Ok(userResponse);
        }

        /// <summary>
        /// Creates a new user
        /// </summary>
        /// <response code="201">User created successfully</response>
        /// <response code="400">User data is invalid</response>
        /// <response code="409">Duplicate user email address</response>
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(409)]
        [ProducesResponseType(500)]
        [HttpPost]
        public async Task<ActionResult<UserResponse>> CreateUser(CreateUserCommand createUserCommand)
        {
            var createUserResponse = await _mediator.Send(createUserCommand);
            if (!createUserResponse.Successful)
            {
                return Conflict(createUserResponse.Error);
            }

            return CreatedAtAction(nameof(GetUser), new GetUserQuery() { Id = createUserResponse.Id }, createUserResponse);
        }
    }
}
