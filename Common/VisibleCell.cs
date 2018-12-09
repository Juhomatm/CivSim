using RLNET;

namespace Common
{
    public class VisibleCell
    {
        public Character Character { get; set; }
        public RLColor Color { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public RLColor? BackColor { get; set; }
        public int Layer { get; set; }

        public VisibleCell(int x, int y, Character character, RLColor color, int layer)
        {
            Character = character;
            Color = color;
            X = x;
            Y = y;
            Layer = layer;
        }

        public void SetCharacter(SpecialCharacter specialCharacter)
        {
            Character = new Character(specialCharacter);
        }
    }
}
