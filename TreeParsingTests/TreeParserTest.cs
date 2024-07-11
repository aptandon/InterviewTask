using TreeParsing.Model;
using TreeParsing.Traverser;
using TreeParsing.Validator;

namespace TreeParsingTests
{
    public class TreeParserTest
    {
        [Fact]
        public void TestTreeConstruction()
        {
            var tree = new Tree();
            tree.Add(15);
            tree.Add(10);
            tree.Add(22);
            tree.Add(4);
            tree.Add(12);
            tree.Add(18);
            tree.Add(24);

            Assert.NotNull(tree.Root);
            Assert.Equal(15, tree.Root.Value);
            Assert.Equal(10, tree.Root.Left.Value);
            Assert.Equal(22, tree.Root.Right.Value);
            Assert.Equal(4, tree.Root.Left.Left.Value);
            Assert.Equal(12, tree.Root.Left.Right.Value);
            Assert.Equal(18, tree.Root.Right.Left.Value);
            Assert.Equal(24, tree.Root.Right.Right.Value);
        }

        [Fact]
        public void TestPostOrderTraversal()
        {
            var tree = new Tree();
            tree.Add(15);
            tree.Add(10);
            tree.Add(22);
            tree.Add(4);
            tree.Add(12);
            tree.Add(18);
            tree.Add(24);

            var expectedOrder = new List<int> { 4, 12, 10, 18, 24, 22, 15 };
            var traversalResult = TreeTraverser.TraversePostOrder(tree.Root);

            Assert.Equal(expectedOrder, traversalResult);
        }

        [Theory]
        [InlineData("15,10,22,4,12,18,24", new[] { 15, 10, 22, 4, 12, 18, 24 })]
        [InlineData("1,2,3,4,5", new[] { 1, 2, 3, 4, 5 })]
        [InlineData("5,4,3,2,1", new[] { 5, 4, 3, 2, 1 })]
        public void TestParseInput_ValidInput(string input, int[] expected)
        {
            var result = InputValidator.ValidateInput(input);
            Assert.NotNull(result);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("15,-10,22", null)]
        [InlineData("abc,def", null)]
        [InlineData("15,10.5,22", null)]
        [InlineData("15,10,", null)]
        public void TestParseInput_InvalidInput(string input, int[] expected)
        {
            var result = InputValidator.ValidateInput(input);
            Assert.Equal(expected, result);
        }
    }
}