using Application.Features.UserOperationClaims.Models;
using Core.Application.Requests;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UserOperationClaims.Queries.GetListUserOperationClaim
{
    public class GetListUserOperationClaimQuery:IRequest<UserOperationClaimListModel>
    {
        public PageRequest PageRequest { get; set; }
    }
}
