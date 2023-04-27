using BrandHub.Map.Models;
using BrandHub.Map.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brandhub.Business.Interface
{
    public interface IAuthenticationService
    {
        public Task<string> LoginAsync(ValidatingLoginDto Newuser);

    }
}
