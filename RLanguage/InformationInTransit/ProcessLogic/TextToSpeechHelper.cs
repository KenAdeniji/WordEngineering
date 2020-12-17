using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Collections;
using System.IO;

namespace InformationInTransit.ProcessLogic
{
    public static partial class TextToSpeechHelper
    {
        public static void Main(string[] argv)
        {
            var files = Say(Directory.GetFiles("c:\\"));
            Say("and the total size is");
            var size = files.Select(x => new FileInfo(x).Length).Sum();
            Say(size);
            Say("bytes");
        }

        public static T Say<T>(this T thing)
        {
            const int enumerableLimit = 100;

            object obj = thing;
            if (obj == null)
            {
                obj = "null reference";
            }

            var enumerable = obj as IEnumerable;
            if (enumerable != null && obj.GetType() != typeof(string))
            {
                var items = enumerable.OfType<object>().Take(enumerableLimit + 1).ToList();
                if (items.Count == enumerableLimit + 1)
                {
                    items[enumerableLimit] = "and so on";
                }
                foreach (var x in items)
                {
                    Say(x);
                }
            }
            else
            {
                using (var synth = new System.Speech.Synthesis.SpeechSynthesizer())
                {
                    synth.Speak(obj.ToString());
                }
            }
            return thing;
        }
    }
}
