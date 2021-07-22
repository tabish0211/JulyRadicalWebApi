using SMS_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SMS_API.Controllers
{
    public class StudentAPIController : ApiController
    {
        //private static List<Student> students = new List<Student>();

        private static StudentDbContext contxt = new StudentDbContext();

        // POST http://localhost:58025/api/StudentAPI
        public void Post([FromBody]Student student)
        {
            contxt.students.Add(student);//In memory
            contxt.SaveChanges();//It will transfer your object(student) to DB
           // contxt.Dispose();
        }

        // GET http://localhost:58025/api/StudentAPI
        public IEnumerable<Student> Get()
        {
            return contxt.students.ToList();
        }

        ////// GET http://localhost:58025/api/StudentAPI/1002
        public Student Get(int id)
        {
            return contxt.students.Where(s => s.Id == id).FirstOrDefault();
        }


        //// PUT http://localhost:58025/api/StudentAPI/1002

        public void Put(int id, [FromBody]Student student)
        {
            var existingObject = contxt.students.Where(s => s.Id == id).FirstOrDefault();

            if (existingObject != null)
            {

                existingObject.Name = student.Name;
                existingObject.Class = student.Class;
            }


            contxt.SaveChanges();

           
           


        }


        ////// DELETE  http://localhost:58025/api/StudentAPI/1002
        public void Delete(int id)
        {
            var existingObject = contxt.students.Where(s => s.Id == id).FirstOrDefault();

            if (existingObject != null)
            {
                contxt.students.Remove(existingObject);
                contxt.SaveChanges();
            }
        }

        ~StudentAPIController()
        {

            contxt.Dispose();
        }

    }
}




//Teacher---TID,TNAme,Tdesg--GET,GET/TID,POST/PUT/DELETE---Inmemory