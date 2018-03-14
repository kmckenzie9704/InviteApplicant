using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InviteApplicant.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;


namespace InviteApplicant.Controllers
{
    [Route("api/InviteApplicant")]
    public class InviteApplicantController : Controller
    {
        private DatabaseContext _context;

        public InviteApplicantController(DatabaseContext context)
        {
            _context = context;
        }

        // GET api/InviteApplicant
        [HttpGet]
        public string Get()
        {
            string strInviteApplicant = "Invite Applicant to register for the system.";

            return strInviteApplicant;

        }

        // POST api/InviteApplicant
        [HttpPost]
        public string InviteNewApplicant([FromBody]Applicant applicant)
        {
            string strReturn = string.Empty;
            string strUniqueCode = applicant.appUniqueCode;
            string strEmail = applicant.appEmail;

            strReturn = Invite(strUniqueCode, strEmail);
            return strReturn;
        }

        private string Invite(string strUniqueCode, string strEmail)
        {
            string strReturn = string.Empty;
            using (_context)
            {
                Applicant newApplicant = new Applicant
                {
                    appEmail = strEmail,
                    appUniqueCode = strUniqueCode
                };
                _context.Applicants.Add(newApplicant);
                _context.SaveChanges();

                strReturn = "Created";
                return strReturn;
            }
        }
    }

}
