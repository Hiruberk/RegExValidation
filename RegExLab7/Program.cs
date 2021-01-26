using System;
using System.Text.RegularExpressions;

namespace RegExLab7
{
    class Program
    {
        //Nate Davis
        //C# .NET Daytime GC
        //Regex Lab
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Regular Expressions!");

            Console.WriteLine("\nPlease enter your name with a capital first Letter: ");//First Requirement
            string name = VoidCheck(Console.ReadLine());//Checks if it is a null then brings a non-null string back

            bool again = true;//Intializing all my do-while conditions, so it will break when a valid answer is entered.
            bool emailAgain = true;
            bool phoneAgain = true;
            bool dateAgain = true;

            do//First do-while to insure a valid name is entered
                if (ValidateName(name) == true)//If the name is valid will output write line and break loop.
                {
                    Console.WriteLine($"\nIt checks out! Welcome {name}");
                    again = false;
                }
                else//If it is not valid will ask them to do it over and over until it is a valid answer.
                {
                    Console.WriteLine($"\nCome on, {name} is not a real name!");
                    Console.WriteLine("Try Again\n");
                    name = Console.ReadLine();
                } 
            while (again == true);

            Console.WriteLine("\nPlease enter your email: ");
            string email = VoidCheck(Console.ReadLine());//Checks if it is a null then brings a non-null string back

            do//Second do-while to insure a valid email is entered
                if (ValidateEmail(email) == true)//If the email is valid will output write line and break loop.
                {
                    Console.WriteLine($"\nOkay...Did you make {email} when you were in 7th grade? Yikes...");
                    emailAgain = false;
                }
                else//If it is not valid will ask them to do it over and over until it is a valid answer.
                {
                    Console.WriteLine($"\nCome on, we both know {email} is not valid!");
                    Console.WriteLine("Try again!\n");
                    email = Console.ReadLine();
                } 
            while (emailAgain == true);

            Console.WriteLine("\nPlease enter your phone number: ");
            string phone = VoidCheck(Console.ReadLine());//Checks if it is a null then brings a non-null string back

            do//third do-while to insure a valid phone is entered
                if (ValidatePhone(phone) == true)//If the phone is valid will output write line and break loop.
                {
                    Console.WriteLine($"\n Score! I promise I won't give {phone} out to spammers!");
                    phoneAgain = false;
                }
                else//If it is not valid will ask them to do it over and over until it is a valid answer.
                {
                    Console.WriteLine($"\nThis {phone} is not your number!");
                    Console.WriteLine("Try again!\n");
                    phone = Console.ReadLine();
                }
            while (phoneAgain == true);

            Console.WriteLine("\nPlease enter the date (dd/mm/yyyy): ");
            string date = VoidCheck(Console.ReadLine());//Checks if it is a null then brings a non-null string back

            do//Fourth do-while to insure a valid date is entered
                if (ValidateDate(date) == true)//If the date is valid will output write line and break loop.
                {
                    Console.WriteLine($"\nWait.. Is it really {date}, OH SHOOT! I've got to go, goodbye! {name}\n");    //End of Program when all criteria is valid.
                    dateAgain = false;
                }
                else//If it is not valid will ask them to do it over and over until it is a valid answer.
                {
                    Console.WriteLine($"\nIs your head okay? It is definitely not {date}");
                    Console.WriteLine("Try again!\n");
                    date = Console.ReadLine();
                }
            while (dateAgain == true);
        }

        /// <summary>
        /// This checks the user input to insure it is not taking a void or an empty space.
        /// </summary>
        /// <param name="input"></param>
        /// <returns>Returns a valid string that is not an empty space or null.</returns>
        public static string VoidCheck(string input)
        {
            string userInput = input;
            bool again = true;

            while(again == true)
            {
                if (userInput == " " || String.IsNullOrEmpty(userInput))
                {
                    Console.WriteLine("Please enter the requested requirements!\n");
                    userInput = Console.ReadLine();
                }
                else
                {
                    again = false;
                }
            }
            return userInput;
        }

        /// <summary>
        /// When given a string validates that it meets the criteria of a name. 
        /// A capital first letter is needed and it cannot be more than 30 characters.
        /// Spaces are allowed.
        /// </summary>
        /// <param name="name"></param>
        /// <returns>Returns a bool indicating whether the name meets the criteria.</returns>
        public static bool ValidateName(string name)
        {
            Regex validName = new Regex(@"^[A-Z][A-Za-z]{0,29}(?<=[a-z])$");
            
            if (validName.IsMatch(name))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// When given a string validates that it meets the criteria of an email.
        /// It can have alphanumeric characters up to 30 followed by an "@",
        /// a domain that can range from 2 to 10 characters followed by a ".",
        /// then ending in 2-3 characters. No special characters are allowed.
        /// </summary>
        /// <param name="email"></param>
        /// <returns>Returns a bool indicating whether the email meets the criteria</returns>
        public static bool ValidateEmail(string email)
        {
            Regex validEmail = new Regex(@"^([\w]+)@([\w]+)((\.(\w){2,3})+)$");

            if (validEmail.IsMatch(email))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// When given a string validates that it meets the criteria of a phone number.
        /// It can be seperated by spaces, "-", "()" or ".", but has to be 10 digits long.
        /// </summary>
        /// <param name="phone"></param>
        /// <returns>Returns a bool indicating whether the phone number meets the criteria</returns>
        public static bool ValidatePhone(string phone)
        {
            Regex validPhone = new Regex(@"\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})");

            if (validPhone.IsMatch(phone))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// When given a string validates that it meets the criteria of a date.
        /// It must follow the format of dd/mm/yyyy.
        /// </summary>
        /// <param name="date"></param>
        /// <returns>Returns a bool indicating whether the date meets the criteria</returns>
        public static bool ValidateDate(string date)
        {
            Regex validDate = new Regex(@"^(0?[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d$");

            if (validDate.IsMatch(date))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
