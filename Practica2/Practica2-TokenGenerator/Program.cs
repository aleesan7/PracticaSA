using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica2_TokenGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            bool endApp = false;
            Hashtable tokens = new Hashtable();
            
            // Display title as the C# console calculator app.
            Console.WriteLine("JWT Token Generator in C#\r");
            Console.WriteLine("------------------------\n");

            while (!endApp)
            {
                // Declare variables and set to empty.
                string secret = "";//Guid.NewGuid().ToString().Substring(0, 32);
                string header = "{\"typ\": \"JWT\", \"alg\": \"HS256\"}";
                string name = "";
                string studentID = "";
                string token = "";

                string tokenToValidate = "";
                string tokenToCompare = "";
                string decodedPayload = "";
                // Ask the user to choose an operator.
                Console.WriteLine("Choose an operator from the following list:");
                Console.WriteLine("\tg - Generate Token");
                Console.WriteLine("\tv - Validate Token");
                Console.Write("Your option? ");

                string op = Console.ReadLine();

                try
                {
                    switch (op)
                    {
                        case "g":
                            // Ask the user to type the first number.
                            Console.Write("Type a name, and then press Enter: ");
                            name = Console.ReadLine();

                            // Ask the user to type the second number.
                            Console.Write("Type the student id, and then press Enter: ");
                            studentID = Console.ReadLine();

                            secret = Guid.NewGuid().ToString().Substring(0, 32);

                            tokens.Add(studentID, secret);

                            TokenGenerator generator = new TokenGenerator();
                            
                            token = generator.GenerateToken(name, studentID, header, secret);

                            Console.WriteLine("Your new token is: ");
                            Console.WriteLine(token);
                            break;
                        case "v":
                            Console.Write("Enter the token you want to validate: ");
                            tokenToValidate = Console.ReadLine();

                            TokenGenerator decoder = new TokenGenerator();
                            
                            decodedPayload = decoder.ObtainPayLoadFromToken(tokenToValidate);

                            string obtainedName = JObject.Parse(decodedPayload)["name"].ToString();
                            string obtainedStudentID = JObject.Parse(decodedPayload)["studentID"].ToString();

                            secret = tokens[obtainedStudentID].ToString();

                            tokenToCompare = decoder.GenerateToken(obtainedName, obtainedStudentID, header, secret);

                            if (tokenToValidate.Equals(tokenToCompare))
                            {
                                Console.WriteLine();
                                Console.WriteLine("The token is valid!");
                                Console.WriteLine();
                            }
                            else
                            {
                                Console.WriteLine();
                                Console.WriteLine("The token isn´t valid");
                                Console.WriteLine();
                            }

                            break;
                    }
                    
                }
                catch (Exception e)
                {
                    Console.WriteLine("Oh no! An exception occurred trying to perform the operation.\n - Details: " + e.Message);
                }

                Console.WriteLine("-----------------------------------------------------------------------\n");

                // Wait for the user to respond before closing.
                Console.Write("Press 'n' and Enter to close the app, or press any other key and Enter to continue: ");
                if (Console.ReadLine() == "n") endApp = true;

                Console.Clear();
                Console.WriteLine("\n"); // Friendly linespacing.
            }
            return;
        }
    }
}
