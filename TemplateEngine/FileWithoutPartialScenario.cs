using System;
using System.IO;
using System.Threading.Tasks;

namespace TemplateEngine
{
    public class FileWithoutPartialScenario
    {
        public static string Template => File.ReadAllText($"{Environment.CurrentDirectory}\\Views\\TemplateWithoutPartial.html");

        public static async Task<string> GetTemplate(TemplateWithoutPartialViewModel model)
        {
            var tpl = Scriban.Template.Parse(Template);
            var result = await tpl.RenderAsync(model, member => member.Name);
            return result;
        }
    }
}
