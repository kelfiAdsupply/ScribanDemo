using System.Threading.Tasks;

namespace TemplateEngine
{
    public class StringScenario
    {
        public static string Template => "Hello, {{name}} Welcome to Scriban repository";

        public static async Task<string> GetTemplate(StringViewModel model)
        {
            var template = Scriban.Template.Parse(Template);
            return await template.RenderAsync(model);
        }
    }
}
