using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsIntegrationService.Models
{
    public class Post
    {
    public int Id { get; set; }
    public int UserId { get; set; }
    public string Title { get; set; } = "";
    public string Body { get; set; } = "";
    }
}