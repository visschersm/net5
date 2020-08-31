using System;
using System.Net.Http;
using System.Net.Http.Headers;

using(var httpClient = new HttpClient())
{
    httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("text/plain"));
    var result = await httpClient.GetStringAsync(new Uri("https://icanhazdadjoke.com")); 
    Console.WriteLine(result);
}