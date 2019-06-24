using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using UdemyDotNetCoreAngular.Domain;

namespace UdemyDotNetCoreAngular.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class BaseController : ControllerBase
    {
        protected readonly VegaDBContext db;
        protected readonly IMapper mapper;

        public BaseController(VegaDBContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }
    }
}