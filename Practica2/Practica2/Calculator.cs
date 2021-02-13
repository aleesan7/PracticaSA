using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Practica2
{
    class Calculator
    {
        public static double DoOperation(double num1, double num2, string op)
        {
            double result = double.NaN; // Default value is "not-a-number" which we use if an operation, such as division, could result in an error.

            // Use a switch statement to do the math.
            switch (op)
            {
                case "a":
                    result = double.Parse(AddNumbers(num1.ToString(), num2.ToString()));
                    break;
                case "s":
                    result = double.Parse(SubstractNumbers(num1.ToString(), num2.ToString()));
                    break;
                case "m":
                    result = double.Parse(MultiplyNumbers(num1.ToString(), num2.ToString()));
                    break;
                case "d":
                    // Ask the user to enter a non-zero divisor.
                    if (num2 != 0)
                    {
                        result = double.Parse(DivideNumbers(num1.ToString(), num2.ToString()));
                    }
                    break;
                // Return text for an incorrect option entry.
                default:
                    break;
            }
            return result;
        }

        //Method that requests to a web service the sum of two numbers and returns the result
        private static string AddNumbers(string firstNum, string secondNum)
        {
            var url = ConfigurationManager.AppSettings["dneonline"].ToString();
            var request = (HttpWebRequest)WebRequest.Create(url);
            string xmlRequest = "<?xml version=\"1.0\" encoding=\"utf - 8\"?>" +
                "<soap12:Envelope xmlns:xsi = \"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd = \"http://www.w3.org/2001/XMLSchema\" xmlns:soap12 = \"http://www.w3.org/2003/05/soap-envelope\" > " +
                    "<soap12:Body>" +
                        "<Add xmlns = \"http://tempuri.org/\" >" +
                            $"<intA> {firstNum} </intA>" +
                            $"<intB> {secondNum} </intB>" +
                        "</Add>" +
                    "</soap12:Body>" +
                "</soap12:Envelope> ";

            request.Method = "POST";
            request.ContentType = "text/xml;charset=\"utf-8\"";
            request.Accept = "text/xml";
            
            XmlDocument SOAPReqBody = new XmlDocument();
            //SOAP Body Request    
            SOAPReqBody.LoadXml(xmlRequest);
            
            using (var streamWriter = new StreamWriter(request.GetRequestStream()))
            {
                streamWriter.Write(xmlRequest);
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
                            Console.WriteLine();

                            XmlDocument resDoc = new XmlDocument();
                            resDoc.LoadXml(responseBody);

                            string result = resDoc.GetElementsByTagName("AddResult")[0].InnerText;

                            return result;
                        }
                    }
                }
            }
            catch (WebException ex)
            {
                Console.WriteLine(ex.Message);
                return ex.Message;
            }
        }

        private static string SubstractNumbers(string firstNum, string secondNum)
        {
            var url = ConfigurationManager.AppSettings["dneonline"].ToString();
            var request = (HttpWebRequest)WebRequest.Create(url);
            string xmlRequest = "<?xml version=\"1.0\" encoding=\"utf - 8\"?>" +
                "<soap12:Envelope xmlns:xsi = \"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd = \"http://www.w3.org/2001/XMLSchema\" xmlns:soap12 = \"http://www.w3.org/2003/05/soap-envelope\" > " +
                    "<soap12:Body>" +
                        "<Subtract xmlns = \"http://tempuri.org/\" >" +
                            $"<intA> {firstNum} </intA>" +
                            $"<intB> {secondNum} </intB>" +
                        "</Subtract>" +
                    "</soap12:Body>" +
                "</soap12:Envelope> ";

            request.Method = "POST";
            request.ContentType = "text/xml;charset=\"utf-8\"";
            request.Accept = "text/xml";

            XmlDocument SOAPReqBody = new XmlDocument();
            //SOAP Body Request    
            SOAPReqBody.LoadXml(xmlRequest);

            using (var streamWriter = new StreamWriter(request.GetRequestStream()))
            {
                streamWriter.Write(xmlRequest);
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

                            XmlDocument resDoc = new XmlDocument();
                            resDoc.LoadXml(responseBody);

                            string result = resDoc.GetElementsByTagName("SubtractResult")[0].InnerText;

                            return result;

                        }
                    }
                }
            }
            catch (WebException ex)
            {
                Console.WriteLine(ex.Message);
                return ex.Message;
            }
        }

        private static string MultiplyNumbers(string firstNum, string secondNum)
        {
            var url = ConfigurationManager.AppSettings["dneonline"].ToString();
            var request = (HttpWebRequest)WebRequest.Create(url);
            string xmlRequest = "<?xml version=\"1.0\" encoding=\"utf - 8\"?>" +
                "<soap12:Envelope xmlns:xsi = \"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd = \"http://www.w3.org/2001/XMLSchema\" xmlns:soap12 = \"http://www.w3.org/2003/05/soap-envelope\" > " +
                    "<soap12:Body>" +
                        "<Multiply xmlns = \"http://tempuri.org/\" >" +
                            $"<intA> {firstNum} </intA>" +
                            $"<intB> {secondNum} </intB>" +
                        "</Multiply>" +
                    "</soap12:Body>" +
                "</soap12:Envelope> ";

            request.Method = "POST";
            request.ContentType = "text/xml;charset=\"utf-8\"";
            request.Accept = "text/xml";

            XmlDocument SOAPReqBody = new XmlDocument();
            //SOAP Body Request    
            SOAPReqBody.LoadXml(xmlRequest);

            using (var streamWriter = new StreamWriter(request.GetRequestStream()))
            {
                streamWriter.Write(xmlRequest);
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

                            XmlDocument resDoc = new XmlDocument();
                            resDoc.LoadXml(responseBody);

                            string result = resDoc.GetElementsByTagName("MultiplyResult")[0].InnerText;

                            return result;

                        }
                    }
                }
            }
            catch (WebException ex)
            {
                Console.WriteLine(ex.Message);
                return ex.Message;
            }
        }

        private static string DivideNumbers(string firstNum, string secondNum)
        {
            var url = ConfigurationManager.AppSettings["dneonline"].ToString();
            var request = (HttpWebRequest)WebRequest.Create(url);
            string xmlRequest = "<?xml version=\"1.0\" encoding=\"utf - 8\"?>" +
                "<soap12:Envelope xmlns:xsi = \"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd = \"http://www.w3.org/2001/XMLSchema\" xmlns:soap12 = \"http://www.w3.org/2003/05/soap-envelope\" > " +
                    "<soap12:Body>" +
                        "<Divide xmlns = \"http://tempuri.org/\" >" +
                            $"<intA> {firstNum} </intA>" +
                            $"<intB> {secondNum} </intB>" +
                        "</Divide>" +
                    "</soap12:Body>" +
                "</soap12:Envelope> ";

            request.Method = "POST";
            request.ContentType = "text/xml;charset=\"utf-8\"";
            request.Accept = "text/xml";

            XmlDocument SOAPReqBody = new XmlDocument();
            //SOAP Body Request    
            SOAPReqBody.LoadXml(xmlRequest);

            using (var streamWriter = new StreamWriter(request.GetRequestStream()))
            {
                streamWriter.Write(xmlRequest);
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

                            XmlDocument resDoc = new XmlDocument();
                            resDoc.LoadXml(responseBody);

                            string result = resDoc.GetElementsByTagName("DivideResult")[0].InnerText;

                            return result;

                        }
                    }
                }
            }
            catch (WebException ex)
            {
                Console.WriteLine(ex.Message);
                return ex.Message;
            }
        }
    }
}
