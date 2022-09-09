using Application.Features.GithubAddresses.Commands.CreateGithubAddress;
using Application.Features.GithubAddresses.Commands.UpdateGithubAddress;
using Application.Features.GithubAddresses.Dtos;
using Application.Features.GithubAddresses.Models;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.GithubAddresses.Profiles
{
    public class MappingProfiles:Profile
    {
        public MappingProfiles()
        {
            CreateMap<GithubAddress, CreatedGithubAddressDto>().ReverseMap();
            CreateMap<GithubAddress, CreateGithubAddressCommand>().ReverseMap();
            CreateMap<GithubAddress, DeletedGithubAddressDto>().ReverseMap();
            CreateMap<GithubAddress, UpdatedGithubAddressDto>().ReverseMap();
            CreateMap<GithubAddress, UpdateGithubAddressCommand>().ReverseMap();
            CreateMap<GithubAddress, GithubAddressListDto>().ReverseMap();
            CreateMap<IPaginate<GithubAddress>, GithubAddressListModel>().ReverseMap();
            CreateMap<GithubAddress, GithubAddressGetByUserIdDto>().ReverseMap();
        }
    }
}
