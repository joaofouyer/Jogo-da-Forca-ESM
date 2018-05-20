
using System.Collections.Generic;
using System.Linq;
using JFESM.Model;
using JFESM.Web.Controllers.Items;

namespace JFESM.Web.Extensions
{
    public static class BonecoExtensions
    {
        public static BonecoDTO ToBonecoViewItem(this Boneco author)
        {
            return new BonecoDTO()
            {
                Name = ""
            };
        }

        public static IEnumerable<BonecoDTO> ToBonecoViewItems(this IEnumerable<Boneco> authors)
        {
            return authors.Select(a => a.ToBonecoViewItem()).ToArray();
        }
    }
}