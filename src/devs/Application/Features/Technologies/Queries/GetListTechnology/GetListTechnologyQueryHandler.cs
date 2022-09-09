using Application.Features.Technologies.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Technologies.Queries.GetListTechnology
{
    public class GetListTechnologyQueryHandler : IRequestHandler<GetListTechnologyQuery, TechnologyListModel>
    {
        private readonly IMapper _mapper;
        private readonly ITechnologyRepository _technologyRepository;

        public GetListTechnologyQueryHandler(IMapper mapper, ITechnologyRepository technologyRepository)
        {
            _mapper = mapper;
            _technologyRepository = technologyRepository;
        }

        public async Task<TechnologyListModel> Handle(GetListTechnologyQuery request, CancellationToken cancellationToken)
        {

            IPaginate<Technology> technologies = await _technologyRepository.GetListAsync(include: t => t.Include(t => t.ProgrammingLanguage),
                                                                                           index: request.PageRequest.Page,
                                                                                           size: request.PageRequest.PageSize
                                                                                           );
            TechnologyListModel mappedTechnology = _mapper.Map<TechnologyListModel>(technologies);
            return mappedTechnology;
        }
    }
}
