using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrandHub.Map.Models.Dto
{
  public class ValidatingLoginDto
    {
        public string UserName { get; set; }
        public string stationID { get; set; }
        public string orderRef { get; set; }
        public int qty { get; set; }
        public string pin { get; set; }
    }
}
