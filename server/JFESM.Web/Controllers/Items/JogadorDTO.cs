using System.Runtime.Serialization;
using JFESM.Model;

namespace JFESM.Web.Controllers.Items
{
    public class JogadorDTO
    {
        [DataMember(Name = "id")]
        public string Id { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "estaPronto")]
        public bool EstaPronto { get; set; }
    }
}