using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuzzleOne
{
    class Program
    {
        static void Main(string[] args)
        {
            Node LinkedList =  new Node();
            Node FifthElement = new Node();

            LinkedList = CreateLinkedList();
            FifthElement = Return5thElement(LinkedList);
            Console.WriteLine(FifthElement.DataElement.ToString());
            Console.Read();
        }
      public static Node Return5thElement(Node HeadPtr)
        {
            Node Ptr2 = HeadPtr;
            for (int i = 1; i < 5; i++)
                Ptr2 = Ptr2.Next;

            while (Ptr2.Next != null)
            {
                Ptr2 = Ptr2.Next;
                HeadPtr = HeadPtr.Next;
            }
            return HeadPtr;
        }
       public static Node CreateLinkedList()
        {
            Node LinkedList = new Node();
            LinkedList.DataElement = 1;
            LinkedList.Next = new Node();
            Node NextNode = LinkedList.Next;
            for (int i = 2; i < 11; i++)
            {
                NextNode.DataElement = i;
                if(i!=10)
                { 
                NextNode.Next = new Node();
                NextNode = NextNode.Next;
                   }

            }
            return LinkedList;
        }
    }
    class Node
    {
        public int DataElement;
        public Node Next;
    }
}
