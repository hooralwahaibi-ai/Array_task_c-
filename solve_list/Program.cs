using System;
using System.Collections.Generic;

namespace TS_DS_01
{
    internal class Program
    {
        public static void TemperatureLog()
        {
            List<double> temperatures = new List<double>();
            temperatures.AddRange(new double[] { 43.5, 35.0, 47.8, 44, 49.9, 47.5, 48 });

            for (int i = 0; i < temperatures.Count; i++)
            {
                Console.WriteLine("Day" + (i + 1) + ":" + temperatures[i] + "C");
            }

            Console.WriteLine("total number of stored readings:" + temperatures.Count);
        }

        public static void StudentScoreBoard()
        {
            List<int> scores = new List<int>();
            scores.AddRange(new int[] { 85, 90, 75, 100, 95, 98 });

            Console.WriteLine("The scores:");

            foreach (int score in scores)
            {
                Console.WriteLine(score);
            }

            Console.WriteLine("The scores after reverse:");

            scores.Reverse();

            for (int i = 0; i < scores.Count; i++)
            {
                Console.WriteLine(scores[i]);
            }
        }

        public static void ProductPriceFinder()
        {
            List<double> prices = new List<double>();
            prices.AddRange(new double[] { 4.99, 2.5, 10.75, 5.5, 15 });

            double targetPrice = 10.75;

            for (int i = 0; i < prices.Count; i++)
            {
                Console.WriteLine("Product " + (i + 1) + ": " + prices[i]);
            }

            int index = prices.IndexOf(targetPrice);

            if (index == -1)
            {
                Console.WriteLine(targetPrice + " this price was not found");
            }
            else
            {
                Console.WriteLine(targetPrice + " this price was found at index: " + index);
            }
        }

        public static void RaceFinishTimes()
        {
            List<int> finishTimes = new List<int>();
            finishTimes.AddRange(new int[] { 340, 315, 390, 300, 360, 330, 410, 325 });

            Console.WriteLine("Original finish times:");

            foreach (int time in finishTimes)
            {
                Console.WriteLine(time + " seconds");
            }

            finishTimes.Sort();

            Console.WriteLine("The time after sort:");

            foreach (int time in finishTimes)
            {
                Console.WriteLine(time + " seconds");
            }

            Console.WriteLine("Total participants: " + finishTimes.Count);
        }

        public static void ClassroomGradeReport()
        {
            List<int> grades = new List<int>();
            grades.AddRange(new int[] { 78, 95, 66, 88, 91, 73, 84, 100, 59, 80 });

            grades.Sort();
            grades.Reverse();

            for (int i = 0; i < grades.Count; i++)
            {
                Console.WriteLine("Rank " + (i + 1) + ": " + grades[i]);
            }
        }

        public static void WarehouseInventoryCheck()
        {
            List<int> quantities = new List<int>();
            quantities.AddRange(new int[] { 20, 50, 35, 10, 80, 45, 60, 25 });

            int total = 0;
            int targetQ = 50;

            for (int i = 0; i < quantities.Count; i++)
            {
                total = total + quantities[i];
            }

            Console.WriteLine("Total stock: " + total);

            double average = (double)total / quantities.Count;

            Console.WriteLine("The average stock per slot: " + average);

            int index = quantities.IndexOf(targetQ);

            if (index == -1)
            {
                Console.WriteLine(targetQ + " this target quantity was not found");
            }
            else
            {
                Console.WriteLine(targetQ + " this target quantity is found at index: " + index);
            }
        }

        public static void LibraryBookShelfScanner()
        {
            List<int> copies = new List<int>();
            copies.AddRange(new int[] { 3, 0, 7, 2, 10, 5, 1, 4, 6 });

            Console.WriteLine("Copy counts in original order:");

            foreach (int copy in copies)
            {
                Console.WriteLine(copy);
            }

            copies.Sort();

            Console.WriteLine("List after sorted:");

            foreach (int copy in copies)
            {
                Console.WriteLine(copy);
            }

            Console.WriteLine("The book with the most copies has: " + copies[copies.Count - 1]);

            bool checkZero = false;

            for (int i = 0; i < copies.Count; i++)
            {
                if (copies[i] == 0)
                {
                    checkZero = true;
                }
            }

            if (checkZero == true)
            {
                Console.WriteLine("There is a book with zero copies");
            }
            else
            {
                Console.WriteLine("There are no books with zero copies");
            }
        }

