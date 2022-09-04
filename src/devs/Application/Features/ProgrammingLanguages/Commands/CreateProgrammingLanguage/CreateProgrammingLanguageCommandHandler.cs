using Application.Features.ProgrammingLanguages.Dtos;
using Application.Features.ProgrammingLanguages.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProgrammingLanguages.Commands.CreateProgrammingLanguage
{
    public class CreateProgrammingLanguageCommandHandler : IRequestHandler<CreateProgrammingLanguageCommand, CreatedProgrammingLanguageDto>
    {
        private readonly IProgrammingLanguageRepository _programmingLanguageRepository;
        private readonly IMapper _mapper;
        private readonly ProgrammingLanguageBusinessRules _programmingLanguageBusinessRules;

        public CreateProgrammingLanguageCommandHandler(ProgrammingLanguageBusinessRules programmingLanguageBusinessRules, IMapper mapper, IProgrammingLanguageRepository programmingLanguageRepository)
        {
            _programmingLanguageBusinessRules = programmingLanguageBusinessRules;
            _mapper = mapper;
            _programmingLanguageRepository = programmingLanguageRepository;
        }

        public async Task<CreatedProgrammingLanguageDto> Handle(CreateProgrammingLanguageCommand request, CancellationToken cancellationToken)
        {
            await _programmingLanguageBusinessRules.ProgrammingLanguageNameCanNotBeDuplicatedWhenInserted(request.Name);
            ProgrammingLanguage mappedProgrammingLanguage = _mapper.Map<ProgrammingLanguage>(request);
            ProgrammingLanguage createProgrammingLanguage = await _programmingLanguageRepository.AddAsync(mappedProgrammingLanguage);
            CreatedProgrammingLanguageDto createProgrammingLanguageDto = _mapper.Map<CreatedProgrammingLanguageDto>(createProgrammingLanguage);
            return createProgrammingLanguageDto;
        }
    }
}
