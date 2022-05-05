using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TechJobsMVC.Data;
using TechJobsMVC.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TechJobsMVC.Controllers
{
    public class SearchController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            ViewBag.columns = ListController.ColumnChoices;
            ViewBag.jobs = null;
            return View();
        }

        // TODO #3: Create an action method to process a search request and render the updated search view. 
        [HttpPost]
        public IActionResult Results(string searchType, string searchTerm)
		{
            if (searchTerm == null)
			{
                searchTerm = "nothing";
			}
            ViewBag.columns = ListController.ColumnChoices;
            List<Job> jobs;
            if (searchType == "all")
			{
                jobs = JobData.FindByValue(searchTerm);
			}

            else if (searchType == "employer")
			{
                jobs = JobData.FindByColumnAndValue(searchType, searchTerm);
            }

            else if (searchType == "positionType")
            {
                jobs = JobData.FindByColumnAndValue(searchType, searchTerm);
            }

            else if (searchType == "coreCompetency")
            {
                jobs = JobData.FindByColumnAndValue(searchType, searchTerm);
            }
            else if (searchType == "location")
			{
                jobs = JobData.FindByColumnAndValue(searchType, searchTerm);
            }
			else
			{
                jobs = null;
			}

            /*if (jobs == null)
			{
                Debug.WriteLine("No jobs were found for search type: " + searchType + " and search term " + searchTerm);
            }
            */

            ViewBag.jobs = jobs;
            return View("Index");
        }
    }
}