        public static void SalesPerformanceAnalyzer()
        {
            List<double> revenue = new List<double>();
            revenue.AddRange(new double[] { 1200.50, 1500.75, 1100, 800.25, 1700.90, 1600.40, 2000, 1900.30, 1750.60, 2100.80, 1950.20, 2200.00 });

            List<double> sortedCopy = new List<double>();
            sortedCopy.AddRange(revenue);

            Console.WriteLine("Original monthly revenue:");

            for (int i = 0; i < revenue.Count; i++)
            {
                Console.WriteLine("Month " + (i + 1) + ": " + revenue[i] + " OMR");
            }

            sortedCopy.Sort();

            Console.WriteLine("Sorted revenue trend:");

            for (int i = 0; i < sortedCopy.Count; i++)
            {
                Console.WriteLine(sortedCopy[i] + " OMR");
            }

            Console.WriteLine("Worst month revenue: " + sortedCopy[0] + " OMR");
            Console.WriteLine("Best month revenue: " + sortedCopy[sortedCopy.Count - 1] + " OMR");

            double total = 0;

            for (int i = 0; i < revenue.Count; i++)
            {
                total = total + revenue[i];
            }

            double average = total / revenue.Count;

            Console.WriteLine("Average monthly revenue: " + average + " OMR");
        }

        public static void FlightSeatAllocationDisplay()
        {
            List<int> seats = new List<int>();
            seats.AddRange(new int[] { 22, 5, 14, 30, 8, 19, 1, 27, 11, 35, 3, 40, 16, 25, 7 });

            List<int> reverse = new List<int>();

            int targetSeat = 19;

            Console.WriteLine("Original seat assignment:");

            foreach (int seat in seats)
            {
                Console.WriteLine(seat);
            }

            seats.Sort();

            Console.WriteLine("Sorted boarding order:");

            foreach (int seat in seats)
            {
                Console.WriteLine(seat);
            }

            int index = seats.IndexOf(targetSeat);

            if (index == -1)
            {
                Console.WriteLine(targetSeat + " the target seat was not found");
            }
            else
            {
                Console.WriteLine(targetSeat + " the target seat found at sorted index: " + index);
            }

            reverse.AddRange(seats);
            reverse.Reverse();

            Console.WriteLine("Sorted and reversed seats side by side:");

            for (int i = 0; i < seats.Count; i++)
            {
                Console.WriteLine("Sorted: " + seats[i] + "   Reversed: " + reverse[i]);
            }

            Console.WriteLine("Total seat count: " + seats.Count);
        }

        public static void HospitalPatientPriorityQueue()
        {
            List<int> severity = new List<int>();
            severity.AddRange(new int[] { 10, 7, 1, 5, 2, 9, 4, 6, 3, 10, 8, 2, 5, 1, 7, 6, 4, 3, 9, 8 });

            List<int> sortedSeverity = new List<int>();
            sortedSeverity.AddRange(severity);

            int targetSeverity = 3;

            sortedSeverity.Sort();

            int position1 = sortedSeverity.Count / 2;
            int position2 = (sortedSeverity.Count / 2) - 1;

            double firstNum = sortedSeverity[position1];
            double secondNum = sortedSeverity[position2];

            double median = (firstNum + secondNum) / 2.0;

            Console.WriteLine("The median is: " + median);

            sortedSeverity.Reverse();

            Console.WriteLine("Triage priority list:");

            for (int i = 0; i < sortedSeverity.Count; i++)
            {
                Console.WriteLine("Rank " + (i + 1) + ": Severity " + sortedSeverity[i]);
            }

            int count = 0;

            for (int i = 0; i < severity.Count; i++)
            {
                if (severity[i] <= 3)
                {
                    count++;
                }
            }

            Console.WriteLine("Number of critical cases: " + count);

            int index = sortedSeverity.IndexOf(targetSeverity);

            if (index == -1)
            {
                Console.WriteLine(targetSeverity + " the target severity was not found");
            }
            else
            {
                Console.WriteLine(targetSeverity + " the target severity found at index: " + index);
            }
        }

        static void Main(string[] args)
        {
            bool exit = false;

            while (exit == false)
            {
                Console.WriteLine();
                Console.WriteLine("Main menu:");
                Console.WriteLine("0. Temperature Log");
                Console.WriteLine("1. Student Score Board");
                Console.WriteLine("2. Product Price Finder");
                Console.WriteLine("3. Race Finish Times");
                Console.WriteLine("4. Classroom Grade Report");
                Console.WriteLine("5. Warehouse Inventory Check");
                Console.WriteLine("6. Library Book Shelf Scanner");
                Console.WriteLine("7. Sales Performance Analyzer");
                Console.WriteLine("8. Flight Seat Allocation Display");
                Console.WriteLine("9. Hospital Patient Priority Queue");

                Console.WriteLine("Please select an option from the menu:");
                int option = int.Parse(Console.ReadLine());

                switch (option)
                {
                    case 0:
                        TemperatureLog();
                        break;

                    case 1:
                        StudentScoreBoard();
                        break;

                    case 2:
                        ProductPriceFinder();
                        break;

                    case 3:
                        RaceFinishTimes();
                        break;

                    case 4:
                        ClassroomGradeReport();
                        break;

                    case 5:
                        WarehouseInventoryCheck();
                        break;

                    case 6:
                        LibraryBookShelfScanner();
                        break;

                    case 7:
                        SalesPerformanceAnalyzer();
                        break;

                    case 8:
                        FlightSeatAllocationDisplay();
                        break;

                    case 9:
                        HospitalPatientPriorityQueue();
                        break;
                }
            }
        }
    }
}