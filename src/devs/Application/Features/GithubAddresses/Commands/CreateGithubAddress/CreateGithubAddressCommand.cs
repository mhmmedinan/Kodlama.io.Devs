using Application.Features.GithubAddresses.Dtos;
using Core.Application.Pipelines.Authorization;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Application.Features.GithubAddresses.Constants.OperationClaims;
using static Domain.Constants.OperationClaims;

namespace Application.Features.GithubAddresses.Commands.CreateGithubAddress
{
    public class CreateGithubAddressCommand:IRequest<CreatedGithubAddressDto>,ISecuredRequest
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string[] Roles => new[] { Admin, GithubAddressesAdd };
    }
}
