using System.Collections.Generic;
using System.Threading.Tasks;
using UdemyDotNetCoreAngular.Domain.Models;

namespace UdemyDotNetCoreAngular.DAL
{
    public interface IMakeDAL
    {
        Task<List<Make>> GetMakes();
    }
}