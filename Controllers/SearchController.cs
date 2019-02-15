using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using SearchDemo.Models;
using SearchDemo.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Search.Models;

namespace SearchDemo.Controllers
{
    public class SearchController : Controller
    {
        private ISearchService _searchService;
        public SearchController(ISearchService searchService)
        {
            _searchService = searchService;
        }
        
        [HttpGet]
        public IActionResult Search(string term, bool fuzzy = true)
        {
            SearchPayload payload = new SearchPayload();
            payload.Text = term;
            return Json(_searchService.Search("cosmos-products-index", payload, fuzzy));
        }
        
        [HttpGet]
        public IActionResult Suggest(string term, bool fuzzy = true)
        {
            DocumentSuggestResult suggestResult = _searchService.Suggest("cosmos-products-index", "suggester", term, fuzzy); 
            // Convert the suggest query results to a list that can be displayed in the client.
            List<string> suggestions = suggestResult.Results.Select(x => x.Text).Distinct().ToList();
            return Json(suggestions);
        }
    }
}