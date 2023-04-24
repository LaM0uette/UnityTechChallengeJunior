using System.Collections.Generic;

namespace Data
{
    [System.Serializable]
    public class Furniture
    {
        public float width;
        public float height;
        public float depth;
        public BackPanel backPanel;
        public Header header;
        public Footer footer;
        public LeftSide leftSide;
        public RightSide rightSide;
        public List<Shelf> shelves;
    }
}
