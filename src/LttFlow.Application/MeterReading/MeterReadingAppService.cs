using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using LttFlow.MeterReading.Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LttFlow.MeterReading
{
    public class MeterReadingAppService : AsyncCrudAppService<MeterReadingList, MeterReadingDto, long, PagedMeterReadingResultRequestDto>, IMeterReadingAppService
    {
        public MeterReadingAppService(IRepository<MeterReadingList, long> repository)
            : base(repository)
        {
            
        }     

        public async Task<IEnumerable<ChartGroupDto>> GetChartData()
        {
            var metricGroups = await Repository
                .GetAllIncluding(x => x.Group)
                .GroupBy(x => x.Group)
                .AsNoTracking()
                .ToListAsync();

            var result = new List<ChartGroupDto>();

            foreach(var g in metricGroups)
            {
                var groupByDate = g.GroupBy(x => x.Time);

                foreach(var gd in groupByDate)
                {
                    result.Add(new ChartGroupDto()
                    {
                        GroupName = g.Key.Name,
                        Value = gd.Average(x => x.Value),
                        Date = gd.Key.ToString("dd.MM.yyyy")
                    });
                }
            }

            return result;
        }
    }
}
