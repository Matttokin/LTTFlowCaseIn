using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using LttFlow.Authorization.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LttFlow.Telegram
{
    public class TelegramUserNotificationList : CreationAuditedEntity<long, User>, IMayHaveTenant
    {
        public virtual int? TenantId { get; set; }

        [ForeignKey("UserId")]
        public TelegramUserList User;
        public int UserId { get; set; }

        [ForeignKey("GroupId")]
        public TelegramNotificationGroupList Group;
        public int GroupId { get; set; }
    }
}
