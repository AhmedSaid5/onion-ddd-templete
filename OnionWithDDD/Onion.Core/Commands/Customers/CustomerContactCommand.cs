using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onion.Core.Commands.Customers
{
    public class CustomerContactCommand
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string ContactType { get; set; }
        public string ContactInfo { get; set; }
    }
}
