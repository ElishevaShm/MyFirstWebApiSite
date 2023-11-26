﻿using AutoMapper;
using DTO;
using Entity;
using Microsoft.AspNetCore.Mvc;
using Service;
using System.Text.Json;


//using (StreamReader reader = System.IO.File.OpenText("M:\\web-api\\userFile.txt"));
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyFirstWebApiSite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class userController : ControllerBase
    {
        private readonly IuserService _userService;
        private readonly IMapper _mapper;

        public userController(IuserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }


        // POST: api/<userController>
        [HttpPost("login")]
        public async Task<ActionResult<UserLoginDTO>> login([FromBody] UserLoginDTO userLogin)
        {

            User user =await _userService.getUserByEmailAndPassword(userLogin.UserName, userLogin.Password);
            
            if (user != null) 
            {
                UserLoginDTO userCreate = _mapper.Map<User, UserLoginDTO>(user);
                return Ok(userCreate);
            }
            return NoContent();

        }

        // GET api/<userController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<UserDTO>>> Get([FromRoute]int id)
        {
            User user = await _userService.getUserById(id);
            UserDTO userDTO = _mapper.Map<User, UserDTO>(user);
            if (user == null)
                return NoContent();
            return Ok(userDTO);
            
        }


        // POST api/<userController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] User user)
        {

            try
            {
                User newUser = await _userService.addUser(user);
                

                if (newUser == null)
                    return BadRequest();
                return CreatedAtAction(nameof(Get), new { id = user.UserId }, newUser);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost("check")]
        public int Check([FromBody] string pwd)
        {
            return _userService.checkPassword(pwd);
        }

        // PUT api/<userController>/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] User userToUpdate)
        {

            try
            {
               await _userService.updateUser(id, userToUpdate);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
