using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InformationInTransit.ProcessLogic
{
    public enum CharType
    {
        Control,
        Digit,
        Letter,
        Punctuation,
        Separator,
        Symbol,
        Whitespace,
        Unknown
    }

    public static partial class CharHelper
    {
        public static CharType GetCharType(this char c)
        {
            if (Char.IsControl(c))
                return CharType.Control;
            else if (Char.IsDigit(c))
                return CharType.Digit;
            else if (Char.IsLetter(c))
                return CharType.Letter;
            else if (Char.IsPunctuation(c))
                return CharType.Punctuation;
            else if (Char.IsSeparator(c))
                return CharType.Separator;
            else if (Char.IsSymbol(c))
                return CharType.Symbol;
            else if (Char.IsWhiteSpace(c))
                return CharType.Whitespace;
            else
                return CharType.Unknown;
        }

        /*
        private void txtChar_KeyPress(object sender, KeyPressEventArgs e)
        {
            //lblChar.Text = e.KeyChar.GetCharType().ToString();
            switch (e.KeyChar.GetCharType())
            {
                case CharType.Digit:
                    e.KeyChar = '~';
                    break;
            }
        }
        */
    }
}
