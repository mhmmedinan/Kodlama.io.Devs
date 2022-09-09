using Application.Features.GithubAddresses.Dtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.GithubAddresses.Commands.CreateGithubAddress
{
    public class CreateGithubAddressCommandValidator:AbstractValidator<CreatedGithubAddressDto>
    {
        public CreateGithubAddressCommandValidator()
        {
            RuleFor(g => g.Name).NotEmpty();
            RuleFor(g => g.UserId).NotEmpty();
        }
    }
}
