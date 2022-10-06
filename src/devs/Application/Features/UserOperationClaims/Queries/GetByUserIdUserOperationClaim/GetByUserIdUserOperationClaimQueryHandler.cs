using Application.Features.UserOperationClaims.Dtos;
using Application.Features.UserOperationClaims.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Persistence.Paging;
using Core.Security.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UserOperationClaims.Queries.GetByUserIdUserOperationClaim
{
    public class GetByUserIdUserOperationClaimQueryHandler : IRequestHandler<GetByUserIdUserOperationClaimQuery, UserOperationClaimListModel>
    {
        private readonly IUserOperationClaimRepository _userOperationClaimRepository;
        private readonly IMapper _mapper;

        public GetByUserIdUserOperationClaimQueryHandler(IUserOperationClaimRepository userOperationClaimRepository, IMapper mapper)
        {
            _userOperationClaimRepository = userOperationClaimRepository;
            _mapper = mapper;
        }

        public async Task<UserOperationClaimListModel> Handle(GetByUserIdUserOperationClaimQuery request, CancellationToken cancellationToken)
        {
            IPaginate<UserOperationClaim> userOperationClaim = await _userOperationClaimRepository.GetListAsync(u=>u.UserId==request.UserId, include: u => u.Include(u => u.User).Include(o => o.OperationClaim));
            UserOperationClaimListModel userOperationClaimGetByUserIdDto = _mapper.Map<UserOperationClaimListModel>(userOperationClaim);
            return userOperationClaimGetByUserIdDto;
        }
    }
}
