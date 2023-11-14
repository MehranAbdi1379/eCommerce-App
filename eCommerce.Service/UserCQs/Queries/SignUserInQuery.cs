using eCommerce.Service.Contracts.DTO;
using Framework.Authentication.Service;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Service.User.Queries;
public record SignUserInQuery(SignInDTO Dto) : IRequest<SignInInformationDTO>;
