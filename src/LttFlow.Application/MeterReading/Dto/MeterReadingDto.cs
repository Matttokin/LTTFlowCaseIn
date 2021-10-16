using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;
using Abp.Authorization.Roles;
using Abp.AutoMapper;
using LttFlow.Authorization.Roles;

namespace LttFlow.MeterReading.Dto
{
    [AutoMapFrom(typeof(MeterReadingList))]
    [AutoMapTo(typeof(MeterReadingList))]
    public class MeterReadingDto : EntityDto<long>
    {
        public string GIUD { get; set; }
        public string Name { get; set; }

        public MeterReadingDto Group;
        public int GroupId { get; set; }
        public string Location { get; set; }
        public decimal Value { get; set; }
        public DateTime Time { get; set; }
    }
}