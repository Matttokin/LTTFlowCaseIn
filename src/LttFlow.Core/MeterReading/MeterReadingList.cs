using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using LttFlow.Authorization.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LttFlow.MeterReading
{
    public class MeterReadingList : CreationAuditedEntity<long, User>, IMayHaveTenant
    {
        public virtual int? TenantId { get; set; }
        public string GIUD { get; set; }
        public string Name { get; set; }

        [ForeignKey("GroupId")]
        public MeterReadingList Group;
        public int GroupId { get; set; }
        public string Location { get; set; }
        public decimal Value { get; set; }
        public DateTime Time { get; set; }
    }
}
