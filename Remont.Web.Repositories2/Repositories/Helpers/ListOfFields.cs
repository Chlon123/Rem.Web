using Remont.Web.Repositories2.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Remont.Web.Repositories2.Repositories.Helpers
{
    public class ListOfFields : IListOfFields
    {
        public List<string> CreateListOfFields(string fields)
        {
            List<string> listOfFields = new List<string>();

            if (fields != null)
            {
                listOfFields = fields.ToLower().Split(',').ToList(); 
            }
            return listOfFields;
        }
    }
}
