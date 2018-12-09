using Common;

namespace CivSim
{
    class TileInfo
    {
        public enum TerrainType { Land, Sea }

        public int X { get; private set; }
        public int Y { get; private set; }
        public VisibleCell VisibleCell { get; private set; }
        private IVisibleCellManager _visibleCellManager;
        public float TerrainHeight { get; private set; }

        public TerrainType Terrain { get; private set; }

        public TileInfo(int x, int y, IVisibleCellManager visibleCellManager)
        {
            X = x;
            Y = y;
            _visibleCellManager = visibleCellManager;
            VisibleCell = _visibleCellManager.getNewCell(new Character(SpecialCharacter.Tilde), X, Y, RLNET.RLColor.Blue);
        }

        public void setTerrain(TerrainType terrainType)
        {
            Terrain = terrainType;
            switch (Terrain)
            {
                case TerrainType.Land:
                    VisibleCell.SetCharacter(SpecialCharacter.LandSparse);
                    VisibleCell.Color = RLNET.RLColor.Green;
                    break;
                case TerrainType.Sea:
                    VisibleCell.SetCharacter(SpecialCharacter.Tilde);
                    VisibleCell.Color = RLNET.RLColor.Blue;
                    break;
                default:
                    throw new System.ArgumentException(terrainType.ToString());
            }
        }

        public void setTerrainHeight(float height)
        {
            TerrainHeight = height;
            float shade = height + 0.2f;
            VisibleCell.Color = new RLNET.RLColor(shade, shade, shade);
            VisibleCell.BackColor = new RLNET.RLColor(0.1f, 0.1f, 0.1f);
            if(TerrainHeight > 0.4f)
            {
                VisibleCell.Character = new Character(94);
                VisibleCell.Color = RLNET.RLColor.White;
            } else if (TerrainHeight > 0.2f)
            {
                VisibleCell.BackColor = new RLNET.RLColor(shade - 0.25f, shade - 0.25f, shade - 0.25f);
                VisibleCell.Color = RLNET.RLColor.Black;
                VisibleCell.Character = new Character(126);
            }
        }
    }
}