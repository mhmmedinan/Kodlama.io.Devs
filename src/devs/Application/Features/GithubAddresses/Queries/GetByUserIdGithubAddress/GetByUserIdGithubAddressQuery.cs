using Application.Features.GithubAddresses.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.GithubAddresses.Queries.GetByUserIdGithubAddress
{
    public class GetByUserIdGithubAddressQuery:IRequest<GithubAddressGetByUserIdDto>
    {
        public int UserId { get; set; }
    }
}
