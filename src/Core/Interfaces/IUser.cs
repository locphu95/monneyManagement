﻿using Core.Models.Dtos.Users;

namespace Core
{
    public interface IUser
    {
        Task<UpdateProfileRequestResponse> UpdateProfile(User userinfo,UpdateProfileRequest userForRegistration);
        
    }
}