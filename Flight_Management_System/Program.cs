using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Linq;

namespace FlightManagementSystem
{
    internal class Program
    {
        static List<string> passengerNames = new List<string>()
        {"Hoor Khalifa","Bayan Khalifa","Fatma Yousif","Khalifa salim"};

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
        // files name
        static string passengersFile = "passengers.txt";
        static string bookingsFile = "bookings.txt";
        static string cancelledFile = "cancelledTickets.txt";
        static string checkedInFile = "checkedInQueue.txt";
        static string waitlistFile = "waitlistQueue.txt";
        static string boardingStackFile = "boardingStack.txt";
        static string seatsFile = "passengerSeats.txt";
        static string stateFile = "seatState.txt";

        // about dataset functions
        public static void SaveData()
        {
            List<string> passengerLines = passengerNames
                .Select((name, index) => name + "|" + ticketNumbers[index])
                .ToList();

            File.WriteAllLines(passengersFile, passengerLines);

            List<string> bookingLines = bookingRecord
                .Select(booking => booking.Key + "|" + booking.Value)
                .ToList();

            File.WriteAllLines(bookingsFile, bookingLines);

            File.WriteAllLines(cancelledFile, cancelledTickets);

            File.WriteAllLines(checkedInFile, checkedInQueue);

            File.WriteAllLines(waitlistFile, waitlistQueue);

            List<string> stackLines = boardingStack
                .Reverse()
                .ToList();

            File.WriteAllLines(boardingStackFile, stackLines);

            List<string> seatLines = passengerSeatMap
                .Select(passenger => passenger.Key + "|" + passenger.Value)
                .ToList();

            File.WriteAllLines(seatsFile, seatLines);

            List<string> stateLines = new List<string>();
            stateLines.Add(seatRow.ToString());
            stateLines.Add(seatLetter.ToString());

            File.WriteAllLines(stateFile, stateLines);
        }
        public static void LoadData()
        {
            if (File.Exists(passengersFile))
            {
                passengerNames.Clear();
                ticketNumbers.Clear();

                string[] lines = File.ReadAllLines(passengersFile);

                foreach (string line in lines)
                {
                    if (line.Trim() != "")
                    {
                        string[] parts = line.Split('|');

                        if (parts.Length >= 2)
                        {
                            passengerNames.Add(parts[0]);
                            ticketNumbers.Add(parts[1]);
                        }
                    }
                }
            }

            bookingRecord.Clear();

            if (File.Exists(bookingsFile))
            {
                string[] lines = File.ReadAllLines(bookingsFile);

                foreach (string line in lines)
                {
                    if (line.Trim() != "")
                    {
                        string[] parts = line.Split('|');

                        if (parts.Length >= 3)
                        {
                            string ticketId = parts[0];
                            string flight = parts[1];
                            string date = parts[2];

                            if (bookingRecord.ContainsKey(ticketId) == false)
                            {
                                bookingRecord.Add(ticketId, flight + "|" + date);
                            }
                        }
                    }
                }
            }

            cancelledTickets.Clear();

            if (File.Exists(cancelledFile))
            {
                cancelledTickets = File.ReadAllLines(cancelledFile)
                    .Where(line => line.Trim() != "")
                    .ToList();
            }

            checkedInQueue.Clear();

            if (File.Exists(checkedInFile))
            {
                string[] lines = File.ReadAllLines(checkedInFile);

                foreach (string line in lines)
                {
                    if (line.Trim() != "")
                    {
                        checkedInQueue.Enqueue(line);
                    }
                }
            }

            waitlistQueue.Clear();

            if (File.Exists(waitlistFile))
            {
                string[] lines = File.ReadAllLines(waitlistFile);

                foreach (string line in lines)
                {
                    if (line.Trim() != "")
                    {
                        waitlistQueue.Enqueue(line);
                    }
                }
            }

            boardingStack.Clear();

            if (File.Exists(boardingStackFile))
            {
                string[] lines = File.ReadAllLines(boardingStackFile);

                foreach (string line in lines)
                {
                    if (line.Trim() != "")
                    {
                        boardingStack.Push(line);
                    }
                }
            }

            passengerSeatMap.Clear();

            if (File.Exists(seatsFile))
            {
                string[] lines = File.ReadAllLines(seatsFile);

                foreach (string line in lines)
                {
                    if (line.Trim() != "")
                    {
                        string[] parts = line.Split('|');

                        if (parts.Length >= 2)
                        {
                            string passengerName = parts[0];
                            string seat = parts[1];

                            if (passengerSeatMap.ContainsKey(passengerName) == false)
                            {
                                passengerSeatMap.Add(passengerName, seat);
                            }
                        }
                    }
                }
            }

            if (File.Exists(stateFile))
            {
                string[] lines = File.ReadAllLines(stateFile);

                if (lines.Length >= 2)
                {
                    int row;
                    bool rowResult = int.TryParse(lines[0], out row);

                    if (rowResult == true)
                    {
                        seatRow = row;
                    }

                    if (lines[1].Length > 0)
                    {
                        seatLetter = lines[1][0];
                    }
                }
            }
        }
        //helper functions 

