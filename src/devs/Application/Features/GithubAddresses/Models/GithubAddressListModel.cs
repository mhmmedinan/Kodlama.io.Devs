using Application.Features.GithubAddresses.Dtos;
using Core.Persistence.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.GithubAddresses.Models
{
    public class GithubAddressListModel:BasePageableModel
    {
        public IList<GithubAddressListDto> Items { get; set; }
    }
}
