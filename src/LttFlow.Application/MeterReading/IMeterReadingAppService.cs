using Abp.Application.Services;
using LttFlow.MeterReading.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LttFlow.MeterReading
{
    public interface IMeterReadingAppService : IAsyncCrudAppService<MeterReadingDto, long, PagedMeterReadingResultRequestDto>
    {
        Task<IEnumerable<ChartGroupDto>> GetChartData();
    }
}
