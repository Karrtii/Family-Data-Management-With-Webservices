using DNPHandin1.Models;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DNPHandin1.Data
{
    public interface IAdultsService
    {
        Task<IList<Adult>> GetAdults();
        Task<Adult> AddAdult(Adult adult);
        Task RemoveAdult(int id);
    }
}
