using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Threading.Tasks;

namespace BlazorSelector.Data
{
    public class Letters
    {
        #region Letters
        //private string[] _A =
        //{
        //    " XXX ",
        //    "X   X",
        //    "X   X",
        //    "XXXXX",
        //    "X   X",
        //    "X   X",
        //    "X   X",
        //};

        //private string[] _B =
        //{
        //    "XXXX ",
        //    "X   X",
        //    "X   X",
        //    "XXXX ",
        //    "X   X",
        //    "X   X",
        //    "XXXX ",
        //};

        //private string[] _C =
        //{
        //    " XXXX",
        //    "X    ",
        //    "X    ",
        //    "X    ",
        //    "X    ",
        //    "X    ",
        //    " XXXX",
        //};

        //private string[] _D =
        //{
        //    "XXXX ",
        //    "X   X",
        //    "X   X",
        //    "X   X",
        //    "X   X",
        //    "X   X",
        //    "XXXX ",
        //};

        //private string[] _E =
        //{
        //    "XXXXX",
        //    "X    ",
        //    "X    ",
        //    "XXXX ",
        //    "X    ",
        //    "X    ",
        //    "XXXXX",
        //};

        //private string[] _F =
        //{
        //    "XXXXX",
        //    "X    ",
        //    "X    ",
        //    "XXXX ",
        //    "X    ",
        //    "X    ",
        //    "X    ",
        //};

        //private string[] _G =
        //{
        //    " XXX ",
        //    "X    ",
        //    "X    ",
        //    "X  XX",
        //    "X   X",
        //    "X   X",
        //    " XXX ",
        //};

        //private string[] _H =
        //{
        //    "X   X",
        //    "X   X",
        //    "X   X",
        //    "XXXXX",
        //    "X   X",
        //    "X   X",
        //    "X   X",
        //};

        //private string[] _I =
        //{
        //    "  X  ",
        //    "  X  ",
        //    "  X  ",
        //    "  X  ",
        //    "  X  ",
        //    "  X  ",
        //    "  X  ",
        //};

        //private string[] _J =
        //{
        //    "  XXX",
        //    "    X",
        //    "    X",
        //    "    X",
        //    "    X",
        //    "X   X",
        //    " XXX ",
        //};

        //private string[] _K =
        //{
        //    "X   X",
        //    "X  X ",
        //    "X X  ",
        //    "XX   ",
        //    "X X  ",
        //    "X  X ",
        //    "X   X",
        //};

        //private string[] _L =
        //{
        //    "X    ",
        //    "X    ",
        //    "X    ",
        //    "X    ",
        //    "X    ",
        //    "X    ",
        //    "XXXXX",
        //};

        //private string[] _M =
        //{
        //    "X   X",
        //    "XX XX",
        //    "X X X",
        //    "X   X",
        //    "X   X",
        //    "X   X",
        //    "X   X",
        //};

        //private string[] _N =
        //{
        //    "X   X",
        //    "X   X",
        //    "XX  X",
        //    "X X X",
        //    "X  XX",
        //    "X   X",
        //    "X   X",
        //};

        //private string[] _O =
        //{
        //    " XXX ",
        //    "X   X",
        //    "X   X",
        //    "X   X",
        //    "X   X",
        //    "X   X",
        //    " XXX ",
        //};

        //private string[] _P =
        //{
        //    "XXXX ",
        //    "X   X",
        //    "X   X",
        //    "XXXX ",
        //    "X    ",
        //    "X    ",
        //    "X    ",
        //};

        //private string[] _Q =
        //{
        //    " XXX ",
        //    "X   X",
        //    "X   X",
        //    "X   X",
        //    "X   X",
        //    "X  X ",
        //    " XX X",
        //};

        //private string[] _R =
        //{
        //    "XXXX ",
        //    "X   X",
        //    "X   X",
        //    "XXXX ",
        //    "X   X",
        //    "X   X",
        //    "X   X",
        //};

        //private string[] _S =
        //{
        //    " XXXX",
        //    "X    ",
        //    "X    ",
        //    " XXX ",
        //    "    X",
        //    "    X",
        //    "XXXX ",
        //};

        //private string[] _T =
        //{
        //    "XXXXX",
        //    "  X  ",
        //    "  X  ",
        //    "  X  ",
        //    "  X  ",
        //    "  X  ",
        //    "  X  ",
        //};

        //private string[] _U =
        //{
        //    "X   X",
        //    "X   X",
        //    "X   X",
        //    "X   X",
        //    "X   X",
        //    "X   X",
        //    " XXX ",
        //};

        //private string[] _V =
        //{
        //    "X   X",
        //    "X   X",
        //    "X   X",
        //    " X X ",
        //    " X X ",
        //    "  X  ",
        //    "  X  ",
        //};

        //private string[] _W =
        //{
        //    "X   X",
        //    "X   X",
        //    "X   X",
        //    "X X X",
        //    "X X X",
        //    "XX XX",
        //    "X   X",
        //};

        //private string[] _X =
        //{
        //    "X   X",
        //    "X   X",
        //    " X X ",
        //    "  X  ",
        //    " X X ",
        //    "X   X",
        //    "X   X",
        //};

        //private string[] _Y =
        //{
        //    "X   X",
        //    "X   X",
        //    "X   X",
        //    " X X ",
        //    "  X  ",
        //    "  X  ",
        //    "  X  ",
        //};


        //private string[] _Z =
        //{
        //    "XXXXX",
        //    "    X",
        //    "   X ",
        //    "  X  ",
        //    " X   ",
        //    "X    ",
        //    "XXXXX",
        //};
        #endregion Letters

        public Dictionary<string, string[]> LetterMap = new();

        public Letters()
        {
            #region Upper Case
            LetterMap.Add("A", new[]
            {
                " XXX ",
                "X   X",
                "X   X",
                "XXXXX",
                "X   X",
                "X   X",
                "X   X",
            });

            LetterMap.Add("B", new[]
            {
                "XXXX ",
                "X   X",
                "X   X",
                "XXXX ",
                "X   X",
                "X   X",
                "XXXX ",
            });

            LetterMap.Add("C", new[]
            {
                " XXX ",
                "X   X",
                "X    ",
                "X    ",
                "X    ",
                "X   X",
                " XXX ",
            });

            LetterMap.Add("D", new[]
            {
                "XXXX ",
                "X   X",
                "X   X",
                "X   X",
                "X   X",
                "X   X",
                "XXXX ",
            });

            LetterMap.Add("E", new[]
            {
                "XXXXX",
                "X    ",
                "X    ",
                "XXXX ",
                "X    ",
                "X    ",
                "XXXXX",
            });

            LetterMap.Add("F", new[]
            {
                "XXXXX",
                "X    ",
                "X    ",
                "XXXX ",
                "X    ",
                "X    ",
                "X    ",
            });

            LetterMap.Add("G", new[]
            {
                " XXX ",
                "X   X",
                "X    ",
                "X    ",
                "X XXX",
                "X   X",
                " XXX ",
            });

            LetterMap.Add("H", new[]
            {
                "X   X",
                "X   X",
                "X   X",
                "XXXXX",
                "X   X",
                "X   X",
                "X   X",
            });

            LetterMap.Add("I", new[]
            {
                " XXX ",
                "  X  ",
                "  X  ",
                "  X  ",
                "  X  ",
                "  X  ",
                " XXX ",
            });

            LetterMap.Add("J", new[]
            {
                "    X",
                "    X",
                "    X",
                "    X",
                "    X",
                "X   X",
                " XXX ",
            });

            LetterMap.Add("K", new[]
            {
                "X   X",
                "X  X ",
                "X X  ",
                "XX   ",
                "X X  ",
                "X  X ",
                "X   X",
            });

            LetterMap.Add("L", new[]
            {
                "X    ",
                "X    ",
                "X    ",
                "X    ",
                "X    ",
                "X    ",
                "XXXXX",
            });

            LetterMap.Add("M", new[]
            {
                "X   X",
                "XX XX",
                "X X X",
                "X   X",
                "X   X",
                "X   X",
                "X   X",
            });

            LetterMap.Add("N", new[]
            {
                "X   X",
                "X   X",
                "XX  X",
                "X X X",
                "X  XX",
                "X   X",
                "X   X",
            });

            LetterMap.Add("O", new[]
            {
                " XXX ",
                "X   X",
                "X   X",
                "X   X",
                "X   X",
                "X   X",
                " XXX ",
            });

            LetterMap.Add("P", new[]
            {
                "XXXX ",
                "X   X",
                "X   X",
                "XXXX ",
                "X    ",
                "X    ",
                "X    ",
            });

            LetterMap.Add("Q", new[]
            {
                " XXX ",
                "X   X",
                "X   X",
                "X   X",
                "X   X",
                "X  X ",
                " XX X",
            });

            LetterMap.Add("R", new[]
            {
                "XXXX ",
                "X   X",
                "X   X",
                "XXXX ",
                "X   X",
                "X   X",
                "X   X",
            });

            LetterMap.Add("S", new[]
            {
                " XXX ",
                "X   X",
                "X    ",
                " XXX ",
                "    X",
                "X   X",
                " XXX ",
            });

            LetterMap.Add("T", new[]
            {
                "XXXXX",
                "  X  ",
                "  X  ",
                "  X  ",
                "  X  ",
                "  X  ",
                "  X  ",
            });

            LetterMap.Add("U", new[]
            {
                "X   X",
                "X   X",
                "X   X",
                "X   X",
                "X   X",
                "X   X",
                " XXX ",
            });

            LetterMap.Add("V", new[]
            {
                "X   X",
                "X   X",
                "X   X",
                " X X ",
                " X X ",
                "  X  ",
                "  X  ",
            });

            LetterMap.Add("W", new[]
            {
                "X   X",
                "X   X",
                "X   X",
                "X   X",
                "X X X",
                "XX XX",
                "X   X",
            });

            LetterMap.Add("X", new[]
            {
                "X   X",
                "X   X",
                " X X ",
                "  X  ",
                " X X ",
                "X   X",
                "X   X",
            });

            LetterMap.Add("Y", new[]
            {
                "X   X",
                "X   X",
                "X   X",
                " X X ",
                "  X  ",
                "  X  ",
                "  X  ",
            });

            LetterMap.Add("Z", new[]
            {
                "XXXXX",
                "    X",
                "   X ",
                "  X  ",
                " X   ",
                "X    ",
                "XXXXX",
            });
            #endregion Upper Case

            #region Symbols
            LetterMap.Add("?", new[]
            {
                " XXX ",
                "X   X",
                "    X",
                "   X ",
                "  X  ",
                "     ",
                "  X  ",
            });

            LetterMap.Add("'", new[]
            {
                "  X  ",
                "  X  ",
                " X   ",
                "     ",
                "     ",
                "     ",
                "     ",
            });


            #endregion Symbols
        }
    }
}
