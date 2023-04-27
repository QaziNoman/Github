using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrandHub.Map.Models
{
    public class UserModel
    {

        
            public string Username { get; set; }
      
        public string Password { get; set; }
            public string result { get; set; }
            public string errText { get; set; }
            public string errDetail { get; set; }
            public bool allowDispatch { get; set; }
            public bool allowGoodsIn { get; set; }
            public bool allowReturns { get; set; }
            public bool allowInventoryControl { get; set; }
            public bool allowEscalation { get; set; }
            public bool allowSecurity { get; set; }
        public int typeId { get; set; }
    }
    }



