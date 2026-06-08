using System;
using System.Collections.Generic;

namespace TS_DS_03
{
    internal class Program
    {
        public static void BrowserHistoryTracker()
        {
            Stack<string> browserHistory = new Stack<string>();

            browserHistory.Push("google.com");
            browserHistory.Push("youtube.com");
            browserHistory.Push("github.com");
            browserHistory.Push("linkesin.com");
            browserHistory.Push("UTAS.com");

            Console.WriteLine("browser history");

            foreach (string page in browserHistory)
            {
                Console.WriteLine(page);
            }

            Console.WriteLine("Current page is: " + browserHistory.Peek());

            string removedPage = browserHistory.Pop();
            Console.WriteLine("Removed page is: " + removedPage);

            removedPage = browserHistory.Pop();
            Console.WriteLine("Removed second page: " + removedPage);

            Console.WriteLine("Remaining History");

            foreach (string page in browserHistory)
            {
                Console.WriteLine(page);
            }

            string targetUrl = "google.com";

            Console.WriteLine("Checking URL");

            if (browserHistory.Contains(targetUrl))
            {
                Console.WriteLine(targetUrl + " is still in the history");
            }
            else
            {
                Console.WriteLine(targetUrl + " is not in the history");
            }

            Console.WriteLine("total pages remaining: " + (browserHistory.Count+1));
        }

        public static void HotelCheckInQueue()
        {
            Queue<string> checkInQueue = new Queue<string>();

            checkInQueue.Enqueue("Hoor");
            checkInQueue.Enqueue("Fatma");
            checkInQueue.Enqueue("Bayan");
            checkInQueue.Enqueue("Khalifa");
            checkInQueue.Enqueue("Salim");

            Console.WriteLine("Waiting Guests");

            foreach (string guest in checkInQueue)
            {
                Console.WriteLine(guest);
            }

            Console.WriteLine("Next guest is: " + checkInQueue.Peek());

            Console.WriteLine("done with 2 Guests");

            string servedGuest = checkInQueue.Dequeue();
            Console.WriteLine("Served guest: " + servedGuest);

            servedGuest = checkInQueue.Dequeue();
            Console.WriteLine("Served guest: " + servedGuest);

            Console.WriteLine("remaining Queue");

            foreach (string guest in checkInQueue)
            {
                Console.WriteLine(guest);
            }

            string targetGuest = "Hoor";

            Console.WriteLine("Checking Guest");

            if (checkInQueue.Contains(targetGuest))
            {
                Console.WriteLine(targetGuest + " is still waiting");
            }
            else
            {
                Console.WriteLine(targetGuest + " is not waiting");
            }

            Console.WriteLine("Total guests remaining: " + (checkInQueue.Count+1));
        }

        public static void TextEditorUndoSystem()
        {
            Stack<string> undoStack = new Stack<string>();
            Stack<string> tempStack = new Stack<string>();

            undoStack.Push("typed");
            undoStack.Push("deleted text");
            undoStack.Push("deleted");
            undoStack.Push("changed font");
            undoStack.Push("added image");
            undoStack.Push("changed color");
            undoStack.Push("saved file");

            Console.WriteLine("Undo History");

            foreach (string action in undoStack)
            {
                Console.WriteLine(action);
            }

            Console.WriteLine("Next action to undo: " + undoStack.Peek());

            Console.WriteLine("Undo Last 2 Actions");

            string removedAction = undoStack.Pop();
            Console.WriteLine("Removed first action: " + removedAction);

            removedAction = undoStack.Pop();
            Console.WriteLine("Removed second action: " + removedAction);

            Console.WriteLine("Remaining Undo History");

            foreach (string action in undoStack)
            {
                Console.WriteLine(action);
            }

            Console.WriteLine("Before Selective Undo");

            foreach (string action in undoStack)
            {
                Console.WriteLine(action);
            }
            string targetAction = "Changed font";
            bool removed = false;

            while (undoStack.Count > 0)
            {
                string action = undoStack.Pop();

                if (action == targetAction && removed == false)
                {
                    removed = true;
                }
                else
                {
                    tempStack.Push(action);
                }
            }

            while (tempStack.Count > 0)
            {
                undoStack.Push(tempStack.Pop());
            }

            Console.WriteLine("Stack After Selective Undo");

            foreach (string action in undoStack)
            {
                Console.WriteLine(action);
            }

            Console.WriteLine("total remaining actions: " + (undoStack.Count + 1));
        }

