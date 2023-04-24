using Data;
using NUnit.Framework;
using UnityEngine;
using Utils;

namespace Tests.Editor
{
    public class JsonParserTests
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
        public void Parse_furniture1_True()
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
        public void ReadAndParse_furniture1_True()
        {
            var testFilePath = Application.dataPath + "/FixturesJson/furniture1.json";
            var furniture = JsonParser.ReadAndParse<Furniture>(testFilePath);

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
        public void ReadAndParse_furniture2_True()
        {
            var testFilePath = Application.dataPath + "/FixturesJson/furniture2.json";
            var furniture = JsonParser.ReadAndParse<Furniture>(testFilePath);

            Assert.IsNotNull(furniture);
            Assert.AreEqual(800, furniture.width);
            Assert.AreEqual(2000, furniture.height);
            Assert.AreEqual(200, furniture.depth);
            Assert.AreEqual(5, furniture.backPanel.depth);
            Assert.AreEqual(100, furniture.header.height);
            Assert.AreEqual(400, furniture.footer.height);
            Assert.AreEqual(50, furniture.leftSide.width);
            Assert.AreEqual(50, furniture.rightSide.width);
            Assert.AreEqual(3, furniture.shelves.Length);
        }
    }
}
