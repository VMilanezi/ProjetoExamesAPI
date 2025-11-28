using Exames.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Exames.API.Context
{
    public class ExameDbContext : DbContext
    {
        public ExameDbContext(DbContextOptions<ExameDbContext> options) : base(options) { }

        public DbSet<ExameModel> Exames { get; set; }
    }
}
