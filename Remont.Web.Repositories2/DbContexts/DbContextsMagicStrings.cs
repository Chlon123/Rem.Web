using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Remont.Web.Repositories
{
    public static class DbContextsMagicStrings
    {
        private const string defaultConnectionStringForDbContexts = "DefaultConnection";

        private const string ConnectionStringForDbContexts = "RemontConnection";



        public static string GetConnectionStringForDbContexts()
        {
            return ConnectionStringForDbContexts;
        }

        public static string GetDefaultConnectionStringForDbContexts()
        {
            return defaultConnectionStringForDbContexts;
        }
    }
}
