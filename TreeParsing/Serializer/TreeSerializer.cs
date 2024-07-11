using TreeParsing.Model;

namespace TreeParsing.Serializer
{
    public static class TreeSerializer
    {
        /// <summary>
        /// Serialise to the file
        /// </summary>
        /// <param name="tree"></param>
        /// <param name="filePath"></param>
        public static void SerializeToDisk(Tree tree, string filePath)
        {
            var queue = new Queue<TreeNode>();
            if (tree.Root != null)
            {
                queue.Enqueue(tree.Root);
            }

            var lines = new List<string>();

            while (queue.Count > 0)
            {
                var currentNode = queue.Dequeue();

                string leftValue = currentNode.Left != null ? currentNode.Left.Value.ToString() : "null";
                string rightValue = currentNode.Right != null ? currentNode.Right.Value.ToString() : "null";
                lines.Add($"Root->{currentNode.Value},Left->{leftValue},Right->{rightValue}");
                if (currentNode.Left != null)
                {
                    queue.Enqueue(currentNode.Left);
                }
                if (currentNode.Right != null)
                {
                    queue.Enqueue(currentNode.Right);
                }
            }
            File.WriteAllLines(filePath, lines);
        }
    }
}
