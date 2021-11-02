using System;
using System.IO;
using System.Reflection;

// To execute C#, please define "static void Main" on a class
// named Solution.

/*
Design a solution focusing on Object Oriented Programming principals.

Consider the following:

Given an instruction file coming in and giving a list of commands each with their own specific data.

Instruction Files come in the format of: <EPOCH TIMESTAMP> <MessageType> <data>

Use OOP to design a program to parse line by line. Each MesageType has its own data formating.

Each MessageType needs to have its own Parse function and Execute command function.

EX file:

1630592861 createFile “c:\file.txt”

1630592861 deleteFie “c:\File.txt”

1630592862 moveFile “C:\File.txt D:\NewFolder\File.txt’

1630592863 ListenToPort “Port:3334 Timeout:100”
Time elapsed: 18 minutes (of 120 minutes)
*/

/*
	https://stackoverflow.com/questions/8251951/call-a-method-dynamically-based-on-some-other-variable
	https://stackoverflow.com/questions/7356367/how-to-call-method-using-its-name
	https://stackoverflow.com/questions/21855840/c-sharp-reflection-invoke-object-of-type-xxx-cannot-be-converted-to-type-sy
*/	

// 2021-11-02T12:17:00 ... 2021-11-02T15:10:00
class Solution
{
    static void Main(string[] args)
    {
        // Open the file to read from.
        using (StreamReader sr = File.OpenText(InstructionPathFilename))
        {
            string s;
            string[] words;
			string epochTimestamp;
			string messageType;

			MethodInfo method;
			object[] parameters;



            while ((s = sr.ReadLine()) != null)
            {
                Console.WriteLine(s);

                words = s.Split(' ');

				epochTimestamp = words[EPOCHTIMESTAMP_Position];
				messageType = words[MessageType_Position].Trim();
				parameters = new object[] { new object[] { words[Data_Position] } };

				try
				{
					var type = typeof(Solution);
					object obj = new Solution();
			
					//var methodParse = type.GetMethod(messageType + "Parse");
					//methodParse.Invoke(obj, parameters);

					//var methodExecute = type.GetMethod(messageType + "Execute");
					//methodExecute.Invoke(obj, parameters);
					
					method = obj.GetType().GetMethod
					(
						messageType + "Parse", 
						BindingFlags.Public|BindingFlags.Instance
					);
					method.Invoke(obj, parameters);

					method = obj.GetType().GetMethod
					(
						messageType + "Execute", 
						BindingFlags.Public|BindingFlags.Instance
					);
					method.Invoke(obj, parameters);
				}
				catch(Exception ex)
				{
					System.Console.WriteLine(ex.Message);
				}	
            }
        }        
    }
	
	public void createFileParse(params object[] parameters)
	{
	
	}
	
	public void createFileExecute(params object[] parameters)
	{
		//StreamWriter sw = File.CreateText((string)parameters[0]);
	}
	
	public void deleteFileParse(params object[] parameters)
	{
	
	}
	
	public void deleteFileExecute(params object[] parameters)
	{
	}

	public void moveFileParse(params object[] parameters)
	{
	
	}
	
	public void moveFileExecute(params object[] parameters)
	{

	}
	
	public void ListenToPortParse(params object[] parameters)
	{
	
	}
	
	public void ListenToPortExecute(params object[] parameters)
	{

	}
	
	public const string InstructionPathFilename = @"Instruction.txt";    
	
	public const int EPOCHTIMESTAMP_Position = 0;
	public const int MessageType_Position = 1;
	public const int Data_Position = 1;
}
