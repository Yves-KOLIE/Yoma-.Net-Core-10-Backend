using Microsoft.EntityFrameworkCore;

namespace YOMA.Models
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options) { }
        public Context() { }
    }
}