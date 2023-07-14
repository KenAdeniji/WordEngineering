using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InformationInTransit.ProcessCode
{
	/*
		2023-07-1315:59:00 ... 2023-07-1316:16:00
			http://www.blackwasp.co.uk/soundex.aspx
			http://www.blackwasp.co.uk/soundex_2.aspx
	*/
    public class SoundexUtility
    {
        public string DetermineSoundex(string value)
        {
            value = value.ToUpper();
            StringBuilder soundex = new StringBuilder();

            foreach (char ch in value)
            {
                if (char.IsLetter(ch))
                    AddCharacter(soundex, ch);
            }

            RemovePlaceholders(soundex);
            FixLength(soundex);
            return soundex.ToString();
        }

        private void AddCharacter(StringBuilder soundex, char ch)
        {
            if (soundex.Length == 0)
                soundex.Append(ch);
            else
            {
                string code = DetermineSoundexDigit(ch);
                if (code != soundex[soundex.Length - 1].ToString())
                    soundex.Append(code);
            }
        }

        private string DetermineSoundexDigit(char ch)
        {
            string chString = ch.ToString();

            if ("BFPV".Contains(chString))
                return "1";
            else if ("CGJKQSXZ".Contains(chString))
                return "2";
            else if ("DT".Contains(chString))
                return "3";
            else if (ch == 'L')
                return "4";
            else if ("MN".Contains(chString))
                return "5";
            else if (ch == 'R')
                return "6";
            else
                return ".";
        }

        private void RemovePlaceholders(StringBuilder soundex)
        {
            soundex.Replace(".", "");
        }

        private void FixLength(StringBuilder soundex)
        {
            int length = soundex.Length;
            if (length < 4)
                soundex.Append(new string('0', 4 - length));
            else
                soundex.Length = 4;
        }

        public int Compare(string value1, string value2)
        {
            int matches = 0;
            string soundex1 = DetermineSoundex(value1);
            string soundex2 = DetermineSoundex(value2);

            for (int i = 0; i < 4; i++)
                if (soundex1[i] == soundex2[i]) matches++;

            return matches;
        }
    }
}
