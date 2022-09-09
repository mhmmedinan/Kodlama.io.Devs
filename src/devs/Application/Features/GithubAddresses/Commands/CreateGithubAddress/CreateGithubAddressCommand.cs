using Application.Features.GithubAddresses.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.GithubAddresses.Commands.CreateGithubAddress
{
    public class CreateGithubAddressCommand:IRequest<CreatedGithubAddressDto>
    {
        public int UserId { get; set; }
        public string Name { get; set; }
    }
}
