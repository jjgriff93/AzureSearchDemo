using Microsoft.Azure.Search.Models;
using SearchDemo.Models;

namespace SearchDemo.Services
{

	public interface ISearchService
	{
		DocumentSuggestResult Suggest(string indexName, string suggesterName, string term, bool useFuzzySearch = true,string filters="", int amount = 10);
		DocumentSearchResult Search(string indexName, SearchPayload payload, bool fuzzy);
	}
}