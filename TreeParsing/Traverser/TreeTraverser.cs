using TreeParsing.Model;

namespace TreeParsing.Traverser
{
    public static class TreeTraverser
    {
        public static List<int> TraversePostOrder(TreeNode node)
        {
            var result = new List<int>();
            TraversePostOrder(node, result);
            return result;
        }

        private static void TraversePostOrder(TreeNode node, List<int> result)
        {
            if (node == null) return;

            TraversePostOrder(node.Left, result);
            TraversePostOrder(node.Right, result);
            result.Add(node.Value);
        }
    }
}
