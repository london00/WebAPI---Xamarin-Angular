using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using UdemyDotNetCoreAngular.DAL;
using UdemyDotNetCoreAngular.Domain.Models;
using UdemyDotNetCoreAngular.DTO;

namespace UdemyDotNetCoreAngular.Controllers
{
    public class FeaturesController : BaseController
    {
        private readonly IFeatureDAL featureDAL;
        public FeaturesController(IMapper mapper, IFeatureDAL featureDAL) : base(mapper)
        {
            this.featureDAL = featureDAL;
        }

        [HttpGet]
        public async Task<ICollection<KeyValuePairDTO>> GetFeaturesByModel(int ModelId) {
            List<Feature> features = await featureDAL.GetFeaturesByModel(ModelId);
            var faturesDTO = mapper.Map<ICollection<Feature>, ICollection<KeyValuePairDTO>>(features);
            return faturesDTO;
        }
    }
}