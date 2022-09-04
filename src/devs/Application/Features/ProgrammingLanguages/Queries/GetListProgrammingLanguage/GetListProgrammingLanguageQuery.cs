using Application.Features.ProgrammingLanguages.Models;
using Core.Application.Requests;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProgrammingLanguages.Queries.GetListProgrammingLanguage
{
    public class GetListProgrammingLanguageQuery:IRequest<ProgrammingLanguageListModel>
    {
        public PageRequest PageRequest {get; set; }
    }
}
