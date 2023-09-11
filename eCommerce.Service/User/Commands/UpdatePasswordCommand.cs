using eCommerce.Service.Contracts.DTO;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Service.User.Commands;

public record UpdatePasswordCommand(ResetPasswordDTO Dto): IRequest<IdentityResult>;
