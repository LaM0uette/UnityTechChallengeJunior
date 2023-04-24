using Data;

namespace Builders
{
    public class FurnitureBuilder : IFurnitureBuilder
    {
        private Furniture _furniture;

        public FurnitureBuilder()
        {
            Reset();
        }

        public void Reset()
        {
            _furniture = new Furniture();
        }

        public void SetWidth(float width)
        {
            _furniture.width = width;
        }

        public void SetHeight(float height)
        {
            _furniture.height = height;
        }

        public void SetDepth(float depth)
        {
            _furniture.depth = depth;
        }

        public void SetBackPanel(BackPanel backPanel)
        {
            _furniture.backPanel = backPanel;
        }

        public void SetHeader(Header header)
        {
            _furniture.header = header;
        }

        public void SetFooter(Footer footer)
        {
            _furniture.footer = footer;
        }

        public void SetLeftSide(LeftSide leftSide)
        {
            _furniture.leftSide = leftSide;
        }

        public void SetRightSide(RightSide rightSide)
        {
            _furniture.rightSide = rightSide;
        }

        public void AddShelf(Shelf shelf)
        {
            _furniture.shelves.Add(shelf);
        }

        public Furniture Build()
        {
            var builtFurniture = _furniture;
            Reset();
            return builtFurniture;
        }
    }
}
