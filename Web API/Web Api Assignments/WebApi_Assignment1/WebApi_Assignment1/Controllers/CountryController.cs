using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi_Assignment1.Models;

namespace WebApi_Assignment1.Controllers
{
    [RoutePrefix("api/User")]
    public class CountryController : ApiController
    {
        List<Country> countrylist = new List<Country>()
        {
            new Country{ID=1, CountryName="India", Capital="Delhi" },
            new Country{ID=2, CountryName="Australia", Capital="Canberra" },
            new Country{ID=3, CountryName="England", Capital="Londan" },
            new Country{ID=4, CountryName="New zealand", Capital="Wellington" },
            new Country{ID=5, CountryName="Southafrica", Capital="Capetown" },
        };

        [HttpGet]
        [Route("All")]
        public IEnumerable<Country> Get()
        {
            return countrylist;
        }

     
        [HttpGet]
        [Route("ByID")]
        public IHttpActionResult GetByID(int cid)
        {
            var country = countrylist.Find(c => c.ID == cid);
            if (country == null)
            {
                return NotFound();
            }
            return Ok(country);
        }

        [HttpGet]
        [Route("GetName")]
        public IHttpActionResult GetPersonByName(int id)
        {
            string uname = countrylist.Where(c => c.ID == id).SingleOrDefault()?.CountryName;
            if (uname == null)
            {
                return NotFound();
            }
            return Ok(uname);
        }


        [HttpPost]
        [Route("post")]
        public Country  Post([FromBody] Country c)
        {
            countrylist.Add(c);
            return c;
        }

        [HttpPut]
        [Route("updatecountry")]
        public void Put(int id, [FromUri] Country c)
        {
            countrylist[id - 1] = c;

        }

        [Route("del")]
        public void Delete(int id)
        {
            countrylist.RemoveAt(id - 1);
        }

    }
}
