﻿using Business.Abstract;
using Core.Entities.Concrete;
using Entities.Concrete;
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
    public class UsersController : ControllerBase
    {
        IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("getclaims")]
        public IActionResult GetClaims(User user)
        {
            var result =_userService.GetClaims(user);
            if (result.ResultStatus==0)
            {
                return Ok(result.Data);
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpPost("add")]
        public IActionResult Add(User user)
        {
            var result = _userService.Add(user);
            if (result.ResultStatus==0)
            {
                return Ok("Eklendi..");
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _userService.GetAll();
            if (result.ResultStatus==0)
            {
                return Ok("Görüntülendi...");
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
