using WebAPP.AccesoDatos.Data.Repository;
using WebAPP.Models;

namespace WebAPP.AccesoDatos.Data
{
    public class EmailRepository : Repository<Email>, IEmailRepositor
    {

        private readonly ApplicationDbContext DDb;
        public EmailRepository(ApplicationDbContext context) : base(context)
        {
            DDb = context;
        }

    }
}
