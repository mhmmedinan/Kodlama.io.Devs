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

namespace Application.Features.GithubAddresses.Commands.CreateGithubAddress
{
    public class CreateGithubAddressCommandHandler : IRequestHandler<CreateGithubAddressCommand, CreatedGithubAddressDto>
    {
        private readonly IMapper _mapper;
        private readonly IGithubAddressRepository _githubAddressRepository;

        public CreateGithubAddressCommandHandler(IMapper mapper, IGithubAddressRepository githubAddressRepository)
        {
            _mapper = mapper;
            _githubAddressRepository = githubAddressRepository;
        }

        public async Task<CreatedGithubAddressDto> Handle(CreateGithubAddressCommand request, CancellationToken cancellationToken)
        {
            GithubAddress mappedGithubAddress = _mapper.Map<GithubAddress>(request);
            GithubAddress createdGithubAdress = await _githubAddressRepository.AddAsync(mappedGithubAddress);
            CreatedGithubAddressDto createdGithubAddressDto = _mapper.Map<CreatedGithubAddressDto>(createdGithubAdress);
            return createdGithubAddressDto;
        }
    }
}
