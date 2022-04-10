using Dapper;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace TicSaludAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ActorController : Controller
    {
        private string _connection = @"Server=localhost; Database=sakila; Uid=root; Pwd=llGranmaestro64;";

        [HttpGet]
        public IActionResult GetAllActor()
        {
            IEnumerable<Models.Actor> lst = null;
            using (var db = new MySqlConnection(_connection))
            {
                var sql = "SELECT * FROM sakila.actor";
                lst = db.Query<Models.Actor>(sql);
            }
            return Ok(lst);
        }
        
        [HttpPost]
        public IActionResult InsertActor(Models.Actor actor)
        {
            int result = 0;
            using (var db = new MySqlConnection(_connection))
            {
                var sql = "insert into sakila.actor(first_name, last_name, last_update) " +
                    "values(@first_name, @last_name, @last_update)";
                result = db.Execute(sql, actor);
            }
            return Ok(result);
        }
        
        [HttpPut]
        public IActionResult EditActor(Models.Actor actor)
        {
            int result = 0;
            using (var db = new MySqlConnection(_connection))
            {
                var sql = "update sakila.actor set first_name = @first_name, last_name = @last_name, " +
                    "last_update = @last_update where actor_id = @actor_id ";
                result = db.Execute(sql, actor);
            }
            return Ok(result);
        }
    }
}
