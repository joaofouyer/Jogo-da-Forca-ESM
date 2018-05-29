using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using JFESM.API;
using JFESM.Model;
using System.Collections.Generic;
using System.Linq;
using JFESM.Web.Controllers.Items;
using JFESM.Web.Validators;
using JFESM.Web.Extensions;
using System;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace JFESM.Web
{
    [Route("api/[controller]")]
    public class SalaController : Controller
    {
        private readonly ISalaService salaService;

        public SalaController(ISalaService salaService)
        {
            this.salaService = salaService;
        }
    }
}
