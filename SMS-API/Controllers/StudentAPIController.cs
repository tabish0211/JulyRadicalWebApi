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
        private static List<Student> students = new List<Student>();

        // POST http://localhost:58025/api/StudentAPI
        public void Post([FromBody]Student student)
        {
            students.Add(student);
        }

        // GET http://localhost:58025/api/StudentAPI
        public IEnumerable<Student> Get()
        {
            return students;
        }

        //// GET http://localhost:58025/api/StudentAPI/1002
        public Student Get(int id)
        {
            return students.Where(s => s.Id == id).FirstOrDefault();
        }


        //// PUT http://localhost:58025/api/StudentAPI/1002
        
        public void Put(int id, [FromBody]Student student)
        {
            var existingObject = students.Where(s => s.Id == id).FirstOrDefault();

            if (existingObject!=null)
            {

                existingObject.Name = student.Name;
                existingObject.Class = student.Class;
            }

            students.Remove(students.Where(s => s.Id == id).FirstOrDefault());
            //1002--Rakesh---1--existingObject----
            //10002--Mahesh---2
            students.Add(existingObject);


        }


        //// DELETE  http://localhost:58025/api/StudentAPI/1002
        public void Delete(int id)
        {
            var existingObject = students.Where(s => s.Id == id).FirstOrDefault();

            if (existingObject != null)
            {
                students.Remove(students.Where(s => s.Id == id).FirstOrDefault());
            }
        }
    }
}




//Teacher---TID,TNAme,Tdesg--GET,GET/TID,POST/PUT/DELETE---Inmemory