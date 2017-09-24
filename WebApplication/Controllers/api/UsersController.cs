using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using WebApplication.Models;
using WebApplication.ViewModels;

namespace WebApplication.Controllers.web
{
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        private IAppRepository _repository;
        private ILogger _logger;

        public UsersController(IAppRepository repository, ILogger<UsersController> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        //// GET: api/values
        //[HttpGet]
        //public IActionResult Get()
        //{
        //    return BadRequest("Users unavailable");
        //}

        //// GET api/values/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "";
        //}

        // GET: User/Create
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]UserViewModel vm)
        {
            if (ModelState.IsValid)
            {
                var user = Mapper.Map<User>(vm);
                _repository.UserAdd(user);
                if (await _repository.SaveChangesAsync())
                {
                    return Created($"api/users/{vm.UserName}", vm);
                }
                else
                {
                    return BadRequest("Save failed");
                }

            }

            return BadRequest("Invalid data");
        }

        //// PUT api/values/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE api/values/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}