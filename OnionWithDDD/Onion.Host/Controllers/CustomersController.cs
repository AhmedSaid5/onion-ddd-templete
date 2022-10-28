using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Onion.App.CommandHandelers;
using Onion.Core.Commands.Customers;
using Onion.Core.Models.ViewModels;
using Onion.App.Queries.Customers;
using Onion.Core.Models.Infrastructure;
using Onion.Core.Models.Enums;

namespace Onion.Host.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {

        [HttpPost]
        public async Task<Guid> PostAsync([FromServices] IMediator _mediator, CreateCustomerCommand customer)
            => await _mediator.Send(customer);

        [HttpPut]
        public async Task<bool> PutAsync([FromServices] IMediator _mediator, UpdateCustomerCommand customer)
            => await _mediator.Send(customer);

        [HttpDelete]
        public async Task<bool> DeleteAsync([FromServices] IMediator _mediator, DeleteCustomerCommand customer)
            => await _mediator.Send(customer);


        [HttpPut("{customerId}/Activate")]
        public async Task<bool> ActivateAsync([FromServices] IMediator _mediator, [FromRoute] Guid customerId)
            => await _mediator.Send(new ActivateCustomerCommand { Id = customerId });

        [HttpPut("{customerId}/Suspend")]
        public async Task<bool> SuspendAsync([FromServices] IMediator _mediator, [FromRoute] Guid customerId)
           => await _mediator.Send(new SuspendCustomerCommand { Id = customerId });


        [HttpGet("{id}")]
        public async Task<CustomerVm> GetAsync([FromServices] IMediator _mediator, [FromRoute] Guid id)
          => await _mediator.Send(new GetCustomerByIdCommand { Id = id });


        [HttpGet("{currentPage}/{pageSize}")]
        public async Task<PagedListModel<CustomerVm>> GetAsync([FromServices] IMediator _mediator,
            [FromRoute] int currentPage,
            [FromRoute] int pageSize,
            [FromQuery] string? sortBy,
            [FromQuery] SearchOrders? sortOrder,
            [FromQuery] Guid? id,
            [FromQuery] string? name,
            [FromQuery] CustomerStatuses? customerStatuses
            )
            => await _mediator.Send(new GetCustomerBySearchCommand 
            { 
                Id = id,
                Name = name,
                CustomerStatus = customerStatuses,
                CurrentPage = currentPage,
                PageSize = pageSize,
                SearchOrder = sortOrder ?? SearchOrders.Asc,
                SortField = sortBy              
            });


    }
}
