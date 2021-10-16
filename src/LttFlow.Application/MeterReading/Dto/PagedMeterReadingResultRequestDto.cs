using Abp.Application.Services.Dto;

namespace LttFlow.MeterReading.Dto
{
    public class PagedMeterReadingResultRequestDto : PagedResultRequestDto
    {
        public string Keyword { get; set; }
    }
}

