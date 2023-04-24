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
            Assert.AreEqual(3000, furniture.Width);
            Assert.AreEqual(400, furniture.Height);
            Assert.AreEqual(600, furniture.Depth);
            Assert.AreEqual(5, furniture.BackPanel.depth);
            Assert.AreEqual(50, furniture.Header.height);
            Assert.AreEqual(100, furniture.Footer.height);
            Assert.AreEqual(80, furniture.LeftSide.width);
            Assert.AreEqual(80, furniture.RightSide.width);
        }

        [Test]
        public void ReadAndParse_furniture1_True()
        {
            var testFilePath = Application.dataPath + "/FixturesJson/furniture1.json";
            var furniture = JsonParser.ReadAndParse<Furniture>(testFilePath);

            Assert.IsNotNull(furniture);
            Assert.AreEqual(3000, furniture.Width);
            Assert.AreEqual(400, furniture.Height);
            Assert.AreEqual(600, furniture.Depth);
            Assert.AreEqual(5, furniture.BackPanel.depth);
            Assert.AreEqual(50, furniture.Header.height);
            Assert.AreEqual(100, furniture.Footer.height);
            Assert.AreEqual(80, furniture.LeftSide.width);
            Assert.AreEqual(80, furniture.RightSide.width);
        }
        
        [Test]
        public void ReadAndParse_furniture2_True()
        {
            var testFilePath = Application.dataPath + "/FixturesJson/furniture2.json";
            var furniture = JsonParser.ReadAndParse<Furniture>(testFilePath);

            Assert.IsNotNull(furniture);
            Assert.AreEqual(800, furniture.Width);
            Assert.AreEqual(2000, furniture.Height);
            Assert.AreEqual(200, furniture.Depth);
            Assert.AreEqual(5, furniture.BackPanel.depth);
            Assert.AreEqual(100, furniture.Header.height);
            Assert.AreEqual(400, furniture.Footer.height);
            Assert.AreEqual(50, furniture.LeftSide.width);
            Assert.AreEqual(50, furniture.RightSide.width);
            Assert.AreEqual(3, furniture.Shelves.Length);
        }
    }
}
