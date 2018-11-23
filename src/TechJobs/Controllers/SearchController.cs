﻿using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TechJobs.Models;

namespace TechJobs.Controllers
{
    public class SearchController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.columns = ListController.columnChoices;
            ViewBag.title = "Search";
            return View();
        }

        // TODO #1 - Create a Results action method to process 
        // search request and display results
        
        public IActionResult Results(string searchType, string searchTerm)
         {
             if (searchType.Equals("all"))
             {
                 List<Dictionary<string, string>> Jobs = JobData.FindByValue(searchTerm);
                 ViewBag.title = "Search In All Jobs";
                 ViewBag.Jobs = Jobs;
                 return View();
             }
             else
             {
                List<Dictionary<string, string>> Jobs = JobData.FindByColumnAndValue(searchType, searchTerm);
                ViewBag.title = "Search In"+ searchType + ":";
                ViewBag.Jobs = Jobs;
                return View();
             }

         }
    }
}
