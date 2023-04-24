using DBModels.Models;
using Google;
using System;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YVFlashCard.Service.Interfaces;
using static Grpc.Core.Metadata;
using YVFlashCard.Service.Types;

namespace YVFlashCard.Service.VisitCounter
{
    public class VisitCounterRepositoryService : IVisitCounterRepositoryService
    {
        private readonly YVFlashCardContext _context;

        public VisitCounterRepositoryService()
        {
            _context = new YVFlashCardContext();
        }

        public async Task<int> GetVisitCountAsync()
        {
            var visitCount = await _context.Setting.FirstOrDefaultAsync(u => u.Name == SettingTypes.USER_VISIT_COUNTER);
            if (visitCount == null)
            {
                return 0;
            }
            return int.Parse(visitCount.Value);
        }

        public async Task<int> IncrementVisitCountAsync(int count)
        {
            var visitCount = await _context.Setting.FirstOrDefaultAsync(u => u.Name == SettingTypes.USER_VISIT_COUNTER);

            if (visitCount == null)
            {
                return 0;
            }
            else
            {
                visitCount.Value = (int.Parse(visitCount.Value) + count).ToString();
            }
            var lastUpdate = await _context.Setting.FirstOrDefaultAsync(u => u.Name == SettingTypes.USER_VISIT_COUNTER_LAST_UPDATE);
            if (lastUpdate != null)
            {
                lastUpdate.Value = DateTime.Now.ToString();
            }
            await _context.SaveChangesAsync();
            return int.Parse(visitCount.Value);
        }
        public async Task<int> IncrementVisitCountAsync()
        {
            return await IncrementVisitCountAsync(1);
        }
    }
}
