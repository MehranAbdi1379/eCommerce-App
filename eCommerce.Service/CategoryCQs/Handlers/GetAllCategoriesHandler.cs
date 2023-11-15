using eCommerce.Domain.Models;
using eCommerce.Domain.Repositories;
using eCommerce.Repository.Main;
using eCommerce.Service.CategoryCQs.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Service.CategoryCQs.Handlers
{
    public class GetAllCategoriesHandler : IRequestHandler<GetAllCategoriesQuery, List<Category>>
    {
        private readonly ICategoryRepository categoryRespository;
        public GetAllCategoriesHandler(ICategoryRepository categoryRespository)
        {
            this.categoryRespository = categoryRespository;
        }

        public Task<List<Category>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(categoryRespository.GetAll());
        }
    }
}
