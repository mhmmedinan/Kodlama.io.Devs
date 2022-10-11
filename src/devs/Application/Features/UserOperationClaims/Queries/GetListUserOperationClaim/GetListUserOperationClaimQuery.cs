using Application.Features.UserOperationClaims.Models;
using Core.Application.Pipelines.Authorization;
using Core.Application.Requests;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Application.Features.UserOperationClaims.Constants.OperationClaims;
using static Domain.Constants.OperationClaims;

namespace Application.Features.UserOperationClaims.Queries.GetListUserOperationClaim
{
    public class GetListUserOperationClaimQuery:IRequest<UserOperationClaimListModel>,ISecuredRequest
    {
        public PageRequest PageRequest { get; set; }
        public string[] Roles => new[] { Admin,OperationClaimList }; 
        
    }
}
