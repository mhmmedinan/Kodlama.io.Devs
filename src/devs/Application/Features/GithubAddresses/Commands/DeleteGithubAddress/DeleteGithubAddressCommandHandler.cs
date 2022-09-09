using Application.Features.GithubAddresses.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.GithubAddresses.Commands.DeleteGithubAddress
{
    public class DeleteGithubAddressCommandHandler : IRequestHandler<DeleteGithubAddressCommand, DeletedGithubAddressDto>
    {
        private readonly IMapper _mapper;
        private readonly IGithubAddressRepository _githubAddressRepository;

        public DeleteGithubAddressCommandHandler(IMapper mapper, IGithubAddressRepository githubAddressRepository)
        {
            _mapper = mapper;
            _githubAddressRepository = githubAddressRepository;
        }

        public async Task<DeletedGithubAddressDto> Handle(DeleteGithubAddressCommand request, CancellationToken cancellationToken)
        {
            GithubAddress? githubAddress = await _githubAddressRepository.GetAsync(x => x.Id == request.Id);
            GithubAddress deletedGithubAddress = await _githubAddressRepository.DeleteAsync(githubAddress);
            DeletedGithubAddressDto deletedGithubAddressDto = _mapper.Map<DeletedGithubAddressDto>(deletedGithubAddress);
            return deletedGithubAddressDto;
        }
    }
}
