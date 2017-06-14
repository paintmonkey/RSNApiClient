using System.Net.Http;
using System.ComponentModel;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace RSNApiClient.Global
{
    public static class Http
    {
        public static FormUrlEncodedContent ToFormUrlEncodedContent<T>(this T dynamicObject)
        {
            Console.WriteLine(string.Format("{0}", dynamicObject.ToString()));
            List<KeyValuePair<string, string>> parameters = new List<KeyValuePair<string, string>>();

            foreach (PropertyDescriptor propertyDescriptor in TypeDescriptor.GetProperties(dynamicObject))
            {
                var property = propertyDescriptor.GetValue(dynamicObject);
                if(property != null)
                {
                    string value = property.ToString();
                    var pair = new KeyValuePair<string, string>(string.Format("record[{0}]", propertyDescriptor.Name.ToLower()), value);
                    Console.WriteLine(string.Format("{0}:{1}", pair.Key, pair.Value));
                    parameters.Add(pair);
                }
            }

            return new FormUrlEncodedContent(parameters.ToArray());
        }
    }
}
