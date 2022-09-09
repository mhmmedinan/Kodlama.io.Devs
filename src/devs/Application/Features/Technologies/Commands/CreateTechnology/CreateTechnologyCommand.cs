using Application.Features.Technologies.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Technologies.Commands.CreateTechnology
{
    public class CreateTechnologyCommand:IRequest<CreatedTechnologyDto>
    {
        public string Name { get; set; }
        public int ProgrammingLanguageId { get; set; }
    }
}
