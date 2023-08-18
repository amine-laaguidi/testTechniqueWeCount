using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using testTechniqueWeCount.Models;

namespace testTechniqueWeCount.Data
{
    public class IdentityAppContext : IdentityDbContext<Administrateur>
    {
        public IdentityAppContext(DbContextOptions<IdentityAppContext> options) : base(options){}
    }
}
