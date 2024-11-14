namespace WordEngineering
{
 public class UtilityDelegate
 {

  private delegate string StringFunction(string english);

  public static void Main(string[] argv)
  {
   //Create a delegate variable.
   StringFunction functionReference;

   //Store a reference to a matching method in the delegate.
   functionReference = TranslateEnglishToFrench;

   //Run the method that functionReference points to.
   //In this case, it will be TranslateEnglishToFrench
   string frenchSTring = functionReference("Girl");
  }

  public static string TranslateEnglishToFrench(string english)
  {
   string french = "Elle";
   System.Console.WriteLine("English: {0} | French: {1}",english,french);
   return (french);
  }
 }
}