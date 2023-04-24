using System.IO;
using Data;
using NUnit.Framework;
using UnityEngine;
using Utils;

namespace Tests.Editor
{
    public class JsonParserTests : MonoBehaviour
    {
        private const string TestJson = @"
{
    ""width"": 3000,
    ""height"": 400,
    ""depth"": 600,
    ""backPanel"": { ""depth"": 5 },
    ""header"": { ""height"": 50 },
    ""footer"": { ""height"": 100 },
    ""leftSide"": { ""width"": 80 },
    ""rightSide"": { ""width"": 80 }
}";

        [Test]
        public void ParseFurnitureFromJsonString()
        {
            var furniture = JsonParser.Parse<Furniture>(TestJson);

            Assert.IsNotNull(furniture);
            Assert.AreEqual(3000, furniture.width);
            Assert.AreEqual(400, furniture.height);
            Assert.AreEqual(600, furniture.depth);
            Assert.AreEqual(5, furniture.backPanel.depth);
            Assert.AreEqual(50, furniture.header.height);
            Assert.AreEqual(100, furniture.footer.height);
            Assert.AreEqual(80, furniture.leftSide.width);
            Assert.AreEqual(80, furniture.rightSide.width);
        }

        [Test]
        public void LoadAndParseFurnitureFromJsonFile()
        {
            var testFilePath = Application.dataPath + "/FixturesJson/furniture1.json";
            File.WriteAllText(testFilePath, TestJson);

            var furniture = JsonParser.LoadAndParse<Furniture>(testFilePath);

            Assert.IsNotNull(furniture);
            Assert.AreEqual(3000, furniture.width);
            Assert.AreEqual(400, furniture.height);
            Assert.AreEqual(600, furniture.depth);
            Assert.AreEqual(5, furniture.backPanel.depth);
            Assert.AreEqual(50, furniture.header.height);
            Assert.AreEqual(100, furniture.footer.height);
            Assert.AreEqual(80, furniture.leftSide.width);
            Assert.AreEqual(80, furniture.rightSide.width);

            File.Delete(testFilePath);
        }
    }
}
