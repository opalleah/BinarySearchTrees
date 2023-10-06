namespace Binary_Search_Trees
{
    internal class Program
    {
        // Create an instance of BSTree
        private static BSTree myTree = new BSTree();

        static void Main(string[] args)
        {

            LessonNotesOrder();
        }

        private static void LessonNotesOrder()
        {
            Console.WriteLine("*** Displaying Traversal Orders ***");


            // Call the Add method on the instance
            myTree.Add(8);
            myTree.Add(3);
            myTree.Add(10);
            myTree.Add(1);
            myTree.Add(6);
            myTree.Add(14);
            myTree.Add(4);
            myTree.Add(7);
            myTree.Add(13);

            Console.WriteLine("*** Pre Order ***");
            Console.WriteLine(myTree.PreOrder());
            Console.WriteLine("*** In Order ***");
            Console.WriteLine(myTree.InOrder());
            Console.WriteLine("*** Post Order ***");
            Console.WriteLine(myTree.PostOrder());

            Console.WriteLine("*** Insert Data ***");
            myTree.Add(100);
            myTree.Add(50);
            myTree.Add(20);
            myTree.Add(30);
            myTree.Add(150);
            myTree.Add(125);
            myTree.Add(175);

            Console.WriteLine("*** Testing Find ***");
            Console.WriteLine(myTree.Find(50));
            Console.WriteLine(myTree.Find(100));
            Console.WriteLine(myTree.Find(175));
            Console.WriteLine(myTree.Find(200));

            Console.WriteLine("*** Tree Depth ***");
            //Console.WriteLine(myTree.TreeDepth());

            Console.WriteLine("Press any key to exit...");

            // Wait for a key press
            Console.ReadKey();
        }
    }
}