        public static void HospitalEmergencyRoomTriage()
        {
            Queue<string> triageQueue = new Queue<string>();
            Queue<string> tempQueue = new Queue<string>();

            triageQueue.Enqueue("Hoor");
            triageQueue.Enqueue("Bayan");
            triageQueue.Enqueue("Khalifa");
            triageQueue.Enqueue("Salim");
            triageQueue.Enqueue("Abdullah");
            triageQueue.Enqueue("Ahmed");
            triageQueue.Enqueue("Jokha");
            triageQueue.Enqueue("Taif");

            Console.WriteLine("Triage Queue");

            int position = 1;

            foreach (string patient in triageQueue)
            {
                Console.WriteLine("Position " + position + ": " + patient);
                position++;
            }

            Console.WriteLine("next patient will seen: " + triageQueue.Peek());

            Console.WriteLine("processing first 3 patients");

            string seenPatient = triageQueue.Dequeue();
            Console.WriteLine("patient seen: " + seenPatient);

            seenPatient = triageQueue.Dequeue();
            Console.WriteLine("patient seen: " + seenPatient);

            seenPatient = triageQueue.Dequeue();
            Console.WriteLine("patient seen: " + seenPatient);

            Console.WriteLine("Remaining Queue");

            int position1 = 1;

            foreach (string patient in triageQueue)
            {
                Console.WriteLine("Position " + position1 + ": " + patient);
                position1++;
            }

            string targetPatient = "Salim";
            bool removed = false;

            while (triageQueue.Count > 0)
            {
                string patient = triageQueue.Dequeue();

                if (patient == targetPatient && removed == false)
                {
                    removed = true;
                }
                else
                {
                    tempQueue.Enqueue(patient);
                }
            }

            while (tempQueue.Count > 0)
            {
                triageQueue.Enqueue(tempQueue.Dequeue());
            }

            Console.WriteLine("Final Queue After Removing Patient");

            int postion2 = 1;

            foreach (string patient in triageQueue)
            {
                Console.WriteLine("Position " + postion2 + ": " + patient);
                postion2++;
            }

            Console.WriteLine("total patients remaining: " + triageQueue.Count);
        }
       
