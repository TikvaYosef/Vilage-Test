using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vilage.Models;

namespace Vilage.Controllers.API
{
    public class SeniorsController : ApiController
    {
        OldsDataContextDataContext datacontext = new OldsDataContextDataContext();

        // GET: api/Seniors
        public IHttpActionResult Get()
        {
            try
            {
                List<senior> listOfSeniors = datacontext.seniors.ToList();
                return Ok(new { listOfSeniors });
            }
            catch (SqlException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/Seniors/5
        public IHttpActionResult Get(int id)
        {
            try
            {
                senior senior = datacontext.seniors.First((item) => item.Id == id);
                return Ok(new { senior });
            }
            catch (SqlException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST: api/Seniors
        public IHttpActionResult Post([FromBody]senior obj)
        {
            try
            {
                datacontext.seniors.InsertOnSubmit(obj);
                datacontext.SubmitChanges();

                return Ok("add");
            }
            catch (SqlException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT: api/Seniors/5
        public IHttpActionResult Put(int id, [FromBody]senior obj)
        {
            try
            {
                senior senior = datacontext.seniors.First((item) => item.Id == id);
                senior.name = obj.name;
                senior.birtday = obj.birtday;
                senior.Seniority = obj.Seniority;
             
                datacontext.SubmitChanges();
                return Ok("Update");
            }
            catch (SqlException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE: api/Seniors/5
        public IHttpActionResult Delete(int id)
        {

            try
            {
                senior senior = datacontext.seniors.First((item) => item.Id == id);
                datacontext.seniors.DeleteOnSubmit(senior);
                datacontext.SubmitChanges();

                return Ok("Deleted");
            }
            catch (SqlException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
