using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brandhub.Business.Interface
{
    public interface IPalletServices
    {



        public Task<string> SetImageAsync(string ReferenceNo, string question, string userName, string image);

        public Task<string> SetAnswerAsync(string ReferenceNo, string question, string userName, string image);


    }
}
