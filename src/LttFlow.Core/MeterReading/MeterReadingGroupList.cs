using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using LttFlow.Authorization.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace LttFlow.MeterReading
{
    public class MeterReadingGroupList : CreationAuditedEntity<long, User>, IMayHaveTenant
    {
        public virtual int? TenantId { get; set; }
        public string Alias { get; set; }
        public string Name { get; set; }
    }
}
