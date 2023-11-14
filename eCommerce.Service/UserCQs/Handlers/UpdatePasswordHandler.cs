using eCommerce.Domain.Models;
using eCommerce.Service.User.Commands;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Service.User.Handlers;

public class UpdatePasswordHandler : IRequestHandler<UpdatePasswordCommand, IdentityResult>
{
    private readonly UserManager<ApiUser> userManager;
    public UpdatePasswordHandler(UserManager<ApiUser> userManager)
    {
        this.userManager = userManager;
    }
    public async Task<IdentityResult> Handle(UpdatePasswordCommand request, CancellationToken cancellationToken)
    {
        var user = await userManager.FindByEmailAsync(request.Dto.Email);
        return await userManager.ResetPasswordAsync(user, request.Dto.Token, request.Dto.newPassword);
    }
}
