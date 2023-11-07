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
        IuserService userService;

        public userController(IuserService iuserService)
        {
            userService = iuserService;
        }


        // GET: api/<userController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> Get([FromQuery] string userName, [FromQuery] string password)
        {

           User user =await userService.getUserByEmailAndPassword(userName, password);
            if (user == null)
                return NoContent();
            return Ok(user);

        }

        // GET api/<userController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<User>>> Get([FromRoute]int id)
        {
            User user = await userService.getUserById(id);
            if (user == null)
                return NoContent();
            return Ok(user);
            
        }


        // POST api/<userController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] User user)
        {

            try
            {
                User newUser = await userService.addUser(user);
                if (newUser == null)
                    return BadRequest();
                return CreatedAtAction(nameof(Get), new { id = newUser.UserId }, newUser);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost("check")]
        public int Check([FromBody] string pwd)
        {
            return userService.checkPassword(pwd);
        }
        // PUT api/<userController>/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] User userToUpdate)
        {

            try
            {
               await userService.updateUser(id, userToUpdate);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        // DELETE api/<userController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
