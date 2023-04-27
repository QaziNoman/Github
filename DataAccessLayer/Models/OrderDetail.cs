using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrandHub.Map.Models
{
  public class OrderDetail
    {
        public String OrderRef { get; set; }
        public bool fourWayEntryPalletUK { get; set; }
        public bool fourWayEntryPalletEU { get; set; }
        public bool chepPallet { get; set; }
        public bool euPallet { get; set; }
        public bool anyPallet { get; set; }
        public string palletType { get; set; }
        public bool specificLabel { get; set; }
        public bool customerNameOnLabel { get; set; }
        public bool palletWrapped { get; set; }
        public bool labelConfirmation { get; set; }

        public List<string>truePallet { get; set; }
    }
}
