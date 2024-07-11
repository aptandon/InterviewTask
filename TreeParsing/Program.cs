using System.Diagnostics.CodeAnalysis;
using TreeParsing.Model;
using TreeParsing.Serializer;
using TreeParsing.Traverser;
using TreeParsing.Validator;

namespace TreeParsing
{
    [ExcludeFromCodeCoverage]
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Please enter a comma-separated list of positive numbers:");
            string input = Console.ReadLine();
            var numbers = InputValidator.ValidateInput(input);

            if (numbers == null)
            {
                Console.WriteLine("Invalid input. Only positive numbers are allowed.");
                Console.ReadLine();
                return;
            }

            var tree = new Tree();
            foreach (var number in numbers)
            {
                tree.Add(number);
            }

            string filePath = "tree_structure.txt";
            TreeSerializer.SerializeToDisk(tree, filePath);

            Console.WriteLine("Tree structure saved to " + filePath);

            var traversalResult = TreeTraverser.TraversePostOrder(tree.Root);
            Console.WriteLine("Post-order Traversal: " + string.Join(',', traversalResult));
            Console.ReadLine();
        }
    }
}