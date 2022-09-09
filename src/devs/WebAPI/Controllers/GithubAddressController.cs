using Application.Features.GithubAddresses.Commands.CreateGithubAddress;
using Application.Features.GithubAddresses.Commands.DeleteGithubAddress;
using Application.Features.GithubAddresses.Commands.UpdateGithubAddress;
using Application.Features.GithubAddresses.Dtos;
using Application.Features.GithubAddresses.Models;
using Application.Features.GithubAddresses.Queries.GetByUserIdGithubAddress;
using Application.Features.GithubAddresses.Queries.GetListGithubAddress;
using Core.Application.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GithubAddressController : BaseController
    {
        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] CreateGithubAddressCommand createGithubAddressCommand)
        {
            CreatedGithubAddressDto result = await Mediator.Send(createGithubAddressCommand);
            return Created("", result);
        }

        [HttpGet("GetList")]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListGithubAddressQuery getListGithubAddressQuery = new() { PageRequest = pageRequest };
            GithubAddressListModel result = await Mediator.Send(getListGithubAddressQuery);
            return Ok(result);
        }

        [HttpGet("{UserId}")]
        public async Task<IActionResult> GetByUserId([FromRoute] GetByUserIdGithubAddressQuery getByUserIdGithubAddressQuery)
        {
            GithubAddressGetByUserIdDto githubAddressGetByUserIdDto = await Mediator.Send(getByUserIdGithubAddressQuery);
            return Ok(githubAddressGetByUserIdDto);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteGithubAddressCommand deleteGithubAddressCommand)
        {
            DeletedGithubAddressDto result = await Mediator.Send(deleteGithubAddressCommand);
            return Ok(result);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] UpdateGithubAddressCommand updateGithubAddressCommand)
        {
            UpdatedGithubAddressDto result = await Mediator.Send(updateGithubAddressCommand);
            return Ok(result);
        }
    }
}
