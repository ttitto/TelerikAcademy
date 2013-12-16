using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BinarySearchTreeTest
{
    partial struct BinarySearchTree<T> where T : IComparable<T>
    {
        internal class TreeNode<T> : IComparable<TreeNode<T>> where T : IComparable<T>
        {
            /// <summary>
            /// Constructs a BinaryTreeNode
            /// </summary>
            /// <param name="value"></param>
            public TreeNode(T value)
            {
                this.value = value;
                this.leftChild = null;
                this.rightChild = null;
                this.parent = null;
            }

            internal T value;
            internal TreeNode<T> leftChild;
            internal TreeNode<T> rightChild;
            internal TreeNode<T> parent;

            /// <summary>
            /// Compares two BinaryTreeNodes if they are equal
            /// </summary>
            /// <param name="obj"></param>
            /// <returns>Returns true if their values are equal, otherwise returns false</returns>
            public override bool Equals(object obj)
            {
                TreeNode<T> other = obj as TreeNode<T>;
                if (other == null) throw new ArgumentNullException("Can not compare a null BinaryTreeNode!");
                else if (this.CompareTo(other) == 0) return true;
                else return false;
            }
            /// <summary>
            /// Converts the value of the BinaryTreeNode to string
            /// </summary>
            /// <returns></returns>
            public override string ToString()
            {
                return this.value.ToString();
            }
            /// <summary>
            /// Assigns the HashCode of the BinaryTreeNode value to the BinaryTreeNode itself
            /// </summary>
            /// <returns> the hashcode as int</returns>
            public override int GetHashCode()
            {
                return this.value.GetHashCode();
            }

            /// <summary>
            /// Compares two BinaryTreeNodes by their values
            /// </summary>
            /// <param name="other"></param>
            /// <returns>-1 if the first node's value is bigger than the other's;
            /// returns 0 if both values are equal:
            /// returns 1 if the first node's value is smaller than the other's</returns>
            public int CompareTo(TreeNode<T> other)
            {
                if (this.value.CompareTo(other.value) < 0) return -1;
                else if (this.value.CompareTo(other.value) > 0) return 1;
                else return 0;
            }
        }
    }
}
