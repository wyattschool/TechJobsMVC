﻿using System;
using System.Collections.Generic;
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
            ViewBag.columns = ListController.ColumnChoices;
            List<Job> jobs;
            if (searchType == "All")
			{
                jobs = JobData.FindByValue(searchTerm);
			}

            if (searchType == "Employer")
			{
                jobs = JobData.FindByColumnAndValue(searchType, searchTerm);
            }

            if (searchType == "Postion")
            {
                jobs = JobData.FindByColumnAndValue(searchType, searchTerm);
            }

            if (searchType == "CoreCompetency")
            {
                jobs = JobData.FindByColumnAndValue(searchType, searchTerm);
            }
			else
			{
                jobs = null;
			}

            ViewBag.jobs = jobs;
            return View("Index");
        }
    }
}
