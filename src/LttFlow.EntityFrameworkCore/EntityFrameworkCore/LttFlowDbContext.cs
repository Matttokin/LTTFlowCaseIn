using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using LttFlow.Authorization.Roles;
using LttFlow.Authorization.Users;
using LttFlow.MultiTenancy;
using LttFlow.MeterReading;
using LttFlow.Telegram;

namespace LttFlow.EntityFrameworkCore
{
    public class LttFlowDbContext : AbpZeroDbContext<Tenant, Role, User, LttFlowDbContext>
    {
        /* Define a DbSet for each entity of the application */
        
        public LttFlowDbContext(DbContextOptions<LttFlowDbContext> options)
            : base(options)
        {
        }
        public DbSet<MeterReadingGroupList> MeterReadingGroupList { get; set; }
        public DbSet<MeterReadingList> MeterReadingList { get; set; }
        public DbSet<TelegramUserList> TelegramUserList { get; set; }
        public DbSet<TelegramNotificationGroupList> TelegramNotificationGroupList { get; set; }
        public DbSet<TelegramUserNotificationList> TelegramUserNotificationList { get; set; }

    }
}
