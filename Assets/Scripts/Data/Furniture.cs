using System.Collections.Generic;

namespace Data
{
    [System.Serializable]
    public class Furniture
    {
        public float Width;
        public float Height;
        public float Depth;
        public BackPanel BackPanel;
        public Header Header;
        public Footer Footer;
        public LeftSide LeftSide;
        public RightSide RightSide;
        public List<Shelf> Shelves;
    }
}
