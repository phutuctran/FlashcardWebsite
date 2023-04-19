using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YVFlashCard.Service.Interfaces
{
        public interface IVisitCounterRepositoryService
        {
            Task<int> GetVisitCountAsync();
            Task<int> IncrementVisitCountAsync();
            Task<int> IncrementVisitCountAsync(int count);
    }
}
