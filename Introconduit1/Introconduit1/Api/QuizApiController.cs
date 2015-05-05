using Introconduit1.Models;
using Introconduit1.MvcForumIdentity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Introconduit1.Controllers
{
    public class QuizApiController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<Quiz> Get()
        {
            IdentityDbContext context = new IdentityDbContext();
            return context.Quiz;
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public string Post([FromBody]IEnumerable<QuizModel> questions)
        {
            string message = "";
            var truescore = questions.Count(x => x.Anwser.HasValue && x.Anwser.Value);
            var falsescore = questions.Count(x => x.Anwser.HasValue && !x.Anwser.Value);

            if (truescore >= 8)
            {
                message = "I";
            }
            if (falsescore >= 8)
            {
                message = "E";
            }


            if ((truescore >= 6 && truescore < 8) || (falsescore >= 6 && falsescore < 8))
            {
                message = "E/I";
            }

            return message;
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}