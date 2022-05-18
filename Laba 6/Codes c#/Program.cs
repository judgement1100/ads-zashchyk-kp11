using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace ASD_Lab5
{
    class Program
    {
        static void Main(string[] args)
        {
            bool isRunning = true;
            while (isRunning)
            {
                Console.WriteLine("If you want to see na example enter <1>, else you should enter <2>");
                string command = Console.ReadLine();
                if (command == "1")
                {
                    string htmlCode = "<html>" +
                                    "<head>" +
                                        "<title> Hello </title>" +
                                    "</head>" +
                                    "<body>" +
                                        "<p> This appears in the <i> browser </i>. </p>" +
                                    "</body>" +
                                  "</html>";
                    Console.WriteLine("Html code example is:\n" + htmlCode);

                    if (HtmlCodeIsCorrect(htmlCode))
                    {
                        Console.WriteLine("Succeeded!");
                    }
                    else
                    {
                        Console.WriteLine("Incorrect html code!");
                    }
                }
                else if (command == "2")
                {
                    Console.WriteLine("Waiting for input html code");
                    string htmlCode = Console.ReadLine();

                    if (HtmlCodeIsCorrect(htmlCode))
                    {
                        Console.WriteLine("Succeeded!");
                    }
                    else
                    {
                        Console.WriteLine("Incorrect html code!");
                    }
                }
                Console.WriteLine("\nEnter <exit> to exit or enter sth else to go on");
                if (Console.ReadLine() == "exit")
                {
                    isRunning = false;
                }
            }
        }

        static bool HtmlCodeIsCorrect(string htmlCode)
        {
            MyStack<string> stack1 = MyStack<string>.InitStack();
            bool isOpened = false;
            string tag = "";

            for (int i = 0; i < htmlCode.Length; i++)
            {
                if (htmlCode[i] == '<')
                {
                    isOpened = true;
                }
                else if (htmlCode[i] == '>')
                {
                    tag += htmlCode[i];
                    if (tag.Contains('/'))
                    {
                        string item1 = stack1.Peek();
                        string item2 = tag.Replace("/", "");
                        if (item1 == item2)
                        {
                            stack1.Pop();
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                        stack1.Push(tag);
                    tag = "";
                    isOpened = false;
                }
                if (isOpened)
                {
                    tag += htmlCode[i];
                }
            }
            if (stack1.IsEmpty())
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public class Node<T>
        {
            public T Value;
            public Node<T> NextNode;
            public Node(T value)
            {
                Value = value;
            }
        }

        public class MyStack<T>
        {
            public Node<T> Top = null;
            public int Size = 0;

            private MyStack()
            {
            }
            public static MyStack<T> InitStack()
            {
                MyStack<T> myStack = new MyStack<T>();
                return myStack;
            }

            public void PrintStackContent()
            {
                if (Size > 0)
                {
                    Console.WriteLine("Current stack content:");
                    Node<T> curNode = Top;
                    while (!(curNode is null))
                    {
                        Console.WriteLine(curNode.Value);
                        curNode = curNode.NextNode;
                    }
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine("Current stack is empty!");
                }
            }

            public static void DestroyStack(ref MyStack<T> stack)
            {
                while (stack.Top.NextNode != null)
                {
                    stack.Top = stack.Top.NextNode;
                }
                if (!(stack.Top is null))
                {
                    stack.Top = null;
                }
                stack.Size = 0;
                stack = null;
            }

            public void Push(T elem)
            {
                Node<T> newNode = new Node<T>(elem);
                if (Top == null)
                {
                    Top = newNode;
                    Top.NextNode = null;
                }
                else
                {
                    newNode.NextNode = Top;
                    Top = newNode;
                    PrintStackContent();
                }
                Size++;
            }

            public T Pop()
            {
                if (!IsEmpty())
                {
                    T valueToShow = Top.Value;
                    Top = Top.NextNode;
                    Size--;
                    PrintStackContent();
                    return valueToShow;
                }
                else
                {
                    return default(T);
                }
            }

            public T PopHidden()
            {
                if (!IsEmpty())
                {
                    T valueToShow = Top.Value;
                    Top = Top.NextNode;
                    Size--;
                    return valueToShow;
                }
                else
                {
                    PrintStackContent();
                    return default(T);
                }
            }

            public T Peek()
            {
                if (!IsEmpty())
                {
                    return Top.Value;
                }
                else
                {
                    return default(T);
                }
            }

            public bool IsEmpty()
            {
                if (Size != 0 )
                {
                    return false;
                }
                else
                {
                    return  true;
                }
            }
        }
    }
}
