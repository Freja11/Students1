using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4.nastavak_25._04
{


   class Person

   {
        protected string name;
        protected string lastName;
        protected string email;
        protected string location;

        public void SetLocation(string input)
{

if (input.ToUpper() == "SA" ||
//input == "sa" || 
//input == "Sa" || 
//input == "Sarajevo" || 
input.ToUpper() == "SARAJEVO")
{
location = "SA";
}

if (input == "TZ" || input == "Tuzla" || input == "TUZLA")
{
location = "TZ";
}

}
        public bool SetEmail(string input, out string errorMsg)
{
// 1. String has to contain "@" character
if (!input.Contains("@"))
{
errorMsg = "String has to contain '@' character";
return false;
}

//2. String has to contain at least one "." after "@"character
char[] arrayChar = input.ToCharArray();

//int indexAt = input.IndexOf('@');
//for (int i = indexAt; i < arrayChar.Length; i = i + 1)
//{
// if (arrayChar[i] == '.')
// {
// foundDot = true;
// }
// }

bool foundAtChar = false;
//int dotCount = 0;
bool foundDot = false;

for (int i = 0; i < arrayChar.Length; i = i + 1)
{
if (arrayChar[i] == '@')
{
foundAtChar = true;
continue;
}

if (foundAtChar)
{
if (arrayChar[i] == '.')
{
foundDot = true;
break;
}

}
}

if (!foundDot)
{
errorMsg = "String has to contain at least one '.' after '@'character";
return false;
}

// 3. String has to have one of following (domains) including last dot ".com", ".ba" or ".edu"
//string endString = input.Substring(input.Length - 4);
//string endString3 = input.Substring(input.Length - 3);

//if (endString != ".com" && endString != ".edu" && endString3 != ".ba")
if (!input.EndsWith(".com") && !input.EndsWith(".edu") && !input.EndsWith(".ba"))
{
errorMsg = "String has to end '.com', '.ba' or '.edu'";
return false;
}


// 4. String has to have at least one character before "@"
int indexAt = input.IndexOf('@');
if (indexAt == 0)
{
errorMsg = "String has to have at least one character before '@'";
return false;
}

//5. In addition to @ and . string can only contain alpha numeric characters and underscore "_". 
foreach (char c in arrayChar)
{
if (!(char.IsLetterOrDigit(c) || c == '@' || c == '_' || c == '.'))
{
errorMsg = "In addition to @ and . string can only contain alpha numeric characters and underscore ";
return false;
}
}
//if here input is Valid email
errorMsg = string.Empty;

this.email = input;
return true;
}
        public bool SetLastName(string input)
{
if (CheckName(input))
{
this.lastName = input;
return true;
}
else
{
return false;
}
}
        public bool SetFirstName(string input)
{
if (CheckName(input))
{
this.name = input;
return true;
}
else
{
return false;
}
}
        private bool CheckName(string input)
{
if (input.Length < 2)
{
//Name has to be at least 2 characters long
return false;
}

char[] chArray = input.ToCharArray();
int count = 0;
foreach (char c in chArray)
{
if (count == 0 && !char.IsUpper(c)) //first letter
{
// First character has to be upper case letter
return false;
}

if (count != 0 && !char.IsLower(c)) //for all other letters except first one
{
return false;
}
count++;
}

return true;
}

       public override string ToString() { return "Person:" + name + ", " + lastName; }
}

   class Teacher : Person
   {
       public Teacher(string name, string lastName) // CONSTRUCTOR METHODE
       {
           this.name = name;
           this.lastName = lastName; // we asked for the name and last name, this for something inside of the class (parameter name)
           Console.WriteLine("Teacher constructor");
       }
   }
   class Student : Person
 {
            public Student() { } // empty student, you've to enter name

         public Student(string name, string lastName, string email)
            {
                this.name = name;
                this.lastName = lastName;
                this.email = email; 
            }           

            public Student(string name, string lastName, string email, string location)
            {
                this.email = email;  
                this.location = location; 
                this.name = name; 
                this.lastName = lastName;
                Console.WriteLine("Student constructor");
            }

            //public string name, lastName, email, location; 
//Declare each propery in single statement (line)
          private double[] testResults = new double[10] { -1, -1, -1, -1, -1, -1, -1, -1, -1, -1 }; //total 10 test results


          public override string ToString()
     {
//change following statement it displays info in format Student Jack, Black from Sarajevo 
     return string.Format("Student {0}, {1} from {2} with email {3}", name, lastName, location, email);
     }
          public bool SetStudentScore(int index, double score)
{
//check arguments
    if (index < 0 || index > 9)
    {
//index is out of bounds
       return false;
    }
    if (score < 1 || score > 10)
    {
//score has to be between 1 and 10
    return false;
    }

//all valid input arguments
    testResults[index] = score;
    return true;
    }

          public enum CompareResult
    {
        Equal,
        Better,
        Worse
    }
// returns -1 if first student is worse then second, 0 if same
          public CompareResult CompareScores(Student second)
    {
    if (this.ScoreAvg() > second.ScoreAvg())
    {
    return CompareResult.Better;
//Console.WriteLine("My average is better");
    }
    else
    {
    if (this.ScoreAvg() < second.ScoreAvg())
    {
//Console.WriteLine("My average is worse");
    return CompareResult.Worse;
    }
    else
    {
//Console.WriteLine("We have the same average");
    return CompareResult.Equal;
       }
    }
}

          public bool SetStudentScore( params double[] scores)
    {

    if (scores.Length > testResults.Length) //
    {
//Var arguments limit
    return false;
    }

        for (int i = 0; i < scores.Length; i++)
    {
    if (scores[i] < 1 || scores[i] > 10)
    {
//score has to be between 1 and 10
    return false;
    }

    testResults[i] = scores[i];

    }

    return true;
    }
          public double ScoreAvg()
    {
    double sum = 0.0;
    int count = 0;

    for (int i = 0; i < testResults.Length; i++)
    {
        if (testResults[i] == -1)
    {
        continue;
}

 sum += testResults[i];
 count++;
}
    return sum / count;
}
}

   class CITA180
{
public const string name = "Introduction to programming"; //can't touch this
Student[] students;
//schedule 
//Syllabus
//Teacher
}
}
    
