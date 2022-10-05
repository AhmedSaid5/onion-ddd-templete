using Onion.Core.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onion.Core.Models.ViewModels
{
    public class CustomerVm
    {

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string Zipcode { get; set; }

        public CustomerStatuses CustomerStatus { get; set; }

        List<CustomerContactVm> CustomerContacts { get; set; }
    }

    public class CustomerContactVm
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string ContactType { get; set; }
        public string ContactInfo { get; set; }
    }
}
