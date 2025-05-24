using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsIntegrationService.Models
{
    public class PostEnriched
    {
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Body { get; set; } = string.Empty;
    public string Author { get; set; } = string.Empty;
    public List<string> Comments { get; set; } = new();
    }
}