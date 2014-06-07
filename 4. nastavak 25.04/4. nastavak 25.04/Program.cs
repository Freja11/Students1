using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4.nastavak_25._04
{
    class Program
    {
        static void Main(string[] args)
        {
                Student me = new Student("Amina","Bajre","ami199@hotmail.com","Sarajevo"); //Created new Student to represent you
                //Put your info name, last name etc. in quotes (string literals) 
                //me.SetFirstName("Jack");
                //me.SetLastName("Black");
                //me.SetEmail("JackBlack@gmail", out errorMsg);

                me.SetStudentScore(7.0, 8.0);
                string errorMsg = ""; 
                //me.SetLocation("Sarajevo");

                Console.WriteLine(me.ToString());
                Person p;
                Object o;
                Teacher t = new Teacher("Arif", "Cengic");
                Student s = new Student(); //Created another new Student, all properties empty
                string input;

                p = s;
                o = s; 

                //get user input for name, lastName, email, location
                Console.WriteLine("Enter name:");
                input = Console.ReadLine();
                while (!s.SetFirstName(input))
                {
                Console.WriteLine("Please try again and enter valid name:");
                input = Console.ReadLine();
                }

                Console.WriteLine("Enter last name:");
                s.SetLastName(Console.ReadLine());
                //get user input for email properties
                //get user input for location properties

                Console.WriteLine("Enter email:");
                input = Console.ReadLine();

                string errorMsg2 = ""; 
                while (!s.SetEmail(input, out errorMsg))
                {
                Console.WriteLine(errorMsg2);
                Console.WriteLine("Please try again and enter valid email:");
                input = Console.ReadLine();
                }


                Console.WriteLine("Enter student test score:");
                input = Console.ReadLine();

                double score;
                while (Double.TryParse(input, out score) != true)
                {
                Console.WriteLine("Invalid input please enter valid student test score:");
                input = Console.ReadLine();
                }


                s.SetStudentScore(score, score, score);
                Console.WriteLine("My average is: " + me.ScoreAvg());
                Console.WriteLine("Student average is: " + s.ScoreAvg());
                Student.CompareResult result = me.CompareScores(s); 

                switch(result)
                {
                case Student.CompareResult.Better:
                Console.WriteLine("My average is better");
                break;

                case Student.CompareResult.Worse:
                Console.WriteLine("My average is worse");
                break;

                case Student.CompareResult.Equal:
                Console.WriteLine("We have the same average");
                break;

                default:
                Console.WriteLine("We have Error in the code");
                break;
                }
                //SetStudentScore(0, score, s);
                Console.WriteLine(t.ToString());
                Console.WriteLine(s.ToString());
                Console.ReadLine();
                }
                        }
                    }

