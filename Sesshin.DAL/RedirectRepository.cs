using System.Linq;
using Sesshin.Model;

namespace Sesshin.DAL
{
    public class RedirectRepository
    {
        readonly SesshinAdminContext context = new SesshinAdminContext();

        public IQueryable<Redirect> All
        {
            get { return context.Redirects; }
        }

    }
}
