using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onion.Domain.BusinessDomain
{
    public class CustomerContact
    {
        public CustomerContact(string name, string contactType, string contactInfo)
        {
            Name = name;
            ContactType = contactType;
            ContactInfo = contactInfo;
        }

        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string ContactType { get; private set; }
        public string ContactInfo { get; private set; }

    }
}
