using System.Collections.Generic;
using Constants;
using Data;
using UnityEngine;

namespace Builders
{
    public class FurnitureBuilder : MonoBehaviour, IFurnitureBuilder
    {
        #region Statements

        private Furniture _furniture;

        #endregion

        #region Builder
        
        public IFurnitureBuilder SetData(Furniture furniture)
        {
            _furniture = furniture;
            return this;
        }

        private GameObject CreateBackPanel(BackPanel backPanelData)
        {
            var backPanel = FurnitureFunctions.CreateCube();
            var position = new Vector3(0, _furniture.height / 2, 0);
            var scale = new Vector3(_furniture.width, _furniture.height, backPanelData.depth);
            
            backPanel.name = "BackPanel";
            backPanel.SetTansform(position, scale);
            backPanel.AddMeshCollider();

            return backPanel;
        }

        private GameObject CreateHeader(Header headerData)
        {
            var header = FurnitureFunctions.CreateCube();
            var position = new Vector3(0, _furniture.height - headerData.height / 2, -_furniture.depth / 2);
            var scale = new Vector3(_furniture.width, headerData.height, _furniture.depth);
            
            header.name = "Header";
            header.SetTansform(position, scale);
            header.AddMeshCollider();
            
            return header;
        }

        private GameObject CreateFooter(Footer footerData)
        {
            var footer = FurnitureFunctions.CreateCube();
            var position = new Vector3(0, footerData.height / 2, -_furniture.depth / 2);
            var scale = new Vector3(_furniture.width, footerData.height, _furniture.depth);
            
            footer.name = "Footer";
            footer.SetTansform(position, scale);
            footer.AddMeshCollider();
            
            return footer;
        }

        private GameObject CreateLeftSide(LeftSide leftSideData)
        {
            var leftSide = FurnitureFunctions.CreateCube();
            var position = new Vector3(-_furniture.width / 2 + leftSideData.width / 2, _furniture.height / 2, -_furniture.depth / 2);
            var scale = new Vector3(leftSideData.width, _furniture.height, _furniture.depth);
            
            leftSide.name = "LeftSide";
            leftSide.SetTansform(position, scale);
            leftSide.AddMeshCollider();
            
            return leftSide;
        }

        private GameObject CreateRightSide(RightSide rightSideData)
        {
            var rightSide = FurnitureFunctions.CreateCube();
            var position = new Vector3(_furniture.width / 2 - rightSideData.width / 2, _furniture.height / 2, -_furniture.depth / 2);
            var scale = new Vector3(rightSideData.width, _furniture.height, _furniture.depth);
            
            rightSide.name = "RightSide";
            rightSide.SetTansform(position, scale);
            rightSide.AddMeshCollider();
            
            return rightSide;
        }

        private List<GameObject> CreateShelves(IEnumerable<Shelf> shelvesData)
        {
            var shelves = new List<GameObject>();

            foreach (var shelfData in shelvesData)
            {
                var shelf = FurnitureFunctions.CreateCube();
                var position = new Vector3(0, shelfData.y, -_furniture.depth / 2);
                var scale = new Vector3(_furniture.width, shelfData.height, _furniture.depth);
                
                shelf.name = "Shelf";
                shelf.SetTansform(position, scale);
                shelf.AddMeshCollider();
                
                shelves.Add(shelf);
            }
            return shelves;
        }

        public GameObject Build()
        {
            var backPanel = CreateBackPanel(_furniture.backPanel);
            var header = CreateHeader(_furniture.header);
            var footer = CreateFooter(_furniture.footer);
            var leftSide = CreateLeftSide(_furniture.leftSide);
            var rightSide = CreateRightSide(_furniture.rightSide);
            var shelves = CreateShelves(_furniture.shelves);

            var furniture = new GameObject(Tags.Furniture);
            furniture.AddChild(backPanel);
            furniture.AddChild(header);
            furniture.AddChild(footer);
            furniture.AddChild(leftSide);
            furniture.AddChild(rightSide);

            foreach (var shelf in shelves)
                furniture.AddChild(shelf);

            furniture.tag = Tags.Furniture;
            furniture.SetTagForChildren(Tags.Fixture);
            
            return furniture;
        }

        #endregion
    }
}