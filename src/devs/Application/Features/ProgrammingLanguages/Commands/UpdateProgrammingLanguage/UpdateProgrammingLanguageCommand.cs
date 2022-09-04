using Application.Features.ProgrammingLanguages.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProgrammingLanguages.Commands.UpdateProgrammingLanguage
{
    public class UpdateProgrammingLanguageCommand:IRequest<UpdatedProgrammingLanguageDto>
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
