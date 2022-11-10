using System;
using System.Diagnostics;

namespace CSharpFundamentals
{
    class Program : Program4
    {

        /*
         public - method will be accessible from another class
         void - return type and returns nothing
         
         */

        //IMPORTANT!!! Methods cannot go inside Main block
        //All class methods should be defined outside

        String firstName;
        String occupation;
        //constructor takes the same name as your class

        public Program(String firstName, String occupation)
        {
            this.firstName = firstName;
            this.occupation = occupation;
        }

        public void getName()
        {
            Console.WriteLine($"My name is {this.firstName}");
        }


        public void getPersonInfo()
        {

            char occupationFirstLetter = this.occupation[0];
            if ("aeiou".Contains(occupationFirstLetter))
            {

                Console.WriteLine($"My name is {this.firstName} " +
                $"and I am an {this.occupation}");

            }
            else {
                Console.WriteLine($"My name is {this.firstName} " +
                $"and I am a {this.occupation}");
            }
          
            
        }

        public void getData()
        {
            Console.WriteLine("I am inside getData method");
        }


        static void Main(string[] args)
        {

            // Classes amd methods with examples
            // you cannot create method directly - we need to create obbject of class first


            // new stands for memory allocation - creates new object in a memory
            Program testProgram = new Program("Riya", "student");
            Program user2 = new Program("Hannah", "orthodontist");

            testProgram.getData();

            // prints name using constructor
            // testProgram.getName();
            testProgram.getPersonInfo();
            user2.getPersonInfo();

            //inherintance from Program4 (parent) class
            testProgram.setData();



            Console.WriteLine("Hello World!");
            // Debug.WriteLine("Hello World!");

            // int and string are static data types
            int numberOne = 12;
            // String interpolation
            Console.WriteLine($"Number is: {numberOne}");

            //string name = "Oliver";

            //Console.WriteLine($"And name is {name}");

            // var is dynamic data type - use in case if you do not know which value your app returns
            var age = 23;
            Console.WriteLine(age);

            // var and dynamic are Dynamic data type -
            // !!!!! you can change/reinitialize data type to any type of data according
            // to program flow
            dynamic height = 5.7;

            height = 6.01;
            height = "six feet and one inch";
            Console.WriteLine($"Height is {height}");

            

        }
    }
}
