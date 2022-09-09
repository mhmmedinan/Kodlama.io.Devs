using Application.Features.GithubAddresses.Models;
using Core.Application.Requests;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.GithubAddresses.Queries.GetListGithubAddress
{
    public class GetListGithubAddressQuery:IRequest<GithubAddressListModel>
    {
        public PageRequest PageRequest { get; set; }
    }
}
