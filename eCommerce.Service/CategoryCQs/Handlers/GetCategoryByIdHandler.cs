using eCommerce.Domain.Models;
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
    public class GetCategoryByIdHandler : IRequestHandler<GetCategoryByIdQuery, Category>
    {
        private readonly ICategoryRepository categoryRespository;
        public GetCategoryByIdHandler(ICategoryRepository categoryRespository)
        {
            this.categoryRespository = categoryRespository;
        }

        public Task<Category> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(categoryRespository.GetById(request.dto.Id));
        }
    }
}
