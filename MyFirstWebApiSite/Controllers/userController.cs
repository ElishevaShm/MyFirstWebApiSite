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
        public ActionResult<IEnumerable<User>> Get([FromQuery] string userName, [FromQuery] string password)
        {

            User user = userService.getUserByEmailAndPassword(userName, password);
            if (user == null)
                return NoContent();
            return Ok(user);

        }

        // GET api/<userController>/5
        [HttpGet("{id}")]
        //public ActionResult<IEnumerable<User>> Get(int id)
        //{
        //         return Ok(user);
        //    return BadRequest();
        //}


        // POST api/<userController>
        [HttpPost]
        public IActionResult Post([FromBody] User user)
        {

            try
            {
                User newUser = userService.addUser(user);
                return CreatedAtAction(nameof(Get), new { id = user.userId }, user);
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
        public IActionResult Put(int id, [FromBody] User userToUpdate)
        {

            try
            {
                User newUser = userService.updateUser(id, userToUpdate);
                return Ok(newUser);
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
