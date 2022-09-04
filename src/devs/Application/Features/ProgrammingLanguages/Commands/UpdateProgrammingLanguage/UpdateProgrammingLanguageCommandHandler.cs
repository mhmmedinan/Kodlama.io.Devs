using Application.Features.ProgrammingLanguages.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProgrammingLanguages.Commands.UpdateProgrammingLanguage
{
    public class UpdateProgrammingLanguageCommandHandler : IRequestHandler<UpdateProgrammingLanguageCommand, UpdatedProgrammingLanguageDto>
    {
        private readonly IProgrammingLanguageRepository _programmingLanguageRepository;
        private readonly IMapper _mapper;

        public UpdateProgrammingLanguageCommandHandler(IMapper mapper, IProgrammingLanguageRepository programmingLanguageRepository)
        {
            _mapper = mapper;
            _programmingLanguageRepository = programmingLanguageRepository;
        }
        public async Task<UpdatedProgrammingLanguageDto> Handle(UpdateProgrammingLanguageCommand request, CancellationToken cancellationToken)
        {
            ProgrammingLanguage mappedProgrammingLanguage = _mapper.Map<ProgrammingLanguage>(request);
            ProgrammingLanguage updatedProgrammingLanguage = await _programmingLanguageRepository.UpdateAsync(mappedProgrammingLanguage);
            UpdatedProgrammingLanguageDto updatedProgrammingLanguageDto = _mapper.Map<UpdatedProgrammingLanguageDto>(updatedProgrammingLanguage);
            return updatedProgrammingLanguageDto;
        }
    }
}
