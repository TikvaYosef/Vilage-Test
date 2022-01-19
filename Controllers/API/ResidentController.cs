using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vilage.Models;

namespace Vilage.Controllers.API
{
    public class ResidentController : ApiController
    {
        private VilageDataContext datacontext = new VilageDataContext();


        // GET: api/Resident
        public IHttpActionResult Get()
        {

            List<Resident> listOfResidents = datacontext.Residents.ToList();
            return Ok(new { listOfResidents });
        }

        // GET: api/Resident/5
        public IHttpActionResult Get(int id)
        {
            try
            {
                Resident resident =  datacontext.Residents.Find(id);
                return Ok(resident);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
           
        }

        // POST: api/Resident
        public IHttpActionResult Post([FromBody] Resident obj)
        {
            try
            {
                datacontext.Residents.Add(obj);
                 datacontext.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
           
        }

        // PUT: api/Resident/5
        public IHttpActionResult Put(int id, [FromBody] Resident obj)
        {
            try
            {
                Resident resident =  datacontext.Residents.Find(id);
                resident.FirstName = obj.FirstName;
                resident.FatherName = obj.FatherName;
                resident.Gender = obj.Gender;
                resident.BornInVillage = obj.BornInVillage;
                resident.BirthDay = obj.BirthDay;
                 datacontext.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE: api/Resident/5
        public IHttpActionResult Delete(int id)
        {
            try
            {
                Resident resident = datacontext.Residents.Find(id);
                datacontext.Residents.Remove(resident);
                 datacontext.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
