using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TNS_DataModels;
using TNS_WebAPI.Data.TNS_API.Data;
using System.Text.Json;

namespace TNS_WebAPI.Controllers
{
    public class EquipmentController : ApiController
    {
        private TNS_Context _context;
        // GET: api/Equipment
        public EquipmentController()
        {
            _context = new TNS_Context();
        }
        public IEnumerable<Equipment> GetWithType(int typeId)
        {
            return _context.Equipments.Where(p => p.TypeId == typeId);
        }
        public IEnumerable<Equipment> Get()
        {
            return (_context.Equipments);
        }

        // GET: api/Equipment/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Equipment
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Equipment/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Equipment/5
        public void Delete(int id)
        {
        }
    }
}
