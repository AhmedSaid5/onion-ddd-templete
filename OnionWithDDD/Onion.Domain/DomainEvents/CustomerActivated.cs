using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Onion.Domain.DomainEvents
{
    public class CustomerActivated : INotification
    {
        public Guid Id { get; set; }

    }
}
