﻿using Mango.Services.AuthAPI.Models.Dto;

namespace Mango.Services.AuthAPI.Service.IService
{
	public interface IAuthService
	{
		Task<string> Register(RegistrationRequestDto registerationRequestDto);
		Task<LoginResponseDto> Login(LoginRequestDto loginRequestDto);

	}
}
