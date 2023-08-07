using Kryptering_1___Hashing.Enums;
using Kryptering_1___Hashing.Managers.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kryptering_1___Hashing.Views
{
    /// <summary>
    /// View for hash related menues
    /// </summary>
    internal class HashView : IViewable
    {
        private readonly IHashManager hashManager;

        public HashView(IHashManager hashManager)
        {
            this.hashManager = hashManager;
        }

        public void Show()
        {
            bool looper = true;
            do
            {
                Console.Clear(); 
                Console.WriteLine("Write the text to be hashed:");
                string input = Console.ReadLine();
                Console.WriteLine();
                Console.WriteLine("Write key for HMAC hashing, leave empty for regular hashing");
                string key = Console.ReadLine();
                Console.WriteLine();
                Console.WriteLine("Choose Hashing method:");
                // Show Enum options
                foreach (HashingMethods hashMethod in Enum.GetValues(typeof(HashingMethods)))
                {
                    Console.WriteLine(((int)hashMethod + 1) + ". " + hashMethod.ToString()); 
                }
                Console.WriteLine("ESC. To cancel");
                Console.WriteLine("-----------------");
                ConsoleKeyInfo userChoice = Console.ReadKey();
                Console.WriteLine();

                HashingMethods? hashingMethod = null;
                // Evaluate the user choice
                switch (userChoice.Key)
                {
                    case ConsoleKey.D1:
                        hashingMethod = HashingMethods.MD5;
                        looper = false;
                        break;
                    case ConsoleKey.D2:
                        hashingMethod = HashingMethods.SHA1;
                        looper = false;
                        break;
                    case ConsoleKey.D3:
                        hashingMethod = HashingMethods.SHA256;
                        looper = false;
                        break;
                    case ConsoleKey.D4:
                        hashingMethod = HashingMethods.SHA512;
                        looper = false;
                        break;
                    case ConsoleKey.Escape:
                        looper = false;
                        break;
                    default:
                        Console.WriteLine("Input not recognised, please try again");
                        break;
                }
                if(string.IsNullOrEmpty(key))
                {
                    Stopwatch stopwatch = new Stopwatch();
                    stopwatch.Start();
                    byte[] hashedData = hashManager.Hash(input, (HashingMethods)hashingMethod);
                    stopwatch.Stop();
                    Console.WriteLine(hashingMethod + " Hash: " + BitConverter.ToString(hashedData));
                    Console.WriteLine(stopwatch.ElapsedTicks + " ticks");
                }
                else
                {
                    Stopwatch stopwatch = new Stopwatch();
                    // Getting HASH data
                    stopwatch.Start();
                    byte[] hashedData = hashManager.Hash(input, (HashingMethods)hashingMethod);
                    stopwatch.Stop();
                    Console.WriteLine(hashingMethod + " Hash: " + BitConverter.ToString(hashedData));
                    Console.WriteLine(stopwatch.ElapsedTicks + " ticks");

                    // Getting HMAC hash data
                    stopwatch.Restart();
                    byte[] hashedHmacData = hashManager.HashWithKey(input, key, (HashingMethods)hashingMethod);
                    stopwatch.Stop();
                    Console.WriteLine("HMAC" + hashingMethod + " Hash: " + BitConverter.ToString(hashedHmacData));
                    Console.WriteLine(stopwatch.ElapsedTicks + " ticks");
                }
                Console.WriteLine();
                Console.WriteLine("Enter any key to continue");
                Console.ReadKey(); // Await user input to allow user time to read information
            } while (looper);
        }
    }
}
