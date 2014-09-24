using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.DAL
{
    public static class TagDAO
    {
        static BlogDBEntities db = new BlogDBEntities();

        public static IEnumerable<object> TagsAutocomplete(string lastValue)
        {
            return db.Tags.Where(t => t.TagName.Contains(lastValue)).Select(t => t.TagName).ToList();
        }
    }
}
