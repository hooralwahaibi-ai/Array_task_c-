using System;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace FlightManagementSystem
{
    internal class Program
    {
        static List<string> passengerNames = new List<string>()
        {"Hoor Khalifa","Bayan Khalifa","Fatma Yousif" };

        static List<string> ticketNumbers = new List<string>()
        {"TKT-001","TKT-002","TKT-003","TKT-004" };

        static string[] flightNumbers = new string[6]
        {"OA101","OA102","OA103","OA104","OA105","OA106" };

        static List<string> availableDates = new List<string>()
        { "12-Jan-2026","13-Jun-2026","14-Jun-2026","15-Jun-2026","16-Jun-2026" };

        static Dictionary<string, string> bookingRecord = new Dictionary<string, string>();

        static Queue<string> checkedInQueue = new Queue<string>();

        static Stack<string> boardingStack = new Stack<string>();

        static List<string> cancelledTickets = new List<string>();

        static Dictionary<string, string> passengerSeatMap = new Dictionary<string, string>();

        static Queue<string> waitlistQueue = new Queue<string>();

        static int seatRow = 10;
        static char seatLetter = 'A';

        public static void RegisterNewPassenger()
        {
            Console.WriteLine("Enter passenger full name:");
            string name = Console.ReadLine();

            if (name == "")
            {
                Console.WriteLine("Error: passenger name cannot be empty");
                return;
            }

            for (int i = 0; i < passengerNames.Count; i++)
            {
                if (passengerNames[i] == name)
                {
                    Console.WriteLine("Error: passenger already exists");
                    return;
                }
            }

            string ticketId = "TKT-" + (passengerNames.Count + 1).ToString("D3");

            passengerNames.Add(name);
            ticketNumbers.Add(ticketId);

            Console.WriteLine("Passenger registered successfully.");
            Console.WriteLine("Passenger Name: " + name);
            Console.WriteLine("Ticket ID: " + ticketId);
        }
        public static void ViewAllPassengers()
        {
            Console.WriteLine("View All Passengers");

            if (passengerNames.Count == 0)
            {
                Console.WriteLine("No passengers registered yet");
                return;
            }


            for (int i = 0; i < passengerNames.Count; i++)
            {
                string status = "Active";

                if (cancelledTickets.Contains(ticketNumbers[i]))
                {
                    status = "CANCELLED";
                }

                Console.WriteLine((i + 1) + ". " + passengerNames[i] + " | " + ticketNumbers[i] + " | " + status);
            }

            Console.WriteLine("total passengers: " + passengerNames.Count);
        }
        public static void BookFlightTicket()
        {
            Console.WriteLine("Book a Flight Ticket");

            Console.WriteLine("Enter ticket ID:");
            string ticketId = Console.ReadLine();

            int passengerIndex = -1;

            for (int i = 0; i < ticketNumbers.Count; i++)
            {
                if (ticketNumbers[i].ToLower() == ticketId.ToLower())
                {
                    passengerIndex = i;
                    ticketId = ticketNumbers[i];
                }
            }

            if (passengerIndex == -1)
            {
                Console.WriteLine("Error: ticket ID not found.");
                return;
            }

            if (cancelledTickets.Contains(ticketId))
            {
                Console.WriteLine("Error: cancelled tickets cannot be booked");
                return;
            }

            if (bookingRecord.ContainsKey(ticketId))
            {
                Console.WriteLine("This ticket already has a booking please use update booking");
                return;
            }

            Console.WriteLine("Available Flights");

            for (int i = 0; i < flightNumbers.Length; i++)
            {
                Console.WriteLine(i + ": "+ flightNumbers[i]);
            }

            Console.WriteLine("Select flight index:");
            int flightIndex;
            bool flightResult = int.TryParse(Console.ReadLine(), out flightIndex);

            if (flightResult == false|| flightIndex >= flightNumbers.Length)
            {
                Console.WriteLine("Invalid flight selection");
                return;
            }

            Console.WriteLine(" Available Dates ");

            for (int i = 0; i < availableDates.Count; i++)
            {
                Console.WriteLine(i + ". " + availableDates[i]);
            }

            Console.WriteLine("Select date index:");
            int dateIndex;
            bool dateResult = int.TryParse(Console.ReadLine(), out dateIndex);

            if (dateResult == false || dateIndex >= availableDates.Count)
            {
                Console.WriteLine("Invalid date selection.");
                return;
            }

            string selectedFlight = flightNumbers[flightIndex];
            string selectedDate = availableDates[dateIndex];

            bookingRecord.Add(ticketId, selectedFlight + "& "+selectedDate);

            Console.WriteLine("Passenger Name: " + passengerNames[passengerIndex]);
            Console.WriteLine("Ticket ID: " + ticketId);
            Console.WriteLine("Flight: " + selectedFlight);
            Console.WriteLine("Date: " + selectedDate);
        }
        public static void ViewBookingDetails()
        {
            Console.WriteLine("View Booking Details");

            Console.WriteLine("Enter ticket ID:");
            string ticketId = Console.ReadLine();

            int passengerIndex = -1;

            for (int i = 0; i < ticketNumbers.Count; i++)
            {
                if (ticketNumbers[i].ToLower() == ticketId.ToLower())
                {
                    passengerIndex = i;
                    ticketId = ticketNumbers[i];
                }
            }

            if (passengerIndex == -1)
            {
                Console.WriteLine("Error: ticket ID not found.");
                return;
            }

            if (cancelledTickets.Contains(ticketId))
            {
                Console.WriteLine("This ticket has been cancelled.");
                return;
            }

            if (bookingRecord.ContainsKey(ticketId) == false)
            {
                Console.WriteLine("No booking found for this ticket.");
                return;
            }

            string bookingValue = bookingRecord[ticketId];
            string[] parts = bookingValue.Split('|');

            string flightN= parts[0];
            string fdate= parts[1];

            Console.WriteLine(" booking summary ");
            Console.WriteLine("Passenger Name: " + passengerNames[passengerIndex]);
            Console.WriteLine("Ticket ID: " + ticketId);
            Console.WriteLine("Flight number: " + flightN);
            Console.WriteLine("flight date: " + fdate);
        }
        public static void UpdateBooking()
        {
            Console.WriteLine(" Update a Booking ");

            Console.WriteLine("Enter ticket ID:");
            string ticketId = Console.ReadLine();

            int passengerIndex = -1;

            for (int i = 0; i < ticketNumbers.Count; i++)
            {
                if (ticketNumbers[i].ToLower() == ticketId.ToLower())
                {
                    passengerIndex = i;
                    ticketId = ticketNumbers[i];
                }
            }

            if (passengerIndex == -1)
            {
                Console.WriteLine("Error: ticket ID not found.");
                return;
            }

            if (cancelledTickets.Contains(ticketId))
            {
                Console.WriteLine("Cancelled tickets cannot be updated.");
                return;
            }

            if (bookingRecord.ContainsKey(ticketId) == false)
            {
                Console.WriteLine("This ticket does not have a booking.");
                return;
            }

            string Value = bookingRecord[ticketId];
            string[] parts = Value.Split('|');

            string oldFlight = parts[0];
            string oldDate = parts[1];

            string newFlight = oldFlight;
            string newDate = oldDate;

            Console.WriteLine("Current Flight: " + oldFlight);
            Console.WriteLine("Current Date: " + oldDate);

            Console.WriteLine("1. Change flight only");
            Console.WriteLine("2. Change date only");
            Console.WriteLine("3. Change both");
            Console.WriteLine("0. Cancel update");

            Console.WriteLine("Select option:");
            int option;
            bool enteroption = int.TryParse(Console.ReadLine(), out option);

            if (enteroption == false)
            {
                Console.WriteLine("Invalid option.");
                return;
            }

            if (option == 0)
            {
                Console.WriteLine("Update cancelled.");
                return;
            }

            if (option < 1 || option > 3)
            {
                Console.WriteLine("Invalid option.");
                return;
            }

            if (option == 1 || option == 3)
            {
                Console.WriteLine(" Available Flights ");

                for (int i = 0; i < flightNumbers.Length; i++)
                {
                    Console.WriteLine(i + "." + flightNumbers[i]);
                }

                Console.WriteLine("Select new flight index:");
                int flightIndex;
                bool flightResult = int.TryParse(Console.ReadLine(), out flightIndex);

                if (flightResult == false || flightIndex >= flightNumbers.Length)
                {
                    Console.WriteLine("Invalid flight selection.");
                    return;
                }

                newFlight = flightNumbers[flightIndex];
            }

            if (option == 2 || option == 3)
            {
                Console.WriteLine(" Available Dates ");

                for (int i = 0; i < availableDates.Count; i++)
                {
                    Console.WriteLine(i + ". " + availableDates[i]);
                }

                Console.WriteLine("Select new date index:");
                int dateIndex;
                bool dateResult = int.TryParse(Console.ReadLine(), out dateIndex);

                if (dateResult == false || dateIndex >= availableDates.Count)
                {
                    Console.WriteLine("Invalid date selection.");
                    return;
                }

                newDate = availableDates[dateIndex];
            }

            bookingRecord[ticketId] = newFlight + "|" + newDate;

            Console.WriteLine(" New Update");
            Console.WriteLine("Passenger: " + passengerNames[passengerIndex]);
            Console.WriteLine("Old Booking: " + oldFlight + " | " + oldDate);
            Console.WriteLine("New Booking: " + newFlight + " | " + newDate);
        }
        public static void CancelTicket()
        {
            Console.WriteLine(" Cancel a Ticket ");

            Console.WriteLine("Enter ticket ID:");
            string ticketId = Console.ReadLine();

            int passengerIndex = -1;

            for (int i = 0; i < ticketNumbers.Count; i++)
            {
                if (ticketNumbers[i].ToLower() == ticketId.ToLower())
                {
                    passengerIndex = i;
                    ticketId = ticketNumbers[i];
                }
            }

            if (passengerIndex == -1)
            {
                Console.WriteLine("Error: ticket ID not found.");
                return;
            }

            if (cancelledTickets.Contains(ticketId))
            {
                Console.WriteLine("This ticket is already cancelled.");
                return;
            }

            string passengerName = passengerNames[passengerIndex];

            if (bookingRecord.ContainsKey(ticketId))
            {
                string removedBooking = bookingRecord[ticketId];
                bookingRecord.Remove(ticketId);

                Console.WriteLine("Removed booking: " + removedBooking);
            }
            else
            {
                Console.WriteLine("No booking found to remove.");
            }

            cancelledTickets.Add(ticketId);


            if (checkedInQueue.Contains(passengerName))
            {
                Queue<string> tempQueue = new Queue<string>();

                while (checkedInQueue.Count > 0)
                {
                    string name = checkedInQueue.Dequeue();

                    if (name == passengerName)
                    {
                        Console.WriteLine("removed from queue");
                    }
                    else
                    {
                        tempQueue.Enqueue(name);
                    }
                }

                while (tempQueue.Count > 0)
                {
                    checkedInQueue.Enqueue(tempQueue.Dequeue());
                }
            }


            if (boardingStack.Contains(passengerName))
            {
                Stack<string> tempStack = new Stack<string>();

                while (boardingStack.Count > 0)
                {
                    string name = boardingStack.Pop();

                    if (name == passengerName)
                    {
                        Console.WriteLine("removed from boarding stack");
                    }
                    else
                    {
                        tempStack.Push(name);
                    }
                }

                while (tempStack.Count > 0)
                {
                    boardingStack.Push(tempStack.Pop());
                }
            }

            Console.WriteLine(" Cancellation Summary ");
            Console.WriteLine("Passenger Name: " + passengerName);
            Console.WriteLine("Ticket ID: " + ticketId);
            Console.WriteLine("Ticket added to cancelled list.");
        }
        public static void PassengerCheckIn()
        {
            bool back = false;

            while (back == false)
            {
                Console.WriteLine("1. Check in a passenger");
                Console.WriteLine("2. View check-in queue");
                Console.WriteLine("3. Process next passenger");
                Console.WriteLine("0. Back");

                Console.WriteLine("Select option:");
                int option;
                bool enteroption = int.TryParse(Console.ReadLine(), out option);

                if (enteroption == false)
                {
                    Console.WriteLine("Invalid option.");
                    continue;
                }

                switch (option)
                {
                    case 1:
                        Console.WriteLine("Enter ticket ID:");
                        string ticketId = Console.ReadLine();

                        int passengerIndex = -1;

                        for (int i = 0; i < ticketNumbers.Count; i++)
                        {
                            if (ticketNumbers[i].ToLower() == ticketId.ToLower())
                            {
                                passengerIndex = i;
                                ticketId = ticketNumbers[i];
                            }
                        }

                        if (passengerIndex == -1)
                        {
                            Console.WriteLine("Ticket ID not found.");
                            break;
                        }

                        if (cancelledTickets.Contains(ticketId))
                        {
                            Console.WriteLine("Cancelled ticket cannot check in.");
                            break;
                        }

                        if (bookingRecord.ContainsKey(ticketId) == false)
                        {
                            Console.WriteLine("Passenger must have a booking before check-in.");
                            break;
                        }

                        string passengerName = passengerNames[passengerIndex];

                        if (checkedInQueue.Contains(passengerName))
                        {
                            Console.WriteLine("Passenger is already in the check-in queue.");
                            break;
                        }

                        if (waitlistQueue.Contains(passengerName))
                        {
                            Console.WriteLine("Passenger is already in the waitlist.");
                            break;
                        }

                        if (checkedInQueue.Count < 10)
                        {
                            checkedInQueue.Enqueue(passengerName);
                            Console.WriteLine(passengerName + " added to check-in queue.");
                        }
                        else
                        {
                            waitlistQueue.Enqueue(passengerName);
                            Console.WriteLine(passengerName + " placed on waitlist because queue is full.");
                        }

                        break;

                    case 2:
                        Console.WriteLine(" Current Check-In Queue ");

                        if (checkedInQueue.Count == 0)
                        {
                            Console.WriteLine("Check-in queue is empty.");
                        }
                        else
                        {
                            int position = 1;

                            foreach (string passenger in checkedInQueue)
                            {
                                Console.WriteLine("Position " + position + ": " + passenger);
                                position++;
                            }
                        }

                        Console.WriteLine("We have whait list with :" + waitlistQueue.Count + "persond");
                        break;

                    case 3:
                        if (checkedInQueue.Count == 0)
                        {
                            Console.WriteLine("No passengers in check-in queue.");
                            break;
                        }

                        string processedPassenger = checkedInQueue.Dequeue();

                        Console.WriteLine("Processed passenger: " + processedPassenger);

                        if (waitlistQueue.Count > 0)
                        {
                            string waitPassenger = waitlistQueue.Dequeue();
                            checkedInQueue.Enqueue(waitPassenger);

                            Console.WriteLine(waitPassenger + " moved from waitlist to check-in queue.");
                        }

                        break;

                    case 0:
                        back = true;
                        break;
                }
            }

        }
        public static void BoardPassengers()
        {
            bool back = false;

            while (back == false)
            {
                Console.WriteLine("Board Passengers");
                Console.WriteLine("1. Load boarding stack from check-in queue");
                Console.WriteLine("2. Board next passenger");
                Console.WriteLine("3. View boarding stack");
                Console.WriteLine("4. View boarding log");
                Console.WriteLine("0. Back");

                Console.WriteLine("Select option:");
                int option;
                bool optionResult = int.TryParse(Console.ReadLine(), out option);

                if (optionResult == false)
                {
                    Console.WriteLine("Invalid option");
                    continue;
                }

                switch (option)
                {
                    case 1:
                        if (checkedInQueue.Count == 0 && boardingStack.Count > 0)
                        {
                            Console.WriteLine("Boarding stack is already loaded");
                            break;
                        }

                        if (checkedInQueue.Count == 0)
                        {
                            Console.WriteLine("No checked-in passengers to load");
                            break;
                        }

                        int count = 0;

                        while (checkedInQueue.Count > 0)
                        {
                            string passenger = checkedInQueue.Dequeue();
                            boardingStack.Push(passenger);
                            count++;
                        }

                        Console.WriteLine("Loaded passengers to boarding stack: " + count);
                        break;

                    case 2:
                        if (boardingStack.Count == 0)
                        {
                            Console.WriteLine("Boarding stack is empty");
                            break;
                        }

                        string boardedPassenger = boardingStack.Pop();

                        string seat = seatRow + seatLetter.ToString();

                        seatLetter++;

                        if (seatLetter > 'F')
                        {
                            seatLetter = 'A';
                            seatRow++;
                        }

                        if (passengerSeatMap.ContainsKey(boardedPassenger))
                        {
                            passengerSeatMap[boardedPassenger] = seat;
                        }
                        else
                        {
                            passengerSeatMap.Add(boardedPassenger, seat);
                        }

                        Console.WriteLine("Passenger boarded: " + boardedPassenger);
                        Console.WriteLine("Assigned seat: " + seat);
                        break;

                    case 3:
                        Console.WriteLine("Boarding Stack");

                        if (boardingStack.Count == 0)
                        {
                            Console.WriteLine("Boarding stack is empty");
                            break;
                        }

                        int position = 1;

                        foreach (string passenger in boardingStack)
                        {
                            Console.WriteLine("Position " + position + ": " + passenger);
                            position++;
                        }

                        break;

                    case 4:
                        Console.WriteLine("Boarding Log ");

                        if (passengerSeatMap.Count == 0)
                        {
                            Console.WriteLine("No passengers boarded yet.");
                            break;
                        }

                        foreach (KeyValuePair<string, string> passenger in passengerSeatMap)
                        {
                            Console.WriteLine(passenger.Key + " | Seat: " + passenger.Value);
                        }

                        break;

                    case 0:
                        back = true;
                        break;
                }
            }
        }
        public static void GenerateFlightManifest()
        {
            Console.WriteLine("Generate Flight Manifest");

            Console.WriteLine("Enter flight number:");
            string flight = Console.ReadLine();

            bool flightFound = false;

            for (int i = 0; i < flightNumbers.Length; i++)
            {
                if (flightNumbers[i].ToLower() == flight.ToLower())
                {
                    flightFound = true;
                    flight = flightNumbers[i];
                }
            }

            if (flightFound == false)
            {
                Console.WriteLine("Invalid flight number.");
                return;
            }

            List<string> manifestRecords = new List<string>();

            foreach (KeyValuePair<string, string> booking in bookingRecord)
            {
                string ticketId = booking.Key;
                string bookingValue = booking.Value;

                string[] bookingParts = bookingValue.Split('|');

                string bookedFlight = bookingParts[0];
                string bookedDate = bookingParts[1];

                if (bookedFlight.ToLower() == flight.ToLower())
                {
                    int passengerIndex = -1;

                    for (int i = 0; i < ticketNumbers.Count; i++)
                    {
                        if (ticketNumbers[i] == ticketId)
                        {
                            passengerIndex = i;
                        }
                    }

                    if (passengerIndex != -1)
                    {
                        string passengerName = passengerNames[passengerIndex];

                        string seat = "—";

                        if (passengerSeatMap.ContainsKey(passengerName))
                        {
                            seat = passengerSeatMap[passengerName];
                        }

                        string status = "Booked";

                        if (passengerSeatMap.ContainsKey(passengerName))
                        {
                            status = "Boarded";
                        }
                        else if (checkedInQueue.Contains(passengerName))
                        {
                            status = "Checked-In";
                        }
                        else if (cancelledTickets.Contains(ticketId))
                        {
                            status = "Cancelled";
                        }

                        string record = passengerName + "|" + ticketId + "|" + bookedDate + "|" + seat + "|" + status;

                        manifestRecords.Add(record);
                    }
                }
            }

            if (manifestRecords.Count == 0)
            {
                Console.WriteLine("No passengers booked on this flight.");
                return;
            }

            for (int i = 0; i < manifestRecords.Count - 1; i++)
            {
                for (int j = 0; j < manifestRecords.Count - i - 1; j++)
                {
                    string[] firstParts = manifestRecords[j].Split('|');
                    string[] secondParts = manifestRecords[j + 1].Split('|');

                    string firstName = firstParts[0];
                    string secondName = secondParts[0];

                    if (firstName.CompareTo(secondName) > 0)
                    {
                        string temp = manifestRecords[j];
                        manifestRecords[j] = manifestRecords[j + 1];
                        manifestRecords[j + 1] = temp;
                    }
                }
            }

            Console.WriteLine("No. | Passenger Name | Ticket ID | Date | Seat | Status");

            int boardedCount = 0;
            int checkedInCount = 0;
            int cancelledCount = 0;

            for (int i = 0; i < manifestRecords.Count; i++)
            {
                string[] parts = manifestRecords[i].Split('|');

                string passengerName = parts[0];
                string ticketId = parts[1];
                string date = parts[2];
                string seat = parts[3];
                string status = parts[4];

                Console.WriteLine((i + 1) + ". " + passengerName + " | " + ticketId + " | " + date + " | " + seat + " | " + status);

                if (status == "Boarded")
                {
                    boardedCount++;
                }
                else if (status == "Checked-In")
                {
                    checkedInCount++;
                }
                else if (status == "Cancelled")
                {
                    cancelledCount++;
                }
            }

            Console.WriteLine("Manifest Summary");
            Console.WriteLine("Total passengers on flight: " + manifestRecords.Count);
            Console.WriteLine("Boarded: " + boardedCount);
            Console.WriteLine("Checked-In: " + checkedInCount);
            Console.WriteLine("Cancelled: " + cancelledCount);
        }
        public static void ManageWaitlistAndSeatAssignment()
        {
            bool back = false;

            while (back == false)
            {
                Console.WriteLine("Manage Waitlist & Seat Assignment");
                Console.WriteLine("1. View waitlist");
                Console.WriteLine("2. Promote next waitlist passenger");
                Console.WriteLine("3. Promote specific waitlist passenger");
                Console.WriteLine("4. Reassign passenger seat");
                Console.WriteLine("0. Back");

                Console.WriteLine("Select option:");
                int option;
                bool optionResult = int.TryParse(Console.ReadLine(), out option);

                if (optionResult == false)
                {
                    Console.WriteLine("Invalid option.");
                    continue;
                }

                switch (option)
                {
                    case 1:
                        Console.WriteLine("Waitlist Queue");

                        if (waitlistQueue.Count == 0)
                        {
                            Console.WriteLine("Waitlist is empty.");
                        }
                        else
                        {
                            int position = 1;

                            foreach (string passenger in waitlistQueue)
                            {
                                Console.WriteLine("Position " + position + ": " + passenger);
                                position++;
                            }
                        }

                        Console.WriteLine("Total waitlist count: " + waitlistQueue.Count);
                        break;

                    case 2:
                        if (waitlistQueue.Count == 0)
                        {
                            Console.WriteLine("Waitlist is empty.");
                            break;
                        }

                        string passengerName = waitlistQueue.Dequeue();

                        int passengerIndex = -1;

                        for (int i = 0; i < passengerNames.Count; i++)
                        {
                            if (passengerNames[i].ToLower() == passengerName.ToLower())
                            {
                                passengerIndex = i;
                            }
                        }

                        if (passengerIndex == -1)
                        {
                            Console.WriteLine("Passenger does not have a valid ticket ID.");
                            break;
                        }

                        string ticketId = ticketNumbers[passengerIndex];

                        if (cancelledTickets.Contains(ticketId))
                        {
                            Console.WriteLine("Cancelled ticket cannot be promoted.");
                            break;
                        }

                        Console.WriteLine("Available Flights");

                        for (int i = 0; i < flightNumbers.Length; i++)
                        {
                            Console.WriteLine(i + ". " + flightNumbers[i]);
                        }

                        Console.WriteLine("Select flight index:");
                        int flightIndex;
                        bool flightResult = int.TryParse(Console.ReadLine(), out flightIndex);

                        if (flightResult == false || flightIndex < 0 || flightIndex >= flightNumbers.Length)
                        {
                            Console.WriteLine("Invalid flight selection.");
                            break;
                        }

                        Console.WriteLine("Available Dates");

                        for (int i = 0; i < availableDates.Count; i++)
                        {
                            Console.WriteLine(i + ". " + availableDates[i]);
                        }

                        Console.WriteLine("Select date index:");
                        int dateIndex;
                        bool dateResult = int.TryParse(Console.ReadLine(), out dateIndex);

                        if (dateResult == false || dateIndex < 0 || dateIndex >= availableDates.Count)
                        {
                            Console.WriteLine("Invalid date selection.");
                            break;
                        }

                        string selectedFlight = flightNumbers[flightIndex];
                        string selectedDate = availableDates[dateIndex];

                        if (bookingRecord.ContainsKey(ticketId))
                        {
                            bookingRecord[ticketId] = selectedFlight + "|" + selectedDate;
                        }
                        else
                        {
                            bookingRecord.Add(ticketId, selectedFlight + "|" + selectedDate);
                        }

                        Console.WriteLine("Promotion Confirmation");
                        Console.WriteLine("Passenger: " + passengerName);
                        Console.WriteLine("Ticket ID: " + ticketId);
                        Console.WriteLine("Flight: " + selectedFlight);
                        Console.WriteLine("Date: " + selectedDate);
                        break;

                    case 3:
                        Console.WriteLine("Enter passenger name:");
                        string targetPassenger = Console.ReadLine();

                        Queue<string> tempQueue = new Queue<string>();
                        bool found = false;
                        string selectedPassenger = "";

                        while (waitlistQueue.Count > 0)
                        {
                            string passenger = waitlistQueue.Dequeue();

                            if (passenger.ToLower() == targetPassenger.ToLower() && found == false)
                            {
                                found = true;
                                selectedPassenger = passenger;
                            }
                            else
                            {
                                tempQueue.Enqueue(passenger);
                            }
                        }

                        while (tempQueue.Count > 0)
                        {
                            waitlistQueue.Enqueue(tempQueue.Dequeue());
                        }

                        if (found == false)
                        {
                            Console.WriteLine("Passenger was not found in the waitlist.");
                            break;
                        }

                        int selectedIndex = -1;

                        for (int i = 0; i < passengerNames.Count; i++)
                        {
                            if (passengerNames[i].ToLower() == selectedPassenger.ToLower())
                            {
                                selectedIndex = i;
                            }
                        }

                        if (selectedIndex == -1)
                        {
                            Console.WriteLine("Passenger does not have a valid ticket ID.");
                            break;
                        }

                        string selectedTicket = ticketNumbers[selectedIndex];

                        if (cancelledTickets.Contains(selectedTicket))
                        {
                            Console.WriteLine("Cancelled ticket cannot be promoted.");
                            break;
                        }

                        Console.WriteLine("Available Flights");

                        for (int i = 0; i < flightNumbers.Length; i++)
                        {
                            Console.WriteLine(i + ". " + flightNumbers[i]);
                        }

                        Console.WriteLine("Select flight index:");
                        int selectedFlightIndex;
                        bool selectedFlightResult = int.TryParse(Console.ReadLine(), out selectedFlightIndex);

                        if (selectedFlightResult == false || selectedFlightIndex < 0 || selectedFlightIndex >= flightNumbers.Length)
                        {
                            Console.WriteLine("Invalid flight selection.");
                            break;
                        }

                        Console.WriteLine("Available Dates");

                        for (int i = 0; i < availableDates.Count; i++)
                        {
                            Console.WriteLine(i + ". " + availableDates[i]);
                        }

                        Console.WriteLine("Select date index:");
                        int selectedDateIndex;
                        bool selectedDateResult = int.TryParse(Console.ReadLine(), out selectedDateIndex);

                        if (selectedDateResult == false || selectedDateIndex < 0 || selectedDateIndex >= availableDates.Count)
                        {
                            Console.WriteLine("Invalid date selection.");
                            break;
                        }

                        string newFlight = flightNumbers[selectedFlightIndex];
                        string newDate = availableDates[selectedDateIndex];

                        if (bookingRecord.ContainsKey(selectedTicket))
                        {
                            bookingRecord[selectedTicket] = newFlight + "|" + newDate;
                        }
                        else
                        {
                            bookingRecord.Add(selectedTicket, newFlight + "|" + newDate);
                        }

                        Console.WriteLine("Promotion Confirmation");
                        Console.WriteLine("Passenger: " + selectedPassenger);
                        Console.WriteLine("Ticket ID: " + selectedTicket);
                        Console.WriteLine("Flight: " + newFlight);
                        Console.WriteLine("Date: " + newDate);
                        break;

                    case 4:
                        Console.WriteLine("Enter passenger name:");
                        string seatPassenger = Console.ReadLine();

                        if (passengerSeatMap.ContainsKey(seatPassenger) == false)
                        {
                            Console.WriteLine("Passenger is not boarded, so seat cannot be reassigned.");
                            break;
                        }

                        string oldSeat = passengerSeatMap[seatPassenger];

                        Console.WriteLine("Enter new seat code:");
                        string newSeat = Console.ReadLine();

                        if (newSeat == "")
                        {
                            Console.WriteLine("Seat code cannot be empty.");
                            break;
                        }

                        passengerSeatMap[seatPassenger] = newSeat;

                        Console.WriteLine("Seat Reassignment Confirmation");
                        Console.WriteLine("Passenger: " + seatPassenger);
                        Console.WriteLine("Old Seat: " + oldSeat);
                        Console.WriteLine("New Seat: " + newSeat);
                        break;

                    case 0:
                        back = true;
                        break;
                }
            }
        }

        static void Main(string[] args)
        {
            bool exit = false;

            while (exit == false)
            {
                Console.WriteLine();
                Console.WriteLine("Main menu:");
                Console.WriteLine("1.  Register New Passenger");
                Console.WriteLine("2. View All Passengers");
                Console.WriteLine("3. Book a Flight Ticket");
                Console.WriteLine("4. View Booking Details");
                Console.WriteLine("5. Update a Booking");
                Console.WriteLine("6. Cancel a Ticket");
                Console.WriteLine("7. Passenger Check-In");
                Console.WriteLine("8. Board Passengers");
                Console.WriteLine("9. Generate Flight Manifest");
                Console.WriteLine("10. Manage Waitlist & Seat Assignment");

                Console.WriteLine("Please select an option from the menu:");
                int option = int.Parse(Console.ReadLine());

                switch (option)
                {
                    case 1:
                        RegisterNewPassenger();
                        break;
                    case 2:
                        ViewAllPassengers();
                        break;
                    case 3:
                        BookFlightTicket();
                        break;
                    case 4:
                        ViewBookingDetails();
                        break;
                    case 5:
                        UpdateBooking();
                        break;
                    case 6:
                        CancelTicket();
                        break;
                    case 7:
                        PassengerCheckIn();
                        break;
                    case 8:
                        BoardPassengers();
                        break;
                    case 9:
                        GenerateFlightManifest();
                        break;
                    case 10:
                        ManageWaitlistAndSeatAssignment();
                        break;
                }
            }
        }
    }
}