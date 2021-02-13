using System;
using System.Collections.Generic;
using System.Configuration;
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
        //Main function of the program
        static void Main(string[] args)
        {
            //GetItems();
            //string newId = PostItem("Alejandro Sanchez", "Male", "2318153440101@ingenieria.usac.edu.gt", "Active");

            //if (!newId.Equals("")) { 
            //    GetItem(int.Parse(newId));
            //    PatchItem(int.Parse(newId), "Alejandro", "Male", "kevinalejandro@email.com", "Active");
            //    DeleteItem(int.Parse(newId));
            //}
            // Ask the user to choose an operator.

            ShowMainMenu();
        }

        //Displays the main menu of the application
        public static void ShowMainMenu()
        {
            //Clean the output
            Console.Clear();

            //Display the available options
            Console.WriteLine("Choose an option from the following list:");
            Console.WriteLine("\tg - Get list of users");
            Console.WriteLine("\tgu - Get especific user by id");
            Console.WriteLine("\tc - Create user");
            Console.WriteLine("\tu - Update user");
            Console.WriteLine("\td - Delete user");
            Console.WriteLine("\te - Exit");
            Console.Write("Your option? ");

            string action = Console.ReadLine();

            //Route to the desired option
            OptionsRouter(action);
        }


        //Routes the flow of the applications based on the option that the user selected
        public static void OptionsRouter(string action)
        {
            switch (action)
            {
                case "g":
                    GetItems();
                    ShowMainMenu();
                    break;
                case "gu":
                    ShowGetUserMenu();
                    ShowMainMenu();
                    break;
                case "c":
                    ShowCreateUserMenu();
                    ShowMainMenu();
                    break;
                case "u":
                    ShowUpdateUserMenu();
                    ShowMainMenu();
                    break;
                case "d":
                    ShowDeleteUserMenu();
                    ShowMainMenu();
                    break;
                case "e":
                    Environment.Exit(0);
                    break;
            }
        }

        //Displays the menu for the get user option
        public static void ShowGetUserMenu()
        {
            // Declare variables and set to empty.
            string userID = "";

            // Ask the user to type the first number.
            Console.Write("Type an user ID, and then press Enter: ");
            userID = Console.ReadLine();

            GetItem(int.Parse(userID));
        }

        //Displays the menu for the create user option
        public static void ShowCreateUserMenu()
        {
            // Declare variables and set to empty.
            string name = "";
            string gender = "";
            string email = "";
            string status = "";

            // Ask the user to type the name.
            Console.Write("Type the name of the new user, and then press Enter: ");
            name = Console.ReadLine();

            // Ask the user to type the gender.
            Console.Write("Type the gender of the new user, and then press Enter: ");
            gender = Console.ReadLine();

            // Ask the user to type the email.
            Console.Write("Type the email of the new user, and then press Enter: ");
            email = Console.ReadLine();

            // Ask the user to type the status.
            Console.Write("Type the status of the new user, and then press Enter: ");
            status = Console.ReadLine();

            PostItem(name, gender, email, status);
        }

        //Displays the menu for the update user option
        public static void ShowUpdateUserMenu()
        {
            // Declare variables and set to empty.
            string userID = "";
            string name = "";
            string gender = "";
            string email = "";
            string status = "";

            //Ask the user to type the id of the user to update
            Console.Write("Type the id of the user to update, and then press Enter: ");
            userID = Console.ReadLine();

            // Ask the user to type the name.
            Console.Write("Type the new name of the user, and then press Enter: ");
            name = Console.ReadLine();

            // Ask the user to type the gender.
            Console.Write("Type the new gender of the user, and then press Enter: ");
            gender = Console.ReadLine();

            // Ask the user to type the email.
            Console.Write("Type the new email of the user, and then press Enter: ");
            email = Console.ReadLine();

            // Ask the user to type the status.
            Console.Write("Type the new status of the user, and then press Enter: ");
            status = Console.ReadLine();

            PatchItem(int.Parse(userID), name, gender, email, status);
        }

        //Displays the menu for the delete user option
        public static void ShowDeleteUserMenu()
        {
            // Declare variables and set to empty.
            string userID = "";

            // Ask the user to type the first number.
            Console.Write("Type the user ID of the user to delete, and then press Enter: ");
            userID = Console.ReadLine();

            DeleteItem(int.Parse(userID));
        }

        //Method that gets a specific user
        private static void GetItem(int id)
        {
            var url = ConfigurationManager.AppSettings["goRestURL"].ToString() + $"{id}";
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

        //Method that gets all the users
        private static void GetItems()
        {
            var url = ConfigurationManager.AppSettings["goRestURL"].ToString();
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

        //Method that creates a new user
        private static string PostItem(string name, string gender, string email, string status)
        {
            var url = ConfigurationManager.AppSettings["goRestURL"].ToString();
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

        //Method that updates an existing user
        private static void PatchItem(int id, string name, string gender, string email, string status)
        {
            var url = ConfigurationManager.AppSettings["goRestURL"].ToString() + $"{id}";
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

        //Method that deletes an existing user
        private static void DeleteItem(int id)
        {
            var url = ConfigurationManager.AppSettings["goRestURL"].ToString() + $"{id}";
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
