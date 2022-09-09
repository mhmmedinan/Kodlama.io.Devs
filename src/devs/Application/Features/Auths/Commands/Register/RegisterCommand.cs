using Application.Features.Auths.Dtos;
using Core.Security.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Auths.Commands.Register
{
    public class RegisterCommand:IRequest<RegisterDto>
    {
        public UserForRegisterDto UserForRegisterDto { get; set; }
        public string ipAddress { get; set; }
    }
}
