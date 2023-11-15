using CleanArchitectureBase.Application.Customers.Commands.Create;
using CleanArchitectureBase.Application.Customers.Models;
using CleanArchitectureBase.Application.Interfaces;
using CleanArchitectureBase.Domin.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureBase.Application.Customers.Queries
{
    public class GetAllCustomerQuery : IRequest<List<CustomerDataDto>>
    {
        public class Handler : IRequestHandler<GetAllCustomerQuery, List<CustomerDataDto>>
        {
            private readonly IApplicationDbContext _context;

            public Handler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<List<CustomerDataDto>> Handle(GetAllCustomerQuery request, CancellationToken cancellationToken)
            {
                try
                {
                    var customer = await _context.Customer.Select(a=> new CustomerDataDto
                    {
                        Name = a.Name,
                        Email = a.Email,
                        Phone = a.Phone,
                    }).AsNoTracking().ToListAsync();

                    return customer;
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
        }
    }
}
