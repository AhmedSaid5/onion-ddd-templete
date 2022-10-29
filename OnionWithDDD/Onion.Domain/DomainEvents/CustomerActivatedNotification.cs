using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Onion.Domain.DomainEvents
{
    public class CustomerActivatedNotification : INotification
    {
        public CustomerActivatedNotification(Guid id, string customerName)
        {
            Id = id;
            CustomerName = customerName;
        }

        public Guid Id { get; private set; }
        public string CustomerName { get; set; }

    }
}
