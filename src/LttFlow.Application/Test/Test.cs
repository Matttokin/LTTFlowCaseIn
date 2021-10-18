using Abp.Application.Services;
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

namespace LttFlow.Test
{
    public class Test : LttFlowAppServiceBase,IApplicationService
    {
        static string token = "2023066077:AAGeCA8YcQPDeZgdaFVmrbWPw5U3faG7HrQ";
        string urlDomain = "https://api.telegram.org/";
        string getUpdates = string.Format("bot{0}/getUpdates", token);
        string sendMessage = string.Format("bot{0}/sendMessage", token);
        string sURL;
        string updateId;
        IRepository<TelegramUserList, long> repositoryTgUser;

        public Test(IRepository<TelegramUserList, long> repository)
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
        void sendUserById(string id,string text)
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


        string getNewUser()
        {
            sURL = urlDomain + getUpdates + "?offset=" + updateId;
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


        [HttpGet]
        public string Get()
        {
            
            getNewUser();
            sendUser("hell");
            return null;
        }
    }
}
