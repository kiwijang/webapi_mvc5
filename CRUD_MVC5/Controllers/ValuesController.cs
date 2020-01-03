using CRUD_MVC5.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Mvc;

namespace CRUD_MVC5.Controllers
{
    public class ValuesController : ApiController
    {
        public ValuesController()
        {
        }

        private readonly TodoDbEntities _db = new TodoDbEntities();

        public ValuesController(TodoDbEntities db)
        {
            _db = db;
        }

        // GET api/values
        public async Task<IEnumerable<Todos>> Get()
        {
            var allTodos = await _db.Todos.ToListAsync();
            return allTodos;
        }

        // GET api/values/5
        public async Task<string> Get(int id)
        {
            var Todo = await _db.Todos.Where(x => x.Id == id).FirstOrDefaultAsync();
            var json = JsonConvert.SerializeObject(Todo);
            return json;
        }

        // POST api/values
        public async Task<int> Post(Todos todo)
        {
            if (todo.Event != null && todo.Event != "" && ModelState.IsValid)
            {
                Todos newTodo = new Todos() { Done = todo.Done, Event = todo.Event, TimeStamp = DateTime.Now };
                _db.Todos.Add(newTodo);
                var result = await _db.SaveChangesAsync();
                return result;
            }
            return 0;
        }

        // PUT api/values/5
        public async Task<int> Put(int id, [Bind(Include = "Done,Event")]Todos todo)
        {
            if (todo.Event != null && todo.Event != "" && ModelState.IsValid)
            {
                todo.Id = id; 
                _db.Entry(todo).State = EntityState.Modified;
                _db.Entry(todo).Property("TimeStamp").IsModified = false;
                var result = await _db.SaveChangesAsync();
                return result;
            }
            return 0;
        }

        // DELETE api/values/5
        public async Task<int> Delete(int id)
        {
            var existTodo = await _db.Todos.Where(x => x.Id == id).FirstOrDefaultAsync();
            _db.Todos.Remove(existTodo);
            var result = await _db.SaveChangesAsync();
            return result;
        }
    }
}
