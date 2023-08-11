﻿using System.Threading.Tasks;
using WareHouse.Application.Auth.Models;
using WareHouse.Application.Common.Exceptions;
using WareHouse.Application.Common.Interfaces;
using WareHouse.Domain.Entities;

namespace WareHouse.Application.Auth;

public class AuthService : IAuthService
{
    private readonly IGenericRepository<User> _userRepository;
    private readonly ITokenService _tokenService;

    public AuthService(
            IGenericRepository<User> userRepository,
            ITokenService tokenService)
    {
        _userRepository = userRepository;
        _tokenService = tokenService;
    }

    public async Task<SignInResultDto> SignInAsync(SignInDto signInDto)
    {
        if (string.IsNullOrEmpty(signInDto.Login))
        {
            throw new ValidationException("Login can't be null or empty");
        }

        if (string.IsNullOrEmpty(signInDto.Password))
        {
            throw new ValidationException("Password can't be null or empty");
        }

        var user = await _userRepository.FirstAsync(x => x.Login == signInDto.Login);
        if (user == null)
        {
            return new SignInResultDto
            {
                Succeeded = false,
                ErrorType = (int)AuthErrorType.UserNotFound
            };
        }

        if (user.Login == signInDto.Login && user.Password != signInDto.Password)
        {
            return new SignInResultDto
            {
                Succeeded = false,
                ErrorType = (int)AuthErrorType.WrongPassword
            };
        }

        return new SignInResultDto
        {
            Succeeded = true,
            Token = _tokenService.BuildToken(user)
        };
    }

    public async Task<SignUpResultDto> SignUpAsync(SignUpDto signUpDto)
    {
        if (string.IsNullOrEmpty(signUpDto.Login))
        {
            throw new ValidationException("Login can't be null or empty");
        }

        if (string.IsNullOrEmpty(signUpDto.Password))
        {
            throw new ValidationException("Password can't be null or empty");
        }

        if (string.IsNullOrEmpty(signUpDto.Name))
        {
            throw new ValidationException("Name can't be null or empty");
        }

        var user = await _userRepository.FirstAsync(x => x.Login == signUpDto.Login);
        if (user != null)
        {
            return new SignUpResultDto
            {
                Succeeded = false,
                ErrorType = (int)AuthErrorType.LoginAlreadyExists
            };
        }

        user = new User
        {
            Name = signUpDto.Name,
            Login = signUpDto.Login,
            Password = signUpDto.Password,
        };

        await _userRepository.CreateAsync(user);
        return new SignUpResultDto { Succeeded = true };
    }
}
