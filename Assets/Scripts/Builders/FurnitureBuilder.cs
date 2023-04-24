using System.Collections.Generic;
using Data;
using UnityEngine;

namespace Builders
{
    public class FurnitureBuilder : MonoBehaviour, IFurnitureBuilder
    {
        private Furniture _furniture;

        public IFurnitureBuilder SetData(Furniture furnitureData)
        {
            _furniture = furnitureData;
            return this;
        }

        private GameObject CreateBackPanel(BackPanel backPanelData)
        {
            var backPanel = GameObject.CreatePrimitive(PrimitiveType.Cube);
            backPanel.name = "BackPanel";
            backPanel.transform.localScale = new Vector3(_furniture.width, _furniture.height, backPanelData.depth);
            return backPanel;
        }

        private GameObject CreateHeader(Header headerData)
        {
            var header = GameObject.CreatePrimitive(PrimitiveType.Cube);
            header.name = "Header";
            header.transform.localScale = new Vector3(_furniture.width, headerData.height, _furniture.depth);
            return header;
        }

        private GameObject CreateFooter(Footer footerData)
        {
            var footer = GameObject.CreatePrimitive(PrimitiveType.Cube);
            footer.name = "Footer";
            footer.transform.localScale = new Vector3(_furniture.width, footerData.height, _furniture.depth);
            return footer;
        }

        private GameObject CreateLeftSide(LeftSide leftSideData)
        {
            var leftSide = GameObject.CreatePrimitive(PrimitiveType.Cube);
            leftSide.name = "LeftSide";
            leftSide.transform.localScale = new Vector3(leftSideData.width, _furniture.height, _furniture.depth);
            return leftSide;
        }

        private GameObject CreateRightSide(RightSide rightSideData)
        {
            var rightSide = GameObject.CreatePrimitive(PrimitiveType.Cube);
            rightSide.name = "RightSide";
            rightSide.transform.localScale = new Vector3(rightSideData.width, _furniture.height, _furniture.depth);
            return rightSide;
        }

        private List<GameObject> CreateShelves(IEnumerable<Shelf> shelvesData)
        {
            var shelves = new List<GameObject>();

            foreach (var shelfData in shelvesData)
            {
                var shelf = GameObject.CreatePrimitive(PrimitiveType.Cube);
                shelf.name = "Shelf";
                shelf.transform.localScale = new Vector3(_furniture.width, shelfData.height, _furniture.depth);
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

            var furniture = new GameObject("Furniture");
            backPanel.transform.SetParent(furniture.transform);
            header.transform.SetParent(furniture.transform);
            footer.transform.SetParent(furniture.transform);
            leftSide.transform.SetParent(furniture.transform);
            rightSide.transform.SetParent(furniture.transform);
            foreach (var shelf in shelves)
                shelf.transform.SetParent(furniture.transform);

            return furniture;
        }
    }
}