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

namespace Application.Features.ProgrammingLanguages.Commands.DeleteProgrammingLanguage
{
    public class DeleteProgrammingLanguageCommandHandler : IRequestHandler<DeleteProgrammingLanguageCommand, DeletedProgrammingLanguageDto>
    {
        private readonly IProgrammingLanguageRepository _programmingLanguageRepository;
        private readonly IMapper _mapper;

        public DeleteProgrammingLanguageCommandHandler(IMapper mapper, IProgrammingLanguageRepository programmingLanguageRepository)
        {
            _mapper = mapper;
            _programmingLanguageRepository = programmingLanguageRepository;
        }

        public async Task<DeletedProgrammingLanguageDto> Handle(DeleteProgrammingLanguageCommand request, CancellationToken cancellationToken)
        {
            ProgrammingLanguage? programmingLanguage = await _programmingLanguageRepository.GetAsync(p => p.Id == request.Id);
            ProgrammingLanguage deletedProgrammingLanguage = await _programmingLanguageRepository.DeleteAsync(programmingLanguage);
            DeletedProgrammingLanguageDto deletedProgrammingLanguageDto = _mapper.Map<DeletedProgrammingLanguageDto>(deletedProgrammingLanguage);
            return deletedProgrammingLanguageDto;
        }
    }
}
