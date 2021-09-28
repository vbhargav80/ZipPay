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
    public class AccountsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AccountsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Gets all the accounts
        /// </summary>
        /// <returns>List of AccountResponse</returns>
        /// <response code="200">Returns all the accounts</response>
        [ProducesResponseType(typeof(List<AccountResponse>), StatusCodes.Status200OK)]
        [HttpGet()]
        public async Task<ActionResult<List<AccountResponse>>> GetAllAccounts()
        {
            var accountsResponse = await _mediator.Send(new GetAllAccountsQuery());

            return Ok(accountsResponse);
        }

        /// <summary>
        /// Gets an account with the given id
        /// </summary>
        /// <param name="id">id of the account</param>
        /// <returns>AccountResponse</returns>
        /// <response code="200">Returns the account</response>
        /// <response code="400">Account could not be found</response>
        [ProducesResponseType(typeof(AccountResponse), StatusCodes.Status200OK)]
        [HttpGet("{id}")]
        public async Task<ActionResult<AccountResponse>> GetAccount(int id)
        {
            var accountResponse = await _mediator.Send(new GetAccountQuery() { Id = id });
            if (accountResponse == null)
            {
                return NotFound();
            }

            return Ok(accountResponse);
        }

        /// <summary>
        /// Creates a new account
        /// </summary>
        /// <response code="201">Account created successfully</response>
        /// <response code="400">Account data is invalid</response>
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [HttpPost]
        public async Task<ActionResult<AccountResponse>> CreateAccount(CreateAccountCommand createAccountCommand)
        {
            var createAccountResponse = await _mediator.Send(createAccountCommand);
            if (!createAccountResponse.Successful)
            {
                return BadRequest(createAccountResponse.Error);
            }

            return CreatedAtAction(nameof(GetAccount), new GetAccountQuery() { Id = createAccountResponse.Id }, createAccountResponse);
        }
    }
}
