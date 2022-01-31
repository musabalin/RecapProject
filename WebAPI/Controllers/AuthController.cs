using Business.Abstract;
using Business.Concrete;
using Core.Utilities.Results;
using Entities.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("Login")]
        public IActionResult Login(UserForLoginDto userForLoginDto)
        {
            var userToLogin = _authService.Login(userForLoginDto);
            if (userToLogin.ResultStatus!= ResultStatus.Success)
            {
                return BadRequest("kullanıcı bulunamadı....");
            }
            var result = _authService.CreateAccessToken(userToLogin.Data);
            if (result.ResultStatus==ResultStatus.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest("İşlem Başarısız..");
        }
        [HttpPost("Register")]
        public IActionResult Register(UserForRegisterDto userForRegisterDto)
        {
            var userToRegister = _authService.UserExists(userForRegisterDto.Email);
            if (userToRegister.ResultStatus!=ResultStatus.Success)
            {
                return BadRequest();
            }
            var registerResult = _authService.Register(userForRegisterDto, userForRegisterDto.Password);
            var result = _authService.CreateAccessToken(registerResult.Data);
            if (result.ResultStatus==ResultStatus.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest();
        }


    }
}
