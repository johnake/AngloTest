using AngloAmers.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AngloAmers.Service
{
    public interface IGetRequests
    {
        Task<int> GetCarByTypeResponseCode(string type);

        Task<IList<Car>> GetCarByType(string type);
    }
}
