using  System.Net.Http.Headers;
using  System.Text.Json;


using  HttpClient  client  =  new();

client.DefaultRequestHeaders.Accept.Clear();
client.DefaultRequestHeaders.Accept.Add(new  MediaTypeWithQualityHeaderValue(
      "application/vnd.github.v3+json"));
client.DefaultRequestHeaders.Add(
      "User-Agent",  ".Net Fundation Repository Reporter");

var  repositories  =  await ProcessRepositoriesAsync(client);

foreach(var  repo  in  repositories)  {

    Console.WriteLine($"Name:  {repo.Name}");
    Console.WriteLine($"Homepage:  {repo.Homepage}");
    Console.WriteLine($"Github:  {repo.GitHubHomeUrl}");
    Console.WriteLine($"Description:  {repo.Description}");
    Console.WriteLine($"Watchers:  {repo.Watchers:#,0}");
    Console.WriteLine($"Last push:  {repo.LastPush}");
    Console.WriteLine();

}

static  async  Task<List<Repository>>  ProcessRepositoriesAsync(HttpClient  client){

    /**var  json  =  await  client.GetStringAsync(
          "https://api.github.com/orgs/dotnet/repos"); */
    
    await  using  Stream  stream  =    await  client.GetStreamAsync(
          "https://api.github.com/orgs/dotnet/repos");
    
    var  repositories  =  await  JsonSerializer.DeserializeAsync<List<Repository>>(stream);
    
    //Console.WriteLine(json);
    
    //foreach(var  repo  in  repositories  ??  Enumerable.Empty<Repository>())  Console.Write(repo.name);
    
    //foreach(var  repo  in  repositories)  Console.Write(repo.Name);
    
    return  repositories  ??  new();

}
