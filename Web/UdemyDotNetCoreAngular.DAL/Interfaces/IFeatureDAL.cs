using System.Collections.Generic;
using System.Threading.Tasks;
using UdemyDotNetCoreAngular.Domain.Models;

namespace UdemyDotNetCoreAngular.DAL
{
    public interface IFeatureDAL
    {
        Task<List<Feature>> GetFeaturesByModel(int ModelId);
    }
}