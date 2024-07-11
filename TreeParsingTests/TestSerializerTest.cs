using TreeParsing.Model;
using TreeParsing.Serializer;

namespace TreeParsingTests
{
    public class TestSerializerTest
    {
        [Fact]
        public void TestSerializeToDisk_SingleNode()
        {
            // Arrange
            var tree = new Tree();
            tree.Add(15);
            string filePath = "single_node_tree.txt";

            // Act
            TreeSerializer.SerializeToDisk(tree, filePath);

            // Assert
            Assert.True(File.Exists(filePath));
            string[] lines = File.ReadAllLines(filePath);
            string[] expectedLines = { "Root->15,Left->null,Right->null" };
            Assert.Equal(expectedLines, lines);

            // Clean up
            File.Delete(filePath);
        }

        [Fact]
        public void TestSerializeToDisk_ComplexTree()
        {
            // Arrange
            var tree = new Tree();
            tree.Add(15);
            tree.Add(10);
            tree.Add(22);
            tree.Add(4);
            tree.Add(12);
            tree.Add(18);
            tree.Add(24);
            string filePath = "complex_tree.txt";

            // Act
            TreeSerializer.SerializeToDisk(tree, filePath);

            // Assert
            Assert.True(File.Exists(filePath));
            string[] lines = File.ReadAllLines(filePath);
            string[] expectedLines = {
                "Root->15,Left->10,Right->22",
                "Root->10,Left->4,Right->12",
                "Root->22,Left->18,Right->24",
                "Root->4,Left->null,Right->null",
                "Root->12,Left->null,Right->null",
                "Root->18,Left->null,Right->null",
                "Root->24,Left->null,Right->null"
            };
            Assert.Equal(expectedLines, lines);

            // Clean up
            File.Delete(filePath);
        }

        [Fact]
        public void TestSerializeToDisk_EmptyTree()
        {
            // Arrange
            var tree = new Tree();
            string filePath = "empty_tree.txt";

            // Act
            TreeSerializer.SerializeToDisk(tree, filePath);

            // Assert
            Assert.True(File.Exists(filePath));
            string[] lines = File.ReadAllLines(filePath);
            Assert.Empty(lines);

            // Clean up
            File.Delete(filePath);
        }

        [Fact]
        public void TestSerializeToDisk_LeftSkewedTree()
        {
            // Arrange
            var tree = new Tree();
            tree.Add(15);
            tree.Add(10);
            tree.Add(5);
            string filePath = "left_skewed_tree.txt";

            // Act
            TreeSerializer.SerializeToDisk(tree, filePath);

            // Assert
            Assert.True(File.Exists(filePath));
            string[] lines = File.ReadAllLines(filePath);
            string[] expectedLines = {
                "Root->15,Left->10,Right->5",
                "Root->10,Left->null,Right->null",
                "Root->5,Left->null,Right->null"
            };
            Assert.Equal(expectedLines, lines);

            // Clean up
            File.Delete(filePath);
        }

        [Fact]
        public void TestSerializeToDisk_RightSkewedTree()
        {
            // Arrange
            var tree = new Tree();
            tree.Add(15);
            tree.Add(20);
            tree.Add(25);
            string filePath = "right_skewed_tree.txt";

            // Act
            TreeSerializer.SerializeToDisk(tree, filePath);

            // Assert
            Assert.True(File.Exists(filePath));
            string[] lines = File.ReadAllLines(filePath);
            string[] expectedLines = {
                "Root->15,Left->20,Right->25",
                "Root->20,Left->null,Right->null",
                "Root->25,Left->null,Right->null"
            };
            Assert.Equal(expectedLines, lines);

            // Clean up
            File.Delete(filePath);
        }
    }
}