        public static void ParenthesisValidator(string testString)
        {
            Stack<char> bracketStack = new Stack<char>();
            bool valid = true;

            for (int i = 0; i < testString.Length; i++)
            {
                char ch = testString[i];

                if (ch == '(' || ch == '[' || ch == '{')
                {
                    bracketStack.Push(ch);
                }
                else if (ch == ')')
                {
                    if (bracketStack.Count == 0)
                    {
                        valid = false;
                        break;
                    }
                    else if (bracketStack.Peek() != '(')
                    {
                        valid = false;
                        break;
                    }
                    else
                    {
                        bracketStack.Pop();
                    }
                }
                else if (ch == ']')
                {
                    if (bracketStack.Count == 0)
                    {
                        valid = false;
                        break;
                    }
                    else if (bracketStack.Peek() != '[')
                    {
                        valid = false;
                        break;
                    }
                    else
                    {
                        bracketStack.Pop();
                    }
                }
                else if (ch == '}')
                {
                    if (bracketStack.Count == 0)
                    {
                        valid = false;
                        break;
                    }
                    else if (bracketStack.Peek() != '{')
                    {
                        valid = false;
                        break;
                    }
                    else
                    {
                        bracketStack.Pop();
                    }
                }
            }

            if (bracketStack.Count != 0)
            {
                valid = false;
            }

            Console.WriteLine("Test string: " + testString);

            if (valid == true)
            {
                Console.WriteLine("Valid");
            }
            else
            {
                Console.WriteLine("Invalid");
            }

            while (bracketStack.Count > 0)
            {
                bracketStack.Pop();
            }
        }
        public static void PrintSpoolerWithPriorityReInsertion()
        {
            Queue<string> spooler = new Queue<string>();
            Queue<string> tempQueue = new Queue<string>();

            spooler.Enqueue("Report:45");
            spooler.Enqueue("Booklet:80");
            spooler.Enqueue("Invoice:10");
            spooler.Enqueue("Poster:70");
            spooler.Enqueue("Notes:20");
            spooler.Enqueue("Manual:120");
            spooler.Enqueue("Receipt:200");
            spooler.Enqueue("Assignment:30");

            Console.WriteLine("print queue");

            int position = 1;

            foreach (string job in spooler)
            {
                Console.WriteLine("Position " + position + ": " + job);
                position++;
            }

            int processCount = spooler.Count;

            for (int i = 0; i < processCount; i++)
            {
                string job = spooler.Dequeue();
                string[] parts = job.Split(':');
                int pages = int.Parse(parts[1]);

                if (pages > 50)
                {
                    spooler.Enqueue(job);
                }
                else
                {
                    tempQueue.Enqueue(job);
                }
            }

            while (spooler.Count > 0)
            {
                tempQueue.Enqueue(spooler.Dequeue());
            }

            while (tempQueue.Count > 0)
            {
                spooler.Enqueue(tempQueue.Dequeue());
            }

            Console.WriteLine("Reordered Print Queue");

            position = 1;

            foreach (string job in spooler)
            {
                Console.WriteLine("Position " + position + ": " + job);
                position++;
            }

            Console.WriteLine("Processing Print Jobs");

            int totalPages = 0;
            int largeJobs = 0;
            int standardJobs = 0;

            while (spooler.Count > 0)
            {
                string job = spooler.Dequeue();
                string[] parts = job.Split(':');

                string jobName = parts[0];
                int pages = int.Parse(parts[1]);

                Console.WriteLine("Printing job: " + jobName + " with " + pages + " pages");

                totalPages = totalPages + pages;

                if (pages > 50)
                {
                    largeJobs++;
                }
                else
                {
                    standardJobs++;
                }
            }

            Console.WriteLine("Total pages printed: " + totalPages);
            Console.WriteLine("Large-format jobs: " + largeJobs);
            Console.WriteLine("Standard jobs: " + standardJobs);
        }
        static void Main(string[] args)
        {
            bool exit = false;

            while (exit == false)
            {
                Console.WriteLine();
                Console.WriteLine("Main menu:");
                Console.WriteLine("1. Browser History Tracker");
                Console.WriteLine("2. Hotel Check-In Queue");
                Console.WriteLine("3. Text Editor Undo System");
                Console.WriteLine("4. Hospital Emergency Room Triage");
                Console.WriteLine("5. Parenthesis Validator");
                Console.WriteLine("6. Print Spooler With Priority Re-Insertion");
                Console.WriteLine("7. Reverse Sentence Word By Word");
                Console.WriteLine("8. Multi-Level Undo With Redo");
                Console.WriteLine("9. Ticket Counter Simulation");
                Console.WriteLine("10. Order Processing Pipeline With Statistics");

                Console.WriteLine("Please select an option from the menu:");
                int option = int.Parse(Console.ReadLine());

                switch (option)
                {
                    case 1:
                        BrowserHistoryTracker();
                        break;

                    case 2:
                        HotelCheckInQueue();
                        break;

                    case 3:
                        TextEditorUndoSystem();
                        break;

                    case 4:
                        HospitalEmergencyRoomTriage();
                        break;

                    case 5:
                        Console.WriteLine("test 1");
                        ParenthesisValidator("(5*10)+{8>6}[]");
                        Console.WriteLine("test 2");
                        ParenthesisValidator("(a + b]");
                        Console.WriteLine("test 3");
                        ParenthesisValidator("{a + [b * c]");
                        break;
                    case 6:
                        PrintSpoolerWithPriorityReInsertion();
                        break;
                }
            }
        }
    }
}