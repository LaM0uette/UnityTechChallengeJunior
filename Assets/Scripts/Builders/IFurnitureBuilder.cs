using Data;

namespace Builders
{
    public interface IFurnitureBuilder
    {
        public void SetWidth(float width);
        public void SetHeight(float height);
        public void SetDepth(float depth);
        public void SetBackPanel(BackPanel backPanel);
        public void SetHeader(Header header);
        public void SetFooter(Footer footer);
        public void SetLeftSide(LeftSide leftSide);
        public void SetRightSide(RightSide rightSide);
        public void AddShelf(Shelf shelf);
        public Furniture Build();
    }
}
