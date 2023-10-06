using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Binary_Search_Trees
{
    internal class BSTree
    {
        public Node Root { get; set; }

        public BSTree()
        {
            Root = null;
        }

        public void Add(int data)
        {
            //UI call
            Node node = new Node(data);

            if (Root == null)
            {
                Root = node;
            }
            else
            {
                {
                    InsertNode(Root, node);
                }
            }
        }

        private void InsertNode(Node tree, Node node)
        {
            //this is a recursice method used to traverse the tree

            //1. compare node for less than node in tree
            if (node.Data < tree.Data)
            {
                if (tree.Left == null)
                {
                    //2. is empty, insert node
                    tree.Left = node;
                }
                else
                {
                    //3. left not empty traverse the tree using recurvive call
                    InsertNode(tree.Left, node);
                }
            }
            //4. compare node for greater than node in tree
            if (node.Data > tree.Data)
            {
                if (tree.Right == null)
                {
                    //5. right is empty, insert node
                    tree.Right = node;
                }
                else
                {
                    //6. right not epty traverse the tree using recursive call
                    InsertNode(tree.Right, node);
                }
            }
        }

        private string TraversePreOrder(Node node)
        {
            StringBuilder sb = new StringBuilder();

            if (node != null)
            {
                sb.Append(node.ToString() + " ");
                sb.Append(TraversePreOrder(node.Left));
                sb.Append(TraversePreOrder(node.Right));
            }
            return sb.ToString();
        }

        public string PreOrder()
        {
            StringBuilder sb = new StringBuilder();
            if (Root == null)
            {
                sb.Append("Tree is EMPTY");
            }
            else
            {
                sb.Append(TraversePreOrder(Root));
            }
            return sb.ToString();
        }

        private string TraverseInOrder(Node node)
        {
            StringBuilder sb = new StringBuilder();

            if (node != null)
            {
                sb.Append(TraverseInOrder(node.Left));
                sb.Append(node.ToString() + " ");
                sb.Append(TraverseInOrder(node.Right));
            }
            return sb.ToString();
        }

        public string InOrder()
        {
            StringBuilder sb = new StringBuilder();
            if (Root == null)
            {
                sb.Append("Tree is EMPTY");
            }
            else
            {
                sb.Append(TraverseInOrder(Root));
            }
            return sb.ToString();
        }

        private string TraversePostOrder(Node node)
        {
            StringBuilder sb = new StringBuilder();

            if (node != null)
            {
                sb.Append(TraversePostOrder(node.Left));
                sb.Append(TraversePostOrder(node.Right));
                sb.Append(node.ToString() + " ");
            }
            return sb.ToString();
        }

        public string PostOrder()
        {
            StringBuilder sb = new StringBuilder();
            if (Root == null)
            {
                sb.Append("Tree is EMPTY");
            }
            else
            {
                sb.Append(TraversePostOrder(Root));
            }
            return sb.ToString();
        }

        private Node Delete(Node tree, Node node)
        {
            if (tree == null)
            {
                //1, reached nnull side of the tree, return to unload stack
                return tree;
            }
            if (node.Data < tree.Data)
            {
                //2, traverse left side to find node
                tree.Left = Delete(tree.Left, node);
            }
            else if(node.Data > tree.Data)
            {
               //3. traverse right side to find node
               tree.Right = Delete(tree.Right, node);    
            }
            else
            {
                //4. found node to delete
                //check if node has only one child or no child
                if (tree.Left == null)
                {
                    //5. pull left side of tree up
                    return tree.Right;
                }
                else if (tree.Right == null)
                {
                        //6. pull left side of tree up
                        return tree.Left;
                }
                else
                {
                    //7. node has two leaf nodes, get the InOrder successor node (smallest)
                    //therefore traverse right side and replace the node found with the current node
                    tree.Data = MinValue(tree.Right);

                    //8. traverse the right side of the tree to delete the inOrder succesor
                    tree.Right = Delete(tree.Right, tree);
                }
            }
            return tree;
        }

        private int MinValue(Node node)
        {
            //finds the min node in the rightside of the tree
            int minval = node.Data;
            while (node.Left != null)
            {
                //traverse the tree replacing the minval with the node on the left side of the tree
                minval = node.Left.Data;
                node = node.Left;
            }
            return minval;
        }

        public string Remove(int data)
        {
            Node node = new Node(data);
            node = Search(Root, node);
            if (node != null)
            {
                Root = Delete(Root, node);
                return "Target: " + data.ToString() + ", NODE removed";
            }
            else
            {
                return "Target: " + data.ToString() + ", NODE not found";
            }
        }

        private Node Search(Node tree, Node node)
        {
            if (tree != null)
            {
                //1. have not reached the end of a branch
                if (node.Data == tree.Data)
                {
                    //2. found node
                    return tree;
                }
                if (node.Data < tree.Data)
                {
                    //3. traverse left side
                    return Search(tree.Left, node);
                }
                else
                {
                    //4. traverse right side
                    return Search(tree.Right, node);
                }
            }
            //5. not found
            return null;
        }

        public string Find(int data)
        {
            Node node = new Node(data);
            node = Search(Root, node);
            if (node != null)
            {
                return "Target: " + data.ToString() + ", NODE found: " + node.ToString();
            }
            else
            {
                return "Target: " + data.ToString() + ", NODE not found or tree empty " ;
            }
        }
    }
}
