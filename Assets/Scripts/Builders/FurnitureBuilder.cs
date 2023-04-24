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
            _furniture.Width = width;
        }

        public void SetHeight(float height)
        {
            _furniture.Height = height;
        }

        public void SetDepth(float depth)
        {
            _furniture.Depth = depth;
        }

        public void SetBackPanel(BackPanel backPanel)
        {
            _furniture.BackPanel = backPanel;
        }

        public void SetHeader(Header header)
        {
            _furniture.Header = header;
        }

        public void SetFooter(Footer footer)
        {
            _furniture.Footer = footer;
        }

        public void SetLeftSide(LeftSide leftSide)
        {
            _furniture.LeftSide = leftSide;
        }

        public void SetRightSide(RightSide rightSide)
        {
            _furniture.RightSide = rightSide;
        }

        public void AddShelf(Shelf shelf)
        {
            _furniture.Shelves.Add(shelf);
        }

        public Furniture Build()
        {
            var builtFurniture = _furniture;
            Reset();
            return builtFurniture;
        }
    }
}
