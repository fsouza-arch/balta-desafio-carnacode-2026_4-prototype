using Prototype.Dominio.Entites;

namespace Prototype.Application.Prototypes;

public class TemplateRegistry
{
    private Dictionary<string, DocumentTemplate> _templates = new Dictionary<string, DocumentTemplate>();

    public void AddTemplate(string key, DocumentTemplate template) => _templates[key] = template;

    public DocumentTemplate GetClone(string key)
    {
        if (!_templates.ContainsKey(key)) return null;
        return (DocumentTemplate)_templates[key].Clone();
    }
}
