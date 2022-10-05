using Application.Features.OperationClaims.Models;
using Core.Application.Requests;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.OperationClaims.Queries.GetListOperationClaim
{
    public class GetListOperationClaimQuery:IRequest<OperationClaimListModel>
    {
        public PageRequest PageRequest { get; set; }
    }
}
