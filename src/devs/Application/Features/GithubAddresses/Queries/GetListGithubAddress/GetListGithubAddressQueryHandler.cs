using Application.Features.GithubAddresses.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.GithubAddresses.Queries.GetListGithubAddress
{
    public class GetListGithubAddressQueryHandler : IRequestHandler<GetListGithubAddressQuery, GithubAddressListModel>
    {
        private readonly IMapper _mapper;
        private readonly IGithubAddressRepository _githubAddressRepository;

        public GetListGithubAddressQueryHandler(IMapper mapper, IGithubAddressRepository githubAddressRepository)
        {
            _mapper = mapper;
            _githubAddressRepository = githubAddressRepository;
        }

        public async Task<GithubAddressListModel> Handle(GetListGithubAddressQuery request, CancellationToken cancellationToken)
        {

            IPaginate<GithubAddress> githubAddress = await _githubAddressRepository.GetListAsync(
                                                                                           index: request.PageRequest.Page,
                                                                                           size: request.PageRequest.PageSize
                                                                                           );
            GithubAddressListModel mappedGithubAddress = _mapper.Map<GithubAddressListModel>(githubAddress);
            return mappedGithubAddress;
        }
    }
}