        public static int FindTicketIndex(string ticketId)
        {
            var ticket = ticketNumbers
                .Select((ticket, index) => new { Ticket = ticket, Index = index })
                .FirstOrDefault(t => t.Ticket.Equals(ticketId, StringComparison.OrdinalIgnoreCase));

            if (ticket == null)
            {
                return -1;
            }

            return ticket.Index;
        }
        public static int FindPassengerIndexByName(string passengerName)
        {
            var passenger = passengerNames
                .Select((name, index) => new { Name = name, Index = index })
                .FirstOrDefault(p => p.Name.Equals(passengerName, StringComparison.OrdinalIgnoreCase));

            if (passenger == null)
            {
                return -1;
            }

            return passenger.Index;
        }
        public static int ReadNumber(string message)
        {
            Console.WriteLine(message);

            int number;
            bool result = int.TryParse(Console.ReadLine(), out number);

            if (result == false)
            {
                return -1;
            }

            return number;
        }
        public static void RemovePassengerFromQueue(Queue<string> queue, string passengerName)
        {
            int oldCount = queue.Count;

            List<string> remainingPassengers = queue
                .Where(name => name.Equals(passengerName, StringComparison.OrdinalIgnoreCase) == false)
                .ToList();

            queue.Clear();

            foreach (string passenger in remainingPassengers)
            {
                queue.Enqueue(passenger);
            }

            if (queue.Count < oldCount)
            {
                Console.WriteLine("removed from queue");
            }
        }
        public static void RemovePassengerFromStack(Stack<string> stack, string passengerName)
        {
            int oldCount = stack.Count;

            List<string> remainingPassengers = stack
                .Where(name => name.Equals(passengerName, StringComparison.OrdinalIgnoreCase) == false)
                .Reverse()
                .ToList();

            stack.Clear();

            foreach (string passenger in remainingPassengers)
            {
                stack.Push(passenger);
            }

            if (stack.Count < oldCount)
            {
                Console.WriteLine("removed from boarding stack");
            }
        }

        public static bool GetTicketInfo(out int passengerIndex, out string ticketId, string errorMessage)
        {
            Console.WriteLine("Enter ticket ID:");
            ticketId = Console.ReadLine();

            passengerIndex = FindTicketIndex(ticketId);

            if (passengerIndex == -1)
            {
                Console.WriteLine(errorMessage);
                return false;
            }

            ticketId = ticketNumbers[passengerIndex];
            return true;
        }
        public static string SelectFlight()
        {
            Console.WriteLine("Available Flights");

            var flightList = flightNumbers
                .Select((flight, index) => index + ". " + flight)
                .ToList();

            foreach (string flight in flightList)
            {
                Console.WriteLine(flight);
            }

            int flightIndex = ReadNumber("Select flight index:");

            if (flightIndex < 0 || flightIndex >= flightNumbers.Length)
            {
                Console.WriteLine("Invalid flight selection.");
                return "";
            }

            return flightNumbers[flightIndex];
        }
        public static string SelectDate()
        {
            Console.WriteLine("Available Dates");

            var dateList = availableDates
               .Select((date, index) => index + ". " + date)
               .ToList();

            foreach (string date in dateList)
            {
                Console.WriteLine(date);
            }

            int dateIndex = ReadNumber("Select date index:");

            if (dateIndex < 0 || dateIndex >= availableDates.Count)
            {
                Console.WriteLine("Invalid date selection.");
                return "";
            }

            return availableDates[dateIndex];
        }
        public static void SaveBooking(string ticketId, string flight, string date)
        {
            if (bookingRecord.ContainsKey(ticketId))
            {
                bookingRecord[ticketId] = flight + "|" + date;
            }
            else
            {
                bookingRecord.Add(ticketId, flight + "|" + date);
            }
        }

