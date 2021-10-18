using Abp.Application.Services;
using Abp.Dependency;
using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using LttFlow.MeterReading;
using LttFlow.Telegram;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;

namespace LttFlow.Test
{
    public class TelegramAppService : LttFlowAppServiceBase, ITelegramAppService
    {
        static string token = "2023066077:AAGeCA8YcQPDeZgdaFVmrbWPw5U3faG7HrQ";
        string urlDomain = "https://api.telegram.org/";
        string getUpdates = string.Format("bot{0}/getUpdates", token);
        string sendMessage = string.Format("bot{0}/sendMessage", token);
        string sURL;
        static string updateId;

        private readonly IRepository<TelegramUserList, long> repositoryTgUser;

        private Timer _timer;

        public TelegramAppService(IRepository<TelegramUserList, long> repository)
        {
            repositoryTgUser = repository;
        }


        void sendUser(string text)
        {
            var users = repositoryTgUser.GetAll();
            foreach (TelegramUserList user in users)
            {
                sURL = urlDomain + sendMessage + "?chat_id=" + user.TelegramId + "&text=" + text;
                Console.WriteLine(sURL);
                WebRequest wrGETURL;
                wrGETURL = WebRequest.Create(sURL);
                Stream objStream;
                objStream = wrGETURL.GetResponse().GetResponseStream();

                StreamReader objReader = new StreamReader(objStream);

                string outLine = "";
                string sLine = "";
                int i = 0;
                List<string> ls = new List<string>();
                while (sLine != null)
                {
                    i++;
                    sLine = objReader.ReadLine();
                    if (sLine != null)
                    {
                        outLine += sLine;
                    }
                }
            }

        }
        void sendUserById(string id, string text)
        {

            sURL = urlDomain + sendMessage + "?chat_id=" + id + "&text=" + text;
            Console.WriteLine(sURL);
            WebRequest wrGETURL;
            wrGETURL = WebRequest.Create(sURL);
            Stream objStream;
            objStream = wrGETURL.GetResponse().GetResponseStream();

            StreamReader objReader = new StreamReader(objStream);

            string outLine = "";
            string sLine = "";
            int i = 0;
            List<string> ls = new List<string>();
            while (sLine != null)
            {
                i++;
                sLine = objReader.ReadLine();
                if (sLine != null)
                {
                    outLine += sLine;
                }
            }


        }

        [UnitOfWork]
        public virtual string GetNewUser()
        {
            sURL = urlDomain + getUpdates + "?offset=" + (String.IsNullOrEmpty(updateId) ? "" : (Int32.Parse(updateId) + 1).ToString());
            WebRequest wrGETURL;
            wrGETURL = WebRequest.Create(sURL);
            Stream objStream;
            objStream = wrGETURL.GetResponse().GetResponseStream();

            StreamReader objReader = new StreamReader(objStream);

            string outLine = "";
            string sLine = "";
            int i = 0;
            List<string> ls = new List<string>();
            while (sLine != null)
            {
                i++;
                sLine = objReader.ReadLine();
                if (sLine != null)
                {
                    outLine += sLine;
                }
            }
            JObject o = JObject.Parse(outLine);
            JToken result = o["result"];


            foreach (JToken elem in result)
            {
                updateId = (string)elem["update_id"];

                string chat_id = (string)elem["message"]["chat"]["id"];
                string first_name = (string)elem["message"]["chat"]["first_name"];
                string last_name = (string)elem["message"]["chat"]["last_name"];

                string text = (string)elem["message"]["text"];

                if (text.Equals("/start"))
                {
                    var user = repositoryTgUser.GetAll().FirstOrDefault(x => x.TelegramId.ToString().Equals(chat_id) && x.IsUsed);

                    if (user == null)
                    {
                        repositoryTgUser.Insert(new TelegramUserList()
                        {
                            TelegramId = Int32.Parse(chat_id),
                            Name = first_name + " " + last_name,
                            IsUsed = true
                        });
                        sendUserById(chat_id, "Здравствуйте. Вы используете LTTFlowBot");
                        CurrentUnitOfWork.SaveChanges();
                    }

                }

            }
            return outLine;
        }

        [UnitOfWork]
        public virtual void GetNewUserCycle()
        {
            _timer = new Timer((obj) => GetNewUser(), null, 0, 60 * 1000);
        }
        [HttpGet]
        public void httpSend(string text)
        {
            sendUser(text);
        }
    }
}
