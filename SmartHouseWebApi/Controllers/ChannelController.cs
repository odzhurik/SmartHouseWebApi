using Newtonsoft.Json;
using SmartHouseMVC.Models.Factory;
using SmartHouseMVC.Models.ImplementedInterfaces;
using SmartHouseMVC.Models.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;



namespace SmartHouseWebApi.Controllers
{

    public class ChannelController : ApiController
    {
        static IDictionary<int, Applience> applienceDictionary = new SortedDictionary<int, Applience>();

         [HttpGet]
         [Route("api/channel/init")]
        public List<Object> InitFromView()
        {
            IDictionary<int, Applience> applienceD = new SortedDictionary<int, Applience>();
            applienceD = (SortedDictionary<int, Applience>)HttpContext.Current.Session["Apps"];
             foreach(var pair in applienceD)
             {
                 var key = pair.Key;
                 var value = pair.Value;
                 if(value is IChannel)
                 {
                     applienceDictionary[key] = value;
                 }
             }
            List<Object> list = new List<object>();
          
         if(applienceDictionary.Count!=0)
         {
             foreach(int item in applienceDictionary.Keys)
             {
                 int index = 0;
                 list.Add(applienceDictionary[item].ToString());
                 index = item;
                 index--;
                 list.Add(index);
             }
         }
        
         return list;
        }
      
        [Route("api/channel/next")]
        public string PutNext([FromBody]int id)
        {
           
            TV tv2;
            string result = "";
            id++;
            if (applienceDictionary.ContainsKey(id))
           
            {
                tv2 = applienceDictionary[id] as TV;
                tv2.NextChannel();

                
                result = tv2.ToString();
            }


            return result;

        }
        [Route("api/channel/OnOff")]
        public string PutOnOff([FromBody] int id)
        {
          
            TV tv2;
            string result = "";
            id++;
            
            if (applienceDictionary.ContainsKey(id))
           
            {
                tv2 = applienceDictionary[id] as TV;
                tv2.OnOff();

                result = tv2.ToString();
            }


            return result;
        }
        [Route("api/channel/prev")]
        public string PutPrev([FromBody]int id)
        {
           
            TV tv2;
            string result = "";
            id++;
            if (applienceDictionary.ContainsKey(id))
          
            {
                tv2 = applienceDictionary[id] as TV;
                tv2.PrevChannel();

               
                result = tv2.ToString();
            }
            return result;
        }
        [Route("api/channel/down")]
        public string PutDown([FromBody] int id)
        {
           
            TV tv2;
            string result = "";
            id++;
            if (applienceDictionary.ContainsKey(id))
           
            {
                tv2 = applienceDictionary[id] as TV;
                tv2.Down();

                
                result = tv2.ToString();
            }
            return result;
        }
        [Route("api/channel/up")]
        public string PutUp([FromBody] int id)
        {
            
            TV tv2;
            string result = "";
            id++;
            if (applienceDictionary.ContainsKey(id))
           
            {
                tv2 = applienceDictionary[id] as TV;
                tv2.Up();

                
                result = tv2.ToString();
            }
            return result;

        }
        [Route("api/channel/addCh")]
        public string PostChannel([FromBody] List<Object> li)
        {

            
            int id = JsonConvert.DeserializeObject<int>(li[0].ToString());
            string channel = (string)li[1];
            string result = "";
            TV tv2=new TV();
            
            id++;
            if (applienceDictionary.ContainsKey(id))
          
            {
                tv2 = applienceDictionary[id] as TV;
                tv2.AddChannel(channel);
                result = "Your channel added";
                
            }

            return result;
        }
        [Route("api/channel/deleteCh")]
        public string DeleteCh([FromBody] int id)
        {
           
            TV tv2;
            string result = "";
            id++;
           
            if (applienceDictionary.ContainsKey(id))
           
            {
                tv2 = applienceDictionary[id] as TV;
                tv2.DeleteCurrentCh();

                
                result=tv2.ToString();
            }

            return result;
        }
        [Route("api/channel/show/{key}")]
        public string GetCh(int key)
        {
            key++;
            List<string> list = new List<string>();
            if (applienceDictionary.ContainsKey(key))
            {
                TV tv = applienceDictionary[key] as TV;
                list = (List<string>)tv.ShowChannels();
                string result = @"<select multiple>";

                foreach (string channel in list)
                {
                    result+="<option>";
                    result += channel + @"</option>";
                }


                result += "</select>";
                return result;
            }
            else
            {
                return "Server doesn't have this applience";
            }

        }
        [Route("api/channel/deleteApp")]
        public string DeleteApp([FromBody]int key)
        {
           
            key++;

            if (applienceDictionary.ContainsKey(key))
            {
                applienceDictionary.Remove(key);
                return "Deleted!";
            }
            else
            {
                return "Server doesn't have this applience";
            }
           
        }
    }
}
