using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NestToFlatProject
{
    public class NestToFlat
    {
        public JArray getFlatObject(object requestObj)
        {
            JArray jArray = new JArray();
            try
            {
                if (requestObj != null)
                {
                    JArray complexObj = JArray.FromObject(requestObj);
                    complexObj.ToList().ForEach(x =>
                    {
                        string routeName = Convert.ToString(x["routename"]);
                        if(((JObject)x).ContainsKey("stops"))
                        x["stops"].ToList().ForEach(y =>
                        {
                            string stopName = Convert.ToString(y["stopname"]);
                            if (((JObject)y).ContainsKey("objects"))
                                y["objects"].ToList().ForEach(z =>
                                {
                                    JObject jObject = new JObject();
                                    JObject.Parse(z.ToString()).Properties().ToList().ForEach(a =>
                                    {
                                        jObject.Add(a.Name, a.Value);
                                    });
                                    jObject.Add("stopname", stopName);
                                    jObject.Add("routename", routeName);
                                    jArray.Add(jObject);
                                });
                            else
                            {
                                JObject jObject = new JObject();
                                jObject.Add("stopname", stopName);
                                jObject.Add("routename", routeName);
                                jArray.Add(jObject);
                            }
                        });
                        else
                        {
                            JObject jObject = new JObject();                                
                            jObject.Add("routename", routeName);
                            jArray.Add(jObject);                            
                        }
                    });
                }
            }catch(Exception ex)
            {

            }
            return jArray;
        }
    }
}