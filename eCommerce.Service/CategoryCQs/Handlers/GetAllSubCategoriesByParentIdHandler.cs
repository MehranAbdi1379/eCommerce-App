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
    public class GetAllSubCategoriesByParentIdHandler : IRequestHandler<GetAllSubCategoriesByParentIdQuery, List<Category>>
    {
        private readonly ICategoryRepository categoryRepository;
        public GetAllSubCategoriesByParentIdHandler(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        public Task<List<Category>> Handle(GetAllSubCategoriesByParentIdQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(categoryRepository.GetAllSubCategoriesByParentId(request.dto.Id));
        }
    }
}
