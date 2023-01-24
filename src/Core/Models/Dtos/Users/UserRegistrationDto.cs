﻿using System.ComponentModel.DataAnnotations;

namespace Core
{
    public class UserRegistrationRequest : BaseRequest
    {
        public string? FirstName { get; init; }
        public string? LastName { get; init; }
        [Required(ErrorMessage = "Username is required")]
        public string? UserName { get; init; }
        [Required(ErrorMessage = "Password is required")]
        public string? Password { get; init; }
        public string? Email { get; init; }
        public string? PhoneNumber { get; init; }
        public bool CreateFash {get;set;} = true;
        public string? RoleName {get;set;}
        public string? RoleId {get;set;}
    }
}