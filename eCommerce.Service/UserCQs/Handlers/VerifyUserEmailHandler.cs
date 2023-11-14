using eCommerce.Domain.Models;
using eCommerce.Service.User.Commands;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Service.User.Handlers
{
    public class VerifyUserEmailHandler : IRequestHandler<VerifyUserEmailCommand, IdentityResult>
    {
        private readonly UserManager<ApiUser> userManager;
        public VerifyUserEmailHandler(UserManager<ApiUser> userManager)
        {
            this.userManager = userManager;
        }
        public async Task<IdentityResult> Handle(VerifyUserEmailCommand request, CancellationToken cancellationToken)
        {
            var user = await userManager.FindByIdAsync(request.UserId);
            return await userManager.ConfirmEmailAsync(user, request.Token);
        }
    }
}
