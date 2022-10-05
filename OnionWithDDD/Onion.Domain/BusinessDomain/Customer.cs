using Onion.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onion.Domain.BusinessDomain
{
    public class Customer
    {
        #region Private Fields
        private List<CustomerContact> _customerContacts;
        #endregion

        #region Constructors
        public Customer( string name)
        {
            this.Name = name;
            this.CustomerStatus = CustomerStatus.Pending;
        }

        #endregion

        #region Properties

        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public Address Address { get; private set; }
        public CustomerStatus CustomerStatus { get; private set; }

        public IReadOnlyCollection<CustomerContact> CustomerContacts => _customerContacts;

        #endregion

        #region Domain Methods

        public void ModifyName(string name) 
        {
            this.Name = name;
        }

        public void ActivateCustomer() 
        {
            this.CustomerStatus = CustomerStatus.Active;
        }

        public void SuspendCustomer()
        {
            this.CustomerStatus = CustomerStatus.Suspended;
        }

        public void SetCustomerAddess(Address address) 
        {
            this.Address = address;
        }

        public void AddContact(string name, string contactType, string contactInfo) 
        {
            if(_customerContacts == null)
                _customerContacts = new List<CustomerContact>();

            _customerContacts.Add(new CustomerContact(name, contactType, contactInfo));
        }

        public void RemoveContact(Guid id) 
        {
            if (_customerContacts == null)
                throw new InvalidOperationException("No Contacts");

            CustomerContact customerContact = _customerContacts.FirstOrDefault(c => c.Id == id);

            if(customerContact != null)
                _customerContacts.Remove(customerContact);
        }

        public void RemoveAllContacts() 
        {
            _customerContacts.Clear();
        }

        #endregion
    }

    public record Address (string Street, string City, string State, string Country, string Zipcode);

   
}
