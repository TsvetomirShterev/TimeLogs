﻿using Microsoft.AspNetCore.Mvc;
using TimeLogs.Services.Dto.Users;
using TimeLogs.Services.Services.Users;

namespace TimeLogs.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly IUserService userService;
    public UsersController(IUserService userService)
    {
        this.userService = userService;
    }

    [HttpPost]
    public ActionResult<CreateUserModel> CreateUser([FromForm] CreateUserModel createUserRequest)
    {
        var createdUser = this.userService.CreateUser(createUserRequest);

        if (createdUser == null)
        {
            return BadRequest();
        }

        return Created("api/[controller]", createUserRequest);
    }
    
    [HttpGet]
    public ActionResult<ReadUserModel> GetUsers([FromQuery] int page = 1, [FromQuery] int itemsPerPage = 10, [FromQuery] DateTime? fromDate = null, [FromQuery] DateTime? toDate = null)
    {
        var users = this.userService.GetUsers(page, itemsPerPage, fromDate, toDate);

        return Ok(users);
    }

    [HttpGet("Count")]
    public ActionResult<int> GetUsersCount([FromQuery] DateTime? fromDate = null, [FromQuery] DateTime? toDate = null)
    {
        var userCount = this.userService.GetUsersCount(fromDate, toDate);

        return Ok(userCount);
    }
}
