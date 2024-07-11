namespace TreeParsing.Model
{
    public class Tree
    {
        public TreeNode Root { get; private set; }

        /// <summary>
        /// Adding the values in the tree
        /// </summary>
        /// <param name="value"></param>
        public void Add(int value)
        {
            if (Root == null)
            {
                Root = new TreeNode(value);
            }
            else
            {
                Root.Add(value);
            }
        }
    }
}
