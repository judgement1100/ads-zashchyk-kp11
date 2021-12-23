using System;
using static System.Console;

namespace Laba_asd_4
{
    partial class Program
    {
        static void Main(string[] args)
        {
            LinkedList<int> linkedList = new LinkedList<int>();
            string command = "";
            bool isRunning = true;
            while (isRunning)
            {
                string str = "";
                Console.WriteLine("Enter '1' to Add First elem\n" +
                                  "Enter '2' to Add Last elem\n" +
                                  "Enter '3' to Add At Position elem\n" +
                                  "Enter '4' to Delete First elem\n" +
                                  "Enter '5' to Delete Last elem\n" +
                                  "Enter '6' to Delete At Position elem\n" +
                                  "Enter '7' to Add new elem before max number (main task)\n" +
                                  "Enter any symbol to Just print");
                                   
                str = ReadLine();
                if (str == "1")
                {
                    Console.WriteLine("Enter number");
                    int data = Convert.ToInt32(ReadLine());
                    linkedList.AddFirst(data);
                }
                if (str == "2")
                {
                    Console.WriteLine("Enter number");
                    int data = Convert.ToInt32(ReadLine());
                    linkedList.AddLast(data);
                }
                if (str == "3")
                {
                    Console.WriteLine("Enter number");
                    int data = Convert.ToInt32(ReadLine());
                    Console.WriteLine("Enter position");
                    int pos = Convert.ToInt32(ReadLine());
                    linkedList.AddAtPosition(data, pos);
                }
                if (str == "4")
                {
                    linkedList.DeleteFirst();
                }
                if (str == "5")
                {
                    linkedList.DeleteLast();
                }
                if (str == "6")
                {
                    Console.WriteLine("Enter position to delete");
                    int pos = Convert.ToInt32(ReadLine());
                    linkedList.DeleteAtPosition(pos);
                }
                if (str == "7")
                {
                    Console.WriteLine("Enter number");
                    int data = Convert.ToInt32(ReadLine());
                    linkedList.LabaEx(data);
                }
                Console.WriteLine("Your list:");
                linkedList.Print();
                Console.WriteLine("If you want to stop running enter 'stop', else enter any other symbol");
                command = ReadLine();
                if (command == "stop")
                    isRunning = false;
            }
        }
        class LinkedList<T>
        {
            Node head;
            private int counter = 0;
            public void AddFirst(int a)
            {
                if (head == null)
                {
                    head = new Node(a);
                    counter++;
                }
                else
                {
                    head.previous = new Node(head.previous, a, head);
                    head = head.previous;
                    head.previous.next = head;
                    counter++;
                }
            }
            public void LabaEx(int a)
            {
                Node node = head;
                int max = int.MinValue;
                int posCounter = 1;
                for (int i = 1; i <= counter; i++)
                {
                    if (node.data > max)
                    {
                        max = node.data;
                        posCounter++;
                    }
                    node = node.next;
                }
                AddAtPosition(a, posCounter - 1);
            }
            public void AddLast(int a)
            {
                if (head == null)
                {
                    head = new Node(a);
                    counter++;
                }
                else
                {
                    head.previous = new Node(head.previous, a, head);
                    head.previous.previous.next = head.previous;
                    counter++;
                }
            }
            public void AddAtPosition(int a, int pos)
            {
                if (head == null)
                {
                    head = new Node(a);
                    counter++;
                }
                else if (pos <= counter + 1)
                {
                    if (pos == 1)
                    {
                        AddFirst(a);
                    }
                    else
                    {
                        Node node = head;
                        for (int i = 1; i < pos - 1; i++)
                            node = node.next;
                        Node newNode = new Node(node, a, node.next);
                        node.next = newNode;
                        newNode.next.previous = newNode;
                        counter++;
                    }
                }
                else
                {
                    AddFirst(a);
                }
            }
            public void DeleteFirst()
            {
                if (counter == 1)
                {
                    head = null;
                    counter--;
                    return;
                }
                if (counter > 1)
                {
                    head = head.next;
                    head.previous.previous.next = head;
                    head.previous = head.previous.previous;
                    counter--;
                }
                else if (counter < 1)
                    Console.WriteLine("Cannot delete. ");
            }
            public void DeleteLast()
            {
                if (counter == 1)
                {
                    head = null;
                    counter--;
                }
                if (counter > 1)
                {
                    head.previous.previous.next = head;
                    head.previous = head.previous.previous;
                    counter--;
                }
                else if (counter < 1)
                    Console.WriteLine("Cannot delete");
            }
            public void DeleteAtPosition(int pos)
            {
                if (pos == 1)
                {
                    DeleteFirst();
                }
                else if (pos == counter)
                {
                    DeleteLast();
                }
                else if (pos < counter && pos > 1)
                {
                    Node currNode = head;
                    for (int i = 1; i < pos - 1; i++)
                    {
                        currNode = currNode.next;
                    }
                    currNode.next = currNode.next.next;
                    currNode.next.previous = currNode;
                    counter--;
                }
                else
                {
                    Console.WriteLine("Cannot delete");
                }
            }
            public void Print()
            {
                Node node = head;
                for (int i = 1; i <= counter; i++)
                {
                    if (counter > 0)
                    {
                        node.PrintNode();
                        node = node.next;
                    }
                    else
                    {
                        Console.WriteLine("Error. Cannot delete element");
                    }
                }
                Console.WriteLine();
            }
            class Node
            {
                public Node next, previous;
                public int data;
                public Node(Node previous, int data, Node next)
                {
                    this.next = next;
                    this.previous = previous;
                    this.data = data;
                }
                public Node(int data)
                {
                    next = this;
                    previous = this;
                    this.data = data;
                }
                public void PrintNode()
                {
                   Console.Write($"{data} ");
                }
            }
        }
    }
}
