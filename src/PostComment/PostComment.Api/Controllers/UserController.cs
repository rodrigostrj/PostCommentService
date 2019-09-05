namespace PostComment.Api.Controllers
{
    using System;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using PostComment.Core.Domain;
    using PostComment.Core.Service;

    [Route("api/Users")]
    public class UsersController : ControllerBase
    {
    //    private IUsersService usersService;

    //    public UsersController(IUsersService usersService)
    //    {
    //        this.usersService = usersService;
    //    }

    //    [HttpPost]
    //    public async Task<IActionResult> CreateUser(User user)
    //    {
    //        await this.usersService.CreateUser(user);
    //        return StatusCode(201);
    //    }

    //    [HttpGet]
    //    public async Task<IActionResult> GetUsers()
    //    {
    //        var users = await this.usersService.GetAllUsers();
    //        return Ok(users);
    //    }

    //    [HttpGet("/{id}")]
    //    public async Task<IActionResult> GetUser(int id)
    //    {
    //        var user = await this.usersService.GetUser(id);
    //        return Ok(user);
    //    }
    }
}

