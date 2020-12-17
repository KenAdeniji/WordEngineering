using com.dominicsayers.isemail;

namespace InformationInTransit.ProcessLogic
{
	///<remarks>
	///2014-09-20 isemail.info
	///</remarks>
	public static partial class IsEMailHelper
	{
		public static void Main(string[] argv)
		{
			IsEMail isEMail = new IsEMail();
			foreach(string argument in argv)
			{
				bool isEmailValid = isEMail.IsEmailValid(argument);
				System.Console.WriteLine
				(
					"Email address: {0} | IsValid: {1}",
					argument,
					isEmailValid
				);	
			}
		}
	}
}
