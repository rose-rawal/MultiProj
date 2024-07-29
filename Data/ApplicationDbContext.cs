using Microsoft.EntityFrameworkCore;

namespace MultiProj.Data
{
    public class ApplicationDbContext :DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options) 
        {
            
        }
    }
}
