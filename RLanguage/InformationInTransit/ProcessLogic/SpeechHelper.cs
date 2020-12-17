#region Using directives
using System;
using System.Collections.Generic;
using System.Text;

using System.Speech.Synthesis;
#endregion

namespace InformationInTransit.ProcessLogic
{
    //2017-06-27 Created.	http://www.codemag.com/article/1707091
	public partial class SpeechHelper
    {
		public static void Main(string[] argv)
		{
			Stub();
		}		
		
		//2017-06-27 http://www.codemag.com/article/1707091
		public static void Stub()
		{
			using (var synth = new SpeechSynthesizer())
			{
				// Configure the audio output.
				synth.SetOutputToDefaultAudioDevice();
				var text = new PromptBuilder();
				text.AppendSsmlMarkup
				(
					//@"<say-as interpret-as = \"characters\"> Hello World! </say-as>"
					"Hello world."
				);
				synth.Speak(text);
			}
		}		
    }
}