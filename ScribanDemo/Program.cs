// See https://aka.ms/new-console-template for more information

using System.Diagnostics;
using Newtonsoft.Json;
using TemplateEngine;

var sw = new Stopwatch();

Console.WriteLine("String Scenario");
Console.WriteLine($"Template: \n{StringScenario.Template}");
Console.WriteLine("----------------------------------------\n");

Console.WriteLine("Start Compiled");
var stringModel = new StringViewModel {Name = "John Doe"};
sw.Restart();
var stringCompiled = StringScenario.GetTemplate(stringModel).Result;
sw.Stop();
Console.WriteLine($"End: {sw.ElapsedMilliseconds} ms");
Console.WriteLine($"Model:\n{JsonConvert.SerializeObject(stringModel)}");
Console.WriteLine($"Result:\n{stringCompiled}");
Console.WriteLine("----------------------------------------\n");

Console.WriteLine("Start Cached");
var stringModel2 = new StringViewModel {Name = "Marie Doe"};
sw.Restart();
var stringCached = StringScenario.GetTemplate(stringModel2).Result;
sw.Stop();
Console.WriteLine($"End: {sw.ElapsedMilliseconds} ms");
Console.WriteLine($"Model:\n{JsonConvert.SerializeObject(stringModel2)}");
Console.WriteLine($"Result:\n{stringCached}");
Console.WriteLine("----------------------------------------\n");

Console.WriteLine("\n\n\n\n");




Console.WriteLine("File Scenario");
Console.WriteLine($"Template: \n{FileWithoutPartialScenario.Template}");
Console.WriteLine("----------------------------------------\n");

Console.WriteLine("Start Compiled");
var fileModel = new TemplateWithoutPartialViewModel()
{
    CompanyName = "AdSupply",
    SiteNames = new[] { "Site1", "Site2" },
    SupportEmail = "support@adsupply.com",
    UserName = "User1"
};
sw.Restart();
var fileCompiled = FileWithoutPartialScenario.GetTemplate(fileModel).Result;
sw.Stop();
Console.WriteLine($"End: {sw.ElapsedMilliseconds} ms");
Console.WriteLine($"Model:\n{JsonConvert.SerializeObject(fileModel)}");
Console.WriteLine($"Result:\n{fileCompiled}");
Console.WriteLine("----------------------------------------\n");

Console.WriteLine("Start Cached");
var fileModel2 = new TemplateWithoutPartialViewModel()
{
    CompanyName = "TwinRed",
    SiteNames = new[] { "Site3" },
    SupportEmail = "support@twinred.com",
    UserName = "User2"
};
sw.Restart();
var fileCached = FileWithoutPartialScenario.GetTemplate(fileModel2).Result;
sw.Stop();
Console.WriteLine($"End: {sw.ElapsedMilliseconds} ms");
Console.WriteLine($"Model:\n{JsonConvert.SerializeObject(fileModel2)}");
Console.WriteLine($"Result:\n{fileCached}");
Console.WriteLine("----------------------------------------\n");

Console.WriteLine("\n\n\n\n");



Console.WriteLine("File With Partial Scenario");
Console.WriteLine($"Template: \n{FileWithPartialScenario.Template}");
Console.WriteLine($"Partial 1: \n{FileWithPartialScenario.Partial}");
Console.WriteLine($"Partial 2: \n{FileWithPartialScenario.Partial2}" );
Console.WriteLine("----------------------------------------\n");

Console.WriteLine("Start Compiled");
var fileWithPartialModel = new
{
    CompanyName = "AdSupply",
    Users = new[] { "User1", "User2", "User3" },
};
sw.Restart();
var fileWithPartialCompiled = FileWithPartialScenario.GetTemplate(fileWithPartialModel).Result;
sw.Stop();
Console.WriteLine($"End: {sw.ElapsedMilliseconds} ms");
Console.WriteLine($"Model:\n{JsonConvert.SerializeObject(fileWithPartialModel)}");
Console.WriteLine($"Result:\n{fileWithPartialCompiled}");
Console.WriteLine("----------------------------------------\n");

Console.WriteLine("Start Cached");
var fileWithPartialModel2 = new
{
    CompanyName = "TwinRed",
    Users = new[] { "User4", "User5" },
};
sw.Restart();
var fileWithPartialCached = FileWithPartialScenario.GetTemplate(fileWithPartialModel2).Result;
sw.Stop();
Console.WriteLine($"End: {sw.ElapsedMilliseconds} ms");
Console.WriteLine($"Model:\n{JsonConvert.SerializeObject(fileWithPartialModel2)}");
Console.WriteLine($"Result:\n{fileWithPartialCached}");
Console.WriteLine("----------------------------------------\n");