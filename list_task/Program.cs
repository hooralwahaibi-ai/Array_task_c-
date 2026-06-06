using System;
using System.Collections.Generic;

namespace TS_DS_02
{
    internal class Program
    {
        public static void RoomServiceMenu()
        {
            List<string> menuItems = new List<string>();

            menuItems.Add("burger");
            menuItems.Add("pizza");
            menuItems.Add("pasta");
            menuItems.Add("nodiles");

            for (int i = 0; i < menuItems.Count; i++)
            {
                Console.WriteLine((i + 1) + ": " + menuItems[i]);
            }

            menuItems.Add("salad");
            menuItems.Add("fish");

            Console.WriteLine("updated menu");

            for (int i = 0; i < menuItems.Count; i++)
            {
                Console.WriteLine((i + 1) + ": " + menuItems[i]);
            }

            menuItems.Remove("pizza");

            Console.WriteLine("menu updated after removing ");

            for (int i = 0; i < menuItems.Count; i++)
            {
                Console.WriteLine((i + 1) + ": " + menuItems[i]);
            }

            string targetDish = "pasta";


            if (menuItems.Contains(targetDish))
            {
                Console.WriteLine(targetDish + " is available in the menu");
            }
            else
            {
                Console.WriteLine(targetDish + " is not available in the menu");
            }

            Console.WriteLine("total number of items on the menu: " + menuItems.Count);
        }

        public static void GuestCheckInQueue()
        {
            List<string> checkInQueue = new List<string>();

            checkInQueue.Add("Hoor");
            checkInQueue.Add("Fatma");
            checkInQueue.Add("Bayan");
            checkInQueue.Add("Khalifa");
            checkInQueue.Add("Salim");

            Console.WriteLine("original list");

            for (int i = 0; i < checkInQueue.Count; i++)
            {
                Console.WriteLine((i + 1) + ": " + checkInQueue[i]);
            }

            checkInQueue.RemoveAt(0);

            Console.WriteLine("first remove after Check-In");

            for (int i = 0; i < checkInQueue.Count; i++)
            {
                Console.WriteLine((i + 1) + ": " + checkInQueue[i]);
            }

            checkInQueue.RemoveAt(0);

            Console.WriteLine("second remove after Check-In");

            for (int i = 0; i < checkInQueue.Count; i++)
            {
                Console.WriteLine((i + 1) + ": " + checkInQueue[i]);
            }

            checkInQueue.Add("Ahmed");
            checkInQueue.Add("Mohammed");
            checkInQueue.Add("Khalid");

            Console.WriteLine("after adding 3");

            for (int i = 0; i < checkInQueue.Count; i++)
            {
                Console.WriteLine((i + 1) + ": " + checkInQueue[i]);
            }

            string targetGuest = "Hoor";

            Console.WriteLine("Checking");

            if (checkInQueue.Contains(targetGuest))
            {
                Console.WriteLine(targetGuest + " is still waiting");
            }
            else
            {
                Console.WriteLine(targetGuest + " is not waiting");
            }

            Console.WriteLine("total number of guests currently in the queue: " + checkInQueue.Count);
        }

        public static void HousekeepingFloorAssignment()
        {
            List<int> assignedRooms = new List<int>();

            assignedRooms.Add(305);
            assignedRooms.Add(102);
            assignedRooms.Add(210);
            assignedRooms.Add(412);
            assignedRooms.Add(101);
            assignedRooms.Add(220);

            Console.WriteLine("original list");

            for (int i = 0; i < assignedRooms.Count; i++)
            {
                Console.WriteLine((i + 1) + ": room number: " + assignedRooms[i]);
            }

            assignedRooms.Add(108);
            assignedRooms.Add(315);

            Console.WriteLine("after adding 2 rooms");

            for (int i = 0; i < assignedRooms.Count; i++)
            {
                Console.WriteLine((i + 1) + ": room number: " + assignedRooms[i]);
            }

            assignedRooms.Remove(210);

            Console.WriteLine("after removing one room ");

            for (int i = 0; i < assignedRooms.Count; i++)
            {
                Console.WriteLine((i + 1) + ": room number: " + assignedRooms[i]);
            }

            assignedRooms.Sort();

            Console.WriteLine("sorted list");

            for (int i = 0; i < assignedRooms.Count; i++)
            {
                Console.WriteLine((i + 1) + ": room number: " + assignedRooms[i]);
            }

            int targetRoom = 315;
            int index = assignedRooms.IndexOf(targetRoom);

            Console.WriteLine("is room 315 avalibal?");

            if (index == -1)
            {
                Console.WriteLine("Room " + targetRoom + " was not found");
            }
            else
            {
                Console.WriteLine("Room " + targetRoom + " was found at index: " + index);
            }

            assignedRooms.Insert(2, 205);

            Console.WriteLine("list after insert");

            for (int i = 0; i < assignedRooms.Count; i++)
            {
                Console.WriteLine((i + 1) + ": room number:  "+ assignedRooms[i]);
            }

            Console.WriteLine("total number of assigned rooms: " + assignedRooms.Count);
        }

