using Abp.Application.Services;
using Abp.Domain.Repositories;
using LttFlow.MeterReading;
using System;
using System.Collections.Generic;
using System.Text;

namespace LttFlow.SeedTimer
{
    public class SeedTimerAppService : LttFlowAppServiceBase, ISeedTimerAppService
    {
        private readonly IRepository<MeterReadingList, long> _meterReadingRepository;

        public SeedTimerAppService(IRepository<MeterReadingList, long> meterReadingRepository)
        {
            _meterReadingRepository = meterReadingRepository;
        }


    }
}
