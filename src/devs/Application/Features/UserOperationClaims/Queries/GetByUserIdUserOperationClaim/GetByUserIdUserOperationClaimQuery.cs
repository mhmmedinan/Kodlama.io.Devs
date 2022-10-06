using Application.Features.UserOperationClaims.Dtos;
using Application.Features.UserOperationClaims.Models;
using Core.Application.Requests;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UserOperationClaims.Queries.GetByUserIdUserOperationClaim
{
    public class GetByUserIdUserOperationClaimQuery:IRequest<UserOperationClaimListModel>
    {
        public PageRequest PageRequest { get; set; }
        public int UserId { get; set; }

    }
}
