using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FeedbackAPI.Models;

namespace FeedbackAPI.Data
{
    public class FeedbackContext : DbContext
    {
        public FeedbackContext(DbContextOptions<FeedbackContext> options) : base(options) { }

        public DbSet<Feedback> Feedbacks => Set<Feedback>();
    }
}