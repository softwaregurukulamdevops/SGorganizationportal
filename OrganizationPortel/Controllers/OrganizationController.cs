using Microsoft.AspNetCore.Mvc;
using OrganizationPortel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrganizationPortel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrganizationController : Controller
    {
        public readonly TrainingDBContext trainingDBContext;
        public OrganizationController(TrainingDBContext _trainingDBContext)
        {
            trainingDBContext = _trainingDBContext;
        }
        [HttpGet("GetOrganizationDetails")]
        public List<Organization> GetOrganizationDetails()
        {
            List<Organization> lstOrganization = new List<Organization>();
            try
            {
                lstOrganization = trainingDBContext.Organization.ToList();
                return lstOrganization;
            }
            catch (Exception ex)
            {
                lstOrganization = new List<Organization>();
                return lstOrganization;
            }
        }
        [HttpPost("AddOrganization")]
        public string AddOrganization(Organization organization)
        {
            string message = string.Empty;
            try
            {
                if (!string.IsNullOrEmpty(organization.OrganizationName))
                {
                    trainingDBContext.Add(organization);
                    trainingDBContext.SaveChanges();
                    message = "Organization added successfully";
                }
                else
                    message = "Organization Name required.";

            }
            catch (Exception ex)
            {
                message = ex.Message;
            }
            return message;
        }
    }
}
