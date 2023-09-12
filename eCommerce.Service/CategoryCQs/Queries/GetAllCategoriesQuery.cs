using eCommerce.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Service.CategoryCQs.Queries;

public record GetAllCategoriesQuery: IRequest<List<Category>>;
