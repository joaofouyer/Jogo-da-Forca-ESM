using System.Collections.Generic;
using System.Linq;
using JFESM.Model;
using JFESM.Web.Controllers.Items;

namespace JFESM.Web.Extensions
{
    public static class AuthorExtensions
    {
        public static BonecoDTO ToAuthorViewItem(this Boneco author)
        {
            return new BonecoDTO()
            {
                Name = ""
            };
        }

        public static IEnumerable<BonecoDTO> ToAuthorViewItems(this IEnumerable<Boneco> authors)
        {
            return authors.Select(a => a.ToAuthorViewItem()).ToArray();
        }
    }
}