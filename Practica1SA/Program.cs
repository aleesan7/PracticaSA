using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace Practica1SA
{
    class Program
    {
        static void Main(string[] args)
        {
            GetItems();
            string newId = PostItem("Alejandro Sanchez", "Male", "2318153440101@ingenieria.usac.edu.gt", "Active");

            if (!newId.Equals("")) { 
                GetItem(int.Parse(newId));
                PatchItem(int.Parse(newId), "Alejandro", "Male", "kevinalejandro@email.com", "Active");
                DeleteItem(int.Parse(newId));
            }
        }

        private static void GetItem(int id)
        {
            var url = $"https://gorest.co.in/public-api/users/{id}";
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            request.ContentType = "application/json";
            request.Accept = "application/json";

            try
            {
                using (WebResponse response = request.GetResponse())
                {
                    using (Stream strReader = response.GetResponseStream())
                    {
                        if (strReader == null) return;
                        using (StreamReader objReader = new StreamReader(strReader))
                        {
                            string responseBody = objReader.ReadToEnd();
                            // Do something with responseBody
                            Console.WriteLine("This is the information related to the user id: " + id);
                            Console.WriteLine();
                            Console.WriteLine(responseBody);
                            Console.WriteLine();
                            Console.ReadKey();
                        }
                    }
                }
            }
            catch (WebException ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine();
            }
        }

        private static void GetItems()
        {
            var url = $"https://gorest.co.in/public-api/users";
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            request.ContentType = "application/json";
            request.Accept = "application/json";

            try
            {
                using (WebResponse response = request.GetResponse())
                {
                    using (Stream strReader = response.GetResponseStream())
                    {
                        if (strReader == null) return;
                        using (StreamReader objReader = new StreamReader(strReader))
                        {
                            string responseBody = objReader.ReadToEnd();
                            // Do something with responseBody
                            Console.WriteLine("This is the complete users list");
                            Console.WriteLine();
                            Console.WriteLine(responseBody);
                            Console.WriteLine();
                            Console.ReadKey();
                        }
                    }
                }
            }
            catch (WebException ex)
            {
                // Handle error
                Console.WriteLine(ex.Message);
            }
        }

        private static string PostItem(string name, string gender, string email, string status)
        {
            var url = $"https://gorest.co.in/public-api/users";
            var request = (HttpWebRequest)WebRequest.Create(url);
            string json = $"{{\"name\":\"{name}\", \"gender\":\"{gender}\", \"email\":\"{email}\", \"status\":\"{status}\"}}";
            request.Method = "POST";
            request.ContentType = "application/json";
            request.Accept = "application/json";
            request.Headers.Add("Authorization", "Bearer 9641f867d9f4c141e46bc7b11c458233c1f83e34cb353916047b78227130db51");

            using (var streamWriter = new StreamWriter(request.GetRequestStream()))
            {
                streamWriter.Write(json);
                streamWriter.Flush();
                streamWriter.Close();
            }

            try
            {
                using (WebResponse response = request.GetResponse())
                {
                    using (Stream strReader = response.GetResponseStream())
                    {
                        if (strReader == null) return "";
                        using (StreamReader objReader = new StreamReader(strReader))
                        {
                            string responseBody = objReader.ReadToEnd();
                            // Do something with responseBody
                            Console.WriteLine("This is the new created user");
                            Console.WriteLine();
                            Console.WriteLine(responseBody);
                            Console.WriteLine();
                            string data = JObject.Parse(responseBody)["data"]["id"].ToString();
                            Console.ReadKey();

                            return data;
                        }
                    }
                }
            }
            catch (WebException ex)
            {
                Console.WriteLine(ex.Message);
                return "";
            }
        }

        private static void PatchItem(int id, string name, string gender, string email, string status)
        {
            var url = $"https://gorest.co.in/public-api/users/{id}";
            var request = (HttpWebRequest)WebRequest.Create(url);
            string json = $"{{\"id\":\"{id}\", \"name\":\"{name}\", \"gender\":\"{gender}\", \"email\":\"{email}\", \"status\":\"{status}\"}}";
            request.Method = "PATCH";
            request.ContentType = "application/json";
            request.Accept = "application/json";
            request.Headers.Add("Authorization", "Bearer 9641f867d9f4c141e46bc7b11c458233c1f83e34cb353916047b78227130db51");

            using (var streamWriter = new StreamWriter(request.GetRequestStream()))
            {
                streamWriter.Write(json);
                streamWriter.Flush();
                streamWriter.Close();
            }

            try
            {
                using (WebResponse response = request.GetResponse())
                {
                    using (Stream strReader = response.GetResponseStream())
                    {
                        if (strReader == null) return;
                        using (StreamReader objReader = new StreamReader(strReader))
                        {
                            string responseBody = objReader.ReadToEnd();
                            // Do something with responseBody
                            Console.WriteLine("Information related to user id " + id + " updated without issues.");
                            Console.WriteLine();
                            Console.WriteLine(responseBody);
                            Console.WriteLine();
                            Console.ReadKey();
                        }
                    }
                }
            }
            catch (WebException ex)
            {
                Console.WriteLine("An issue occurred while updating the user, you can see the details next: ");
                Console.WriteLine();
                Console.WriteLine(ex.Message);
                Console.WriteLine();
            }
        }

        private static void DeleteItem(int id)
        {
            var url = $"https://gorest.co.in/public-api/users/{id}";
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "DELETE";
            request.ContentType = "application/json";
            request.Accept = "application/json";
            request.Headers.Add("Authorization", "Bearer 9641f867d9f4c141e46bc7b11c458233c1f83e34cb353916047b78227130db51");

            try
            {
                using (WebResponse response = request.GetResponse())
                {
                    using (Stream strReader = response.GetResponseStream())
                    {
                        if (strReader == null) return;
                        using (StreamReader objReader = new StreamReader(strReader))
                        {
                            string responseBody = objReader.ReadToEnd();
                            // Do something with responseBody
                            Console.WriteLine("User deleted without issues");
                            Console.WriteLine();
                            Console.WriteLine(responseBody);
                            Console.ReadKey();
                        }
                    }
                }
            }
            catch (WebException ex)
            {
                Console.WriteLine("An issue occurred while deleting the user, you can see the details next: ");
                Console.WriteLine();
                Console.WriteLine(ex.Message);
                Console.WriteLine();
            }
        }
    }
}
