using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using UdemyDotNetCoreAngular.DAL;
using UdemyDotNetCoreAngular.Domain.Models;
using UdemyDotNetCoreAngular.DTO;

namespace UdemyDotNetCoreAngular.Controllers
{
    public class MakesController : BaseController
    {
        private readonly IMakeDAL makeDAL;
        public MakesController(IMapper mapper, IMakeDAL makeDAL) : base(mapper)
        {
            this.makeDAL = makeDAL;
        }

        [HttpGet]
        public async Task<IEnumerable<MakeDTO>> GetMakes()
        {
            List<Make> makes = await makeDAL.GetMakes();
            return mapper.Map<IEnumerable<Make>, IEnumerable<MakeDTO>>(makes);
        }
    }
}