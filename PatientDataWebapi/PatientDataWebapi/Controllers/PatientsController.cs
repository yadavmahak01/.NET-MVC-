using MongoDB.Bson;
using MongoDB.Driver;
using PatientDataWebapi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PatientDataWebapi.Controllers
{
    public class PatientsController : ApiController
    {
        MongoCollection<Patient> _patients;
        public PatientsController()
        {
            _patients = PatientDb.Open();

        }
        //for info in the request of /api/aptients
        public IEnumerable<Patient> Get()
        {
            return _patients.FindAll();
        }

        public IHttpActionResult Get(string id)
        {
            var patient = _patients.FindOneById(ObjectId.Parse(id));
            if (patient == null)
            {
                return NotFound();
                    //for HttpResponseMessage(404) - Request.CreateErrorResponse(HttpStatusCode.NotFound,"Patient not found");
            }
            return Ok(patient);
                //Request.CreateResponse(patient);-202 ok

        }
        //when using httpResponseMessage IHttpActionResult can be used
        [Route("api/patients/{id}/medications")]
        public IHttpActionResult GetMedications(string id)
        {
            var patient = _patients.FindOneById(ObjectId.Parse(id));
            if (patient == null)
            {
                return NotFound();
            }
            return Ok(patient.Medications);

        }
    }

}
