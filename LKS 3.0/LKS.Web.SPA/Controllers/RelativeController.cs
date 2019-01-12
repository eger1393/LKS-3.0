using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LKS.Data.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LKS.Web.SPA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RelativeController : ControllerBase
    {
        private readonly IRelativeRepository _relativeRepository;

        public RelativeController(IRelativeRepository relativeRepository)
        {
            _relativeRepository = relativeRepository;
        }
    }
}