        public static void HotelBookingConflictResolver()
        {
            List<int> standardBookings = new List<int>();
            List<int> suiteBookings = new List<int>();
            List<int> masterBookings = new List<int>();

            standardBookings.Add(1001);
            standardBookings.Add(1002);
            standardBookings.Add(1003);
            standardBookings.Add(1004);
            standardBookings.Add(1005);
            standardBookings.Add(1006);

            suiteBookings.Add(1003);
            suiteBookings.Add(1005);
            suiteBookings.Add(1006);
            suiteBookings.Add(2001);
            suiteBookings.Add(2002);

            Console.WriteLine("Original standard booking");

            for (int i = 0; i < standardBookings.Count; i++)
            {
                Console.WriteLine((i + 1) + ":" + standardBookings[i]);
            }

            Console.WriteLine("Original Suite Bookings");

            for (int i = 0; i < suiteBookings.Count; i++)
            {
                Console.WriteLine((i + 1) + ": " + suiteBookings[i]);
            }

            masterBookings.AddRange(standardBookings);
            masterBookings.AddRange(suiteBookings);

            Console.WriteLine("after merging");

            for (int i = 0; i < masterBookings.Count; i++)
            {
                Console.WriteLine((i + 1) + ": " + masterBookings[i]);
            }

            for (int i = 0; i < masterBookings.Count; i++)
            {
                for (int j = i + 1; j < masterBookings.Count; j++)
                {
                    if (masterBookings[i] == masterBookings[j])
                    {
                        masterBookings.RemoveAt(j);
                        j--;
                    }
                }
            }

            masterBookings.Sort();

            Console.WriteLine("sorted master bookings");

            for (int i = 0; i < masterBookings.Count; i++)
            {
                Console.WriteLine((i + 1) + ": " + masterBookings[i]);
            }

            int booking1 = 1003;
            int booking2 = 3000;

            Console.WriteLine("Check Booking ID");

            if (masterBookings.Contains(booking1))
            {
                Console.WriteLine(booking1 + " exists in the master list");
            }
            else
            {
                Console.WriteLine(booking1 + " does not exist in the master list");
            }

            if (masterBookings.Contains(booking2))
            {
                Console.WriteLine(booking2 + " exists in the master list");
            }
            else
            {
                Console.WriteLine(booking2 + " does not exist in the master list");
            }

            int targetBooking = 2001;
            int index = masterBookings.IndexOf(targetBooking);

            Console.WriteLine("find Booking Index");

            if (index == -1)
            {
                Console.WriteLine(targetBooking +" was not found");
            }
            else
            {
                Console.WriteLine(targetBooking + " was found at index: " + index);
            }

            masterBookings.RemoveRange(1, 3);

            Console.WriteLine("final Master List");

            for (int i = 0; i < masterBookings.Count; i++)
            {
                Console.WriteLine((i + 1) + ": " + masterBookings[i]);
            }

            Console.WriteLine("total number of bookings: " + masterBookings.Count);
        }

        static void Main(string[] args)
        {
            bool exit = false;

            while (exit == false)
            {
                Console.WriteLine();
                Console.WriteLine("Main menu:");
                Console.WriteLine("0. Room Service Menu");
                Console.WriteLine("1. Guest Check-In Queue");
                Console.WriteLine("2. Housekeeping Floor Assignment");
                Console.WriteLine("3. Hotel Booking Conflict Resolver");

                Console.WriteLine("Please select an option from the menu:");
                int option = int.Parse(Console.ReadLine());

                switch (option)
                {
                    case 0:
                        RoomServiceMenu();
                        break;

                    case 1:
                        GuestCheckInQueue();
                        break;

                    case 2:
                        HousekeepingFloorAssignment();
                        break;

                    case 3:
                        HotelBookingConflictResolver();
                        break;
                }
            }
        }
    }
}