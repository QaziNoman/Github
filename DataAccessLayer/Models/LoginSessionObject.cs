using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrandHub.Map.Models
{
    public class LoginSessionObject
    {
        public int counter { get; set; }
        public string PalletNo { get; set; }
        public String Username { get; set; }
        public bool allowDispatch { get; set; }
        public bool allowGoodsIn { get; set; }
        public bool allowReturns { get; set; }
        public bool allowInventoryControl { get; set; }
        public bool allowEscalation { get; set; }
        public bool allowSecurity{ get; set; }
    }
}
