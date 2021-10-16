using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using LttFlow.Authorization.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace LttFlow.Telegram
{
    public class TelegramUserList : CreationAuditedEntity<long, User>, IMayHaveTenant
    {
        public virtual int? TenantId { get; set; }
        public int TelegramId { get; set; }
        public string Name { get; set; }
        public bool IsUsed { get; set; }
    }
}
