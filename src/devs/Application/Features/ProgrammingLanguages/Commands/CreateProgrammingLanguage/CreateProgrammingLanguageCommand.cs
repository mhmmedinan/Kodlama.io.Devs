using Application.Features.ProgrammingLanguages.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProgrammingLanguages.Commands.CreateProgrammingLanguage
{
    public class CreateProgrammingLanguageCommand:IRequest<CreatedProgrammingLanguageDto>
    {
        public string Name { get; set; }
    }
}
