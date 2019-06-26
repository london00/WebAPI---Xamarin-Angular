using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace UdemyDotNetCoreAngular.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class BaseController : ControllerBase
    {
        protected readonly IMapper mapper;

        public BaseController(IMapper mapper)
        {
            this.mapper = mapper;
        }
    }
}