using eCommerce.Domain.Models;
using eCommerce.Service.Contracts.DTO;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Service.CategoryCQs.Queries
{
    public record GetAllSubCategoriesByParentIdQuery(IdDTO dto): IRequest<List<Category>>;
}