        public static string GenerateSeat()
        {
            string seat = seatRow + seatLetter.ToString();

            seatLetter++;

            if (seatLetter > 'F')
            {
                seatLetter = 'A';
                seatRow++;
            }

            return seat;
        }

        public static void RegisterNewPassenger()
        {
            Console.WriteLine("Enter passenger full name:");
            string name = Console.ReadLine();

            if (name == "")
            {
                Console.WriteLine("Error: passenger name cannot be empty");
                return;
            }

            bool passengerExists = passengerNames
                .Any(passenger => passenger.Equals(name, StringComparison.OrdinalIgnoreCase));

            if (passengerExists)
            {
                Console.WriteLine("Error: passenger already exists");
                return;
            }

            string ticketId = "TKT-" + (passengerNames.Count + 1).ToString("D3");

            passengerNames.Add(name);
            ticketNumbers.Add(ticketId);

            SaveData();

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


            var passengers = passengerNames
                .Select((name, index) => new
                {
                    Number = index + 1,
                    Name = name,
                    Ticket = ticketNumbers[index],
                    Status = cancelledTickets.Contains(ticketNumbers[index]) ? "CANCELLED" : "Active"
                })
                .ToList();

            foreach (var passenger in passengers)
            {
                Console.WriteLine(passenger.Number + ". " + passenger.Name + " | " + passenger.Ticket + " | " + passenger.Status);
            }

            Console.WriteLine("total passengers: " + passengerNames.Count);
        }
        public static void BookFlightTicket()
        {
            Console.WriteLine("Book a Flight Ticket");

            int passengerIndex;
            string ticketId;

            if (GetTicketInfo(out passengerIndex, out ticketId, "Error: ticket ID not found.") == false)
            {
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

            string selectedFlight = SelectFlight();

            if (selectedFlight == "")
            {
                return;
            }

            string selectedDate = SelectDate();

            if (selectedDate == "")
            {
                return;
            }

            SaveBooking(ticketId, selectedFlight, selectedDate);
            SaveData();

            Console.WriteLine("Passenger Name: " + passengerNames[passengerIndex]);
            Console.WriteLine("Ticket ID: " + ticketId);
            Console.WriteLine("Flight: " + selectedFlight);
            Console.WriteLine("Date: " + selectedDate);
        }
        public static void ViewBookingDetails()
        {
            Console.WriteLine("View Booking Details");

            int passengerIndex;
            string ticketId;

            if (GetTicketInfo(out passengerIndex, out ticketId, "Error: ticket ID not found.") == false)
            {
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

            int passengerIndex;
            string ticketId;

            if (GetTicketInfo(out passengerIndex, out ticketId, "Error: ticket ID not found.") == false)
            {
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

            int option = ReadNumber("Select option:");

            if (option == -1)
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
                newFlight = SelectFlight();

                if (newFlight == "")
                {
                    return;
                }
            }

            if (option == 2 || option == 3)
            {
                newDate = SelectDate();

                if (newDate == "")
                {
                    return;
                }
            }

            SaveBooking(ticketId, newFlight, newDate);
            SaveData();

            Console.WriteLine(" New Update");
            Console.WriteLine("Passenger: " + passengerNames[passengerIndex]);
            Console.WriteLine("Old Booking: " + oldFlight + " | " + oldDate);
            Console.WriteLine("New Booking: " + newFlight + " | " + newDate);
        }
        public static void CancelTicket()
        {
            Console.WriteLine(" Cancel a Ticket ");

            int passengerIndex;
            string ticketId;

            if (GetTicketInfo(out passengerIndex, out ticketId, "Error: ticket ID not found.") == false)
            {
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
                RemovePassengerFromQueue(checkedInQueue, passengerName);
            }

            if (waitlistQueue.Contains(passengerName))
            {
                RemovePassengerFromQueue(waitlistQueue, passengerName);
            } //if a passenger is already in the waitlist and then i cancel the ticket,
              //i should remove them from the waitlist too
              // so here it will remove passenger from checkedInQueue,waitlistQueue and boardingStack


            if (boardingStack.Contains(passengerName))
            {
                RemovePassengerFromStack(boardingStack, passengerName);
            }
            SaveData();

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

                int option = ReadNumber("Select option:");

                if (option == -1)
                {
                    Console.WriteLine("Invalid option.");
                    continue;
                }

                switch (option)
                {
                    case 1:
                        int passengerIndex;
                        string ticketId;

                        if (GetTicketInfo(out passengerIndex, out ticketId, "Ticket ID not found.") == false)
                        {
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
                        SaveData();

                        break;

                    case 2:
                        Console.WriteLine(" Current Check-In Queue ");

                        if (checkedInQueue.Count == 0)
                        {
                            Console.WriteLine("Check-in queue is empty.");
                        }
                        else
                        {
                            var queueList = checkedInQueue
                                .Select((passenger, index) => "Position " + (index + 1) + ": " + passenger)
                                .ToList();

                            foreach (string passenger in queueList)
                            {
                                Console.WriteLine(passenger);
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
                        SaveData();
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

                int option = ReadNumber("Select option:");

                if (option == -1)
                {
                    Console.WriteLine("Invalid option");
                    continue;
                }

                switch (option)
                {
                    case 1:
                        if (boardingStack.Count > 0)
                        {
                            Console.WriteLine("Boarding stack already has passengers.");
                            Console.WriteLine("Use option 2 to board next passenger.");
                            break;
                        }

                        if (checkedInQueue.Count == 0)
                        {
                            Console.WriteLine("No checked-in passengers to load.");
                            Console.WriteLine("Go to Passenger Check-In first and add passengers.");
                            break;
                        }

                        int count = 0;

                        while (checkedInQueue.Count > 0)
                        {
                            string passenger = checkedInQueue.Dequeue();
                            boardingStack.Push(passenger);
                            count++;
                        }

                        SaveData();

                        Console.WriteLine("Loaded passengers to boarding stack: " + count);
                        Console.WriteLine("Check-in queue is now empty because passengers moved to boarding stack.");
                        break;

                    case 2:
                        if (boardingStack.Count == 0)
                        {
                            Console.WriteLine("Boarding stack is empty");
                            break;
                        }

                        string boardedPassenger = boardingStack.Pop();

                        string seat = GenerateSeat();

                        if (passengerSeatMap.ContainsKey(boardedPassenger))
                        {
                            passengerSeatMap[boardedPassenger] = seat;
                        }
                        else
                        {
                            passengerSeatMap.Add(boardedPassenger, seat);
                        }

                        SaveData();

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

                        var stackList = boardingStack
                            .Select((passenger, index) => "Position " + (index + 1) + ": " + passenger)
                            .ToList();

                        foreach (string passenger in stackList)
                        {
                            Console.WriteLine(passenger);
                        }

                        break;

                    case 4:
                        Console.WriteLine("Boarding Log ");

                        if (passengerSeatMap.Count == 0)
                        {
                            Console.WriteLine("No passengers boarded yet.");
                            break;
                        }

                        var boardingLog = passengerSeatMap
                            .OrderBy(passenger => passenger.Key)
                            .Select(passenger => passenger.Key + " | Seat: " + passenger.Value)
                            .ToList();

                        foreach (string passenger in boardingLog)
                        {
                            Console.WriteLine(passenger);
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

            bool flightFound = flightNumbers
                .Any(f => f.Equals(flight, StringComparison.OrdinalIgnoreCase));

            if (flightFound == false)
            {
                Console.WriteLine("Invalid flight number.");
                return;
            }

            flight = flightNumbers
                .First(f => f.Equals(flight, StringComparison.OrdinalIgnoreCase));

            List<string> manifestRecords = bookingRecord
                .Select(booking =>
                {
                    string ticketId = booking.Key;
                    string bookingValue = booking.Value;

                    string[] bookingParts = bookingValue.Split('|');

                    if (bookingParts.Length < 2)
                    {
                        return "";
                    }

                    string bookedFlight = bookingParts[0];
                    string bookedDate = bookingParts[1];

                    if (bookedFlight.Equals(flight, StringComparison.OrdinalIgnoreCase) == false)
                    {
                        return "";
                    }

                    int passengerIndex = FindTicketIndex(ticketId);

                    if (passengerIndex == -1)
                    {
                        return "";
                    }

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

                    return passengerName + "|" + ticketId + "|" + bookedDate + "|" + seat + "|" + status;
                })
                .Where(record => record != "")
                .OrderBy(record => record.Split('|')[0])
                .ToList();

            if (manifestRecords.Count == 0)
            {
                Console.WriteLine("No passengers booked on this flight.");
                return;
            }

            Console.WriteLine("No. | Passenger Name | Ticket ID | Date | Seat | Status");

            for (int i = 0; i < manifestRecords.Count; i++)
            {
                string[] parts = manifestRecords[i].Split('|');

                string passengerName = parts[0];
                string ticketId = parts[1];
                string date = parts[2];
                string seat = parts[3];
                string status = parts[4];

                Console.WriteLine((i + 1) + ". " + passengerName + " | " + ticketId + " | " + date + " | " + seat + " | " + status);
            }

            int boardedCount = manifestRecords.Count(record => record.Split('|')[4] == "Boarded");
            int checkedInCount = manifestRecords.Count(record => record.Split('|')[4] == "Checked-In");
            int cancelledCount = manifestRecords.Count(record => record.Split('|')[4] == "Cancelled");

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

                int option = ReadNumber("Select option:");

                if (option == -1)
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
                            var waitlist = waitlistQueue
                                .Select((passenger, index) => "Position " + (index + 1) + ": " + passenger)
                                .ToList();

                            foreach (string passenger in waitlist)
                            {
                                Console.WriteLine(passenger);
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

                        string passengerName = waitlistQueue.Peek(); //i change from dequeue to peek

                        int passengerIndex = FindPassengerIndexByName(passengerName);

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

                        string selectedFlight = SelectFlight();

                        if (selectedFlight == "")
                        {
                            break;
                        }

                        string selectedDate = SelectDate();

                        if (selectedDate == "")
                        {
                            break;
                        }

                        SaveBooking(ticketId, selectedFlight, selectedDate);
                        waitlistQueue.Dequeue(); //also i add this (i do this so passenger will be removed from
                                                 //the waitlist only after flight and date are selected correctly)
                        SaveData();

                        Console.WriteLine("Promotion Confirmation");
                        Console.WriteLine("Passenger: " + passengerName);
                        Console.WriteLine("Ticket ID: " + ticketId);
                        Console.WriteLine("Flight: " + selectedFlight);
                        Console.WriteLine("Date: " + selectedDate);
                        break;

                    case 3:
                        Console.WriteLine("Enter passenger name:");
                        string targetPassenger = Console.ReadLine();

                        bool found = false;
                        string selectedPassenger = waitlistQueue
                            .FirstOrDefault(passenger => passenger.Equals(targetPassenger,
                                StringComparison.OrdinalIgnoreCase)); // here i change so it will search without
                                                                      // removing anyone from the waitlist

                        if (selectedPassenger == null)
                        {
                            Console.WriteLine("Passenger was not found in the waitlist.");
                            break;
                        }

                        int selectedIndex = FindPassengerIndexByName(selectedPassenger);

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

                        string newFlight = SelectFlight();

                        if (newFlight == "")
                        {
                            break;
                        }

                        string newDate = SelectDate();

                        if (newDate == "")
                        {
                            break;
                        }

                        SaveBooking(selectedTicket, newFlight, newDate);
                        RemovePassengerFromQueue(waitlistQueue, selectedPassenger); // here the specific passenger will be removed
                        
                        SaveData();                                                     // from the waitlist only after booking is successful.

                        Console.WriteLine("Promotion Confirmation");
                        Console.WriteLine("Passenger: " + selectedPassenger);
                        Console.WriteLine("Ticket ID: " + selectedTicket);
                        Console.WriteLine("Flight: " + newFlight);
                        Console.WriteLine("Date: " + newDate);
                        break;

                    case 4:
                        Console.WriteLine("Enter passenger name:");
                        string seatPassenger = Console.ReadLine();
                        string realPassengerName = passengerSeatMap.Keys
                            .FirstOrDefault(name => name.Equals(seatPassenger,StringComparison.OrdinalIgnoreCase));

                        if (realPassengerName == null)
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

                        SaveData();

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
            LoadData();
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
                Console.WriteLine("0. Exit");

                int option = ReadNumber("Please select an option from the menu:");

                if (option == -1)
                {
                    Console.WriteLine("Invalid option.");
                    continue;
                }

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
                    case 0:
                        SaveData();
                        exit = true;
                        break;
                }
            }
        }
    }
}