using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class RoleController : ApiController
    {
        ApplicationDbContext context = new ApplicationDbContext();

        [HttpGet]
        public IQueryable<RoleModels> GetRoles()
        {
            return context.RoleModels;
        }

        //[ResponseType(typeof(RoleModels))]
        [HttpGet]
        public IHttpActionResult GetRoles(int id)
        {
            RoleModels role = context.RoleModels.Find(id);
            if (role != null)
            {
                return Ok(role);
            }
            return NotFound();
        }

        //[ResponseType(typeof(RoleModels))]
        [HttpPost]
        public IHttpActionResult Post(RoleModels role)
        {
            if (!string.IsNullOrWhiteSpace(role.Name))
            {
                context.RoleModels.Add(role);
                var result = context.SaveChanges();
                if (result > 0)
                {
                    return Ok(role);
                }
            }
            return BadRequest();
        }

        //[ResponseType(typeof(void))]
        [HttpPut]
        public IHttpActionResult Put(int id, RoleModels role)
        {
            var put = context.RoleModels.Find(id);
            if (put != null)
            {
                if (!string.IsNullOrWhiteSpace(role.Name))
                {
                    put.Name = role.Name;
                    context.Entry(put).State = EntityState.Modified;
                    var result = context.SaveChanges();
                    if (result > 0)
                    {
                        return Ok(put);
                    }
                }
                return BadRequest();
            }
            return NotFound();                                     
        }

        //[ResponseType(typeof(RoleModels))]
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var role = context.RoleModels.Find(id);
            if (role != null)
            {
                context.RoleModels.Remove(role);
                context.SaveChanges();
                return Ok(role);
            }
            return BadRequest();
        }
    }
}
