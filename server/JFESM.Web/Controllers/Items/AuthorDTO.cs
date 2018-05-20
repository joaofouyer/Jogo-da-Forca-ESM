using System.Runtime.Serialization;
using JFESM.Model;

namespace JFESM.Web.Controllers.Items
{
    public class BonecoDTO
    {
        [DataMember(Name = "id")]
        public long Id { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }
    }
}