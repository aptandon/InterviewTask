namespace TreeParsing.Model
{
    public class TreeNode
    {
        public int Value { get; }
        public TreeNode Left { get; private set; }
        public TreeNode Right { get; private set; }

        public TreeNode(int value)
        {
            Value = value;
        }

        /// <summary>
        /// Adding the values in the tree
        /// </summary>
        /// <param name="value"></param>
        public void Add(int value)
        {
            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(this);

            while (queue.Count > 0)
            {
                TreeNode current = queue.Dequeue();

                if (current.Left == null)
                {
                    current.Left = new TreeNode(value);
                    break;
                }
                else
                {
                    queue.Enqueue(current.Left);
                }

                if (current.Right == null)
                {
                    current.Right = new TreeNode(value);
                    break;
                }
                else
                {
                    queue.Enqueue(current.Right);
                }
            }
        }
    }
}
