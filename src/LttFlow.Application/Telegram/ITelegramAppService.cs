using Abp.Application.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace LttFlow.Test
{
    public interface ITelegramAppService : IApplicationService
    {
        public void GetNewUserCycle();
        public void httpSend(string text);
    }
}
