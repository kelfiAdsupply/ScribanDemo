using System;
using System.IO;
using System.Threading.Tasks;
using Scriban;
using Scriban.Runtime;

namespace TemplateEngine
{
    public class FileWithPartialScenario
    {

        public static string Template
        {
            get
            {
                string fileTemplate;
                using (var stream = new StreamReader($"{Environment.CurrentDirectory}\\Views\\TemplateWithPartial.html"))
                {
                    fileTemplate = stream.ReadToEnd();
                }
                return fileTemplate;
            }
        }

        public static string Partial
        {
            get
            {
                string fileTemplate;
                using (var stream = new StreamReader($"{Environment.CurrentDirectory}\\Views\\Partial.html"))
                {
                    fileTemplate = stream.ReadToEnd();
                }
                return fileTemplate;
            }
        }

        public static string Partial2
        {
            get
            {
                string fileTemplate;
                using (var stream = new StreamReader($"{Environment.CurrentDirectory}\\Views\\Partials\\Partial2.html"))
                {
                    fileTemplate = stream.ReadToEnd();
                }
                return fileTemplate;
            }
        }

        public static async Task<string> GetTemplate(object model)
        {
            var tpl = Scriban.Template.Parse(Template);
            var templateContext = new TemplateContext
            {
                TemplateLoader = new PartialInclude(),
            };
            var scriptObject = new ScriptObject();
            scriptObject.Import(model, renamer: member => member.Name);
            templateContext.PushGlobal(scriptObject);
            var result = await tpl.RenderAsync(templateContext);
            return result;
        }
    }
}
