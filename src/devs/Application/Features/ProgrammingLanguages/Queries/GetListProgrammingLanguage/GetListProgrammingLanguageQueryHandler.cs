using Application.Features.ProgrammingLanguages.Models;
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

namespace Application.Features.ProgrammingLanguages.Queries.GetListProgrammingLanguage
{
    public class GetListProgrammingLanguageQueryHandler : IRequestHandler<GetListProgrammingLanguageQuery, ProgrammingLanguageListModel>
    {
        private readonly IProgrammingLanguageRepository _programmingLanguageRepository;
        private readonly IMapper _mapper;

        public GetListProgrammingLanguageQueryHandler(IMapper mapper, IProgrammingLanguageRepository programmingLanguageRepository)
        {
            _mapper = mapper;
            _programmingLanguageRepository = programmingLanguageRepository;
        }

        public async Task<ProgrammingLanguageListModel> Handle(GetListProgrammingLanguageQuery request, CancellationToken cancellationToken)
        {
           IPaginate<ProgrammingLanguage> programmingLanguage = await _programmingLanguageRepository.GetListAsync(index:request.PageRequest.Page,size:request.PageRequest.PageSize);
           ProgrammingLanguageListModel mappedProgrammingLanguageListModel = _mapper.Map<ProgrammingLanguageListModel>(programmingLanguage);
           return mappedProgrammingLanguageListModel;
        }
    }
}
