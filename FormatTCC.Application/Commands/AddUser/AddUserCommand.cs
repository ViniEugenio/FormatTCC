﻿using FormatTCC.Application.ViewModels;
using MediatR;

namespace FormatTCC.Application.Commands.AddUser
{
    public class AddUserCommand : IRequest<InputResultViewModel>
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmedPassword { get; set; }
    }
}