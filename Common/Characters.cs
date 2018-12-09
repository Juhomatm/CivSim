using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public enum SpecialCharacter
    {
        Dude = 1,
        DudeOpaque = 2,
        Diamond = 4,
        Tilde = 126,
        LandSparse = 176,
        LandNormal = 177,
        LandThick = 178,
    }

    public class Character
    {
        public int Code { get; private set; }

        public bool IsSpecialCharacter { get; private set; }
        public bool IsCode { get; private set; }

        public Character(int code)
        {
            IsCode = true;
            Code = code;
        }

        public Character(SpecialCharacter character)
        {
            IsCode = true;
            Code = (int)character;
        }
    }
}
