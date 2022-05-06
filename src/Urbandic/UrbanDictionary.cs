/*
 * Copyright (c) 2022 XXIV
 *
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 *
 * The above copyright notice and this permission notice shall be included in all
 * copies or substantial portions of the Software.
 *
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
 * SOFTWARE.
 */
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Urbandic {
    public class UrbanDictionary {

        private static string Http(string endpoint)
        {
            try
            {
                HttpWebRequest client = (HttpWebRequest) WebRequest.Create($"https://api.urbandictionary.com/v0/{endpoint}");
                client.Method = "GET";
                var webResponse = client.GetResponse();
                var webStream = webResponse.GetResponseStream();
                var responseReader = new StreamReader(webStream);
                var response = responseReader.ReadToEnd();
                responseReader.Close();
                responseReader.Dispose();
                return response;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static List<Response> Search(string input, long page)
        {
            try
            {
                var response = Http($"define?term={Uri.EscapeDataString(input)}&page={page}");
                if (response != null && response.Length != 0)
                {
                    BaseResponse data = JsonConvert.DeserializeObject<BaseResponse>(response);
                    if (data.list != null && data.list.Count != 0)
                    {
                        List<Response> list = new List<Response>();
                        foreach (var c in data.list)
                        {
                            list.Add(c);
                        }
                        if (list.Count == 0)
                        {
                            return null;
                        }
                        else
                        {
                            return list;
                        }
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static List<Response> Random()
        {
            try
            {
                var response = Http("random");
                if (response != null && response.Length != 0)
                {
                    BaseResponse data = JsonConvert.DeserializeObject<BaseResponse>(response);
                    if (data.list != null && data.list.Count != 0)
                    {
                        List<Response> list = new List<Response>();
                        foreach (var c in data.list)
                        {
                            list.Add(c);
                        }
                        if (list.Count == 0)
                        {
                            return null;
                        }
                        else
                        {
                            return list;
                        }
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static Response DefinitionById(long id)
        {
            try
            {
                var response = Http($"define?defid={id}");
                if (response != null && response.Length != 0)
                {
                    BaseResponse data = JsonConvert.DeserializeObject<BaseResponse>(response);
                    if (data.list != null && data.list.Count != 0)
                    {
                        return data.list[0];
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static string ToolTip(string term)
        {
            try
            {
                var response = Http($"tooltip?term={term}");
                if (response != null && response.Length != 0)
                {
                    string data = JObject.Parse(response)["string"].ToString();
                    return data;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}