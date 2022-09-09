using Application.Features.Technologies.Models;
using Core.Application.Requests;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Technologies.Queries.GetListTechnology
{
    public class GetListTechnologyQuery:IRequest<TechnologyListModel>
    {
        public PageRequest PageRequest { get; set; }
    }
}
