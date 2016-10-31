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
         else
         {
             TV tv = new TV();
            list.Add(tv.ToString());
            list.Add(3);

         }
         return list;
        }
         private void Init(TV tv, int id)
        {
           
            applienceDictionary.Add(id, tv);
               
        }
        [Route("api/channel/next")]
        public string[] PutNext([FromBody]List<Object> li)
        {
            TV tv = JsonConvert.DeserializeObject<TV>(li[0].ToString());
            int id = JsonConvert.DeserializeObject<int>(li[1].ToString());
            TV tv2;
            string[] array = new string[2];
            id++;
            if (applienceDictionary.ContainsKey(id) == false)
            {
                Init(tv, id);
                tv.NextChannel();

                array[0] = tv.currentChannel;
                array[1] = tv.ToString();
            }
            else
            {
                tv2 = applienceDictionary[id] as TV;
                tv2.NextChannel();

                array[0] = tv2.currentChannel;
                array[1] = tv2.ToString();
            }


            return array;

        }
        [Route("api/channel/OnOff")]
        public string[] PutOnOff([FromBody] List<Object> li)
        {
            TV tv = JsonConvert.DeserializeObject<TV>(li[0].ToString());
            int id = JsonConvert.DeserializeObject<int>(li[1].ToString());
            TV tv2;
            string[] array = new string[2];
            id++;
            
            if (applienceDictionary.ContainsKey(id) == false)
            {
                Init(tv, id);
                tv.OnOff();

                array[0] = tv.State.ToString();
                array[1] = tv.ToString();
            }
            else
            {
                tv2 = applienceDictionary[id] as TV;
                tv2.OnOff();

                array[0] = tv2.State.ToString();
                array[1] = tv2.ToString();
            }


            return array;
        }
        [Route("api/channel/prev")]
        public string[] PutPrev([FromBody]List<Object> li)
        {
            TV tv = JsonConvert.DeserializeObject<TV>(li[0].ToString());
            int id = JsonConvert.DeserializeObject<int>(li[1].ToString());
            TV tv2;
            string[] array = new string[2];
            id++;
            if (applienceDictionary.ContainsKey(id) == false)
            {
                Init(tv, id);
                tv.PrevChannel();

                array[0] = tv.currentChannel;
                array[1] = tv.ToString();
            }
            else
            {
                tv2 = applienceDictionary[id] as TV;
                tv2.PrevChannel();

                array[0] = tv2.currentChannel;
                array[1] = tv2.ToString();
            }
            return array;
        }
        [Route("api/channel/down")]
        public string[] PutDown([FromBody] List<Object> li)
        {
            TV tv = JsonConvert.DeserializeObject<TV>(li[0].ToString());
            int id = JsonConvert.DeserializeObject<int>(li[1].ToString());
            TV tv2;
            string[] array = new string[2];
            id++;
            if (applienceDictionary.ContainsKey(id) == false)
            {
                Init(tv, id);
                tv.Down();

                array[0] = tv.Unit.ToString();
                array[1] = tv.ToString();
            }
            else
            {
                tv2 = applienceDictionary[id] as TV;
                tv2.Down();

                array[0] = tv2.Unit.ToString();
                array[1] = tv2.ToString();
            }
            return array;
        }
        [Route("api/channel/up")]
        public string[] PutUp([FromBody] List<Object> li)
        {
            TV tv = JsonConvert.DeserializeObject<TV>(li[0].ToString());
            int id = JsonConvert.DeserializeObject<int>(li[1].ToString());
            TV tv2;
            string[] array = new string[2];
            id++;
            if (applienceDictionary.ContainsKey(id) == false)
            {
                Init(tv, id);
                tv.Up();

                array[0] = tv.Unit.ToString();
                array[1] = tv.ToString();
            }
            else
            {
                tv2 = applienceDictionary[id] as TV;
                tv2.Up();

                array[0] = tv2.Unit.ToString();
                array[1] = tv2.ToString();
            }
            return array;
        }
        [Route("api/channel/addCh")]
        public TV PostChannel([FromBody] List<Object> li)
        {

            TV tv = JsonConvert.DeserializeObject<TV>(li[0].ToString());
            int id = JsonConvert.DeserializeObject<int>(li[1].ToString());
            string channel = (string)li[2];
            TV tv2;
            
            id++;
            if (applienceDictionary.ContainsKey(id) == false)
            {
                Init(tv, id);
                tv.AddChannel(channel);

                return tv;
            }
            else
            {
                tv2 = applienceDictionary[id] as TV;
                tv2.AddChannel(channel);

                return tv2;
            }

            
        }
        [Route("api/channel/deleteCh")]
        public List<Object> DeleteCh([FromBody] List<Object> li)
        {
            TV tv = JsonConvert.DeserializeObject<TV>(li[0].ToString());
            int id = JsonConvert.DeserializeObject<int>(li[1].ToString());
            TV tv2;
            string[] array = new string[2];
            id++;
            List<Object> list = new List<object>();
            if (applienceDictionary.ContainsKey(id) == false)
            {
                Init(tv, id);
                tv.DeleteCurrentCh();

                list.Add(tv);
                list.Add(tv.ToString());
            }
            else
            {
                tv2 = applienceDictionary[id] as TV;
                tv2.DeleteCurrentCh();

                list.Add(tv2);
                list.Add(tv2.ToString());
            }

            return list;
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
