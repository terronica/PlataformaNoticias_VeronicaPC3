using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsIntegrationService.Models
{
    public class Comment
    {
    public int Id { get; set; }
    public int PostId { get; set; }
    public string Body { get; set; } = "";
    }
}