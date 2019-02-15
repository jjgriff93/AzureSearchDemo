# AzureSearchDemo
Demo ASP.NET Core / clientside code to perform simple searches on an Azure Search index

Getting started
1. Create your Azure Search index - guide [here](https://docs.microsoft.com/en-us/azure/search/search-create-index-dotnet)
2. Add your search key and the service name in the `appsettings.json`
3. Update the `SearchController.cs` with your index name (and suggester name if you're using a suggester) - lines 25 and 31
