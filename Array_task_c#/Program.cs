using System;

namespace TS_DS_01
{
    internal class Program
    {
        public static void TemperatureLog()
        {
            double[] temperatures = new double[7] { 43.5, 35.0, 47.8, 44, 49.9, 47.5, 48 };

            for (int i = 0; i < temperatures.Length; i++)
            {
                Console.WriteLine("Day" + (i + 1) + ": " + temperatures[i] + "C");
            }

            Console.WriteLine("total number of stored readings:" + temperatures.Length);
        }
        public static void StudentScoreBoard()
        {
            int[] scores = new int[6] { 85, 90, 75, 100, 95, 98 };
            Console.WriteLine("the score:");

            foreach (int score in scores)
            {
                Console.WriteLine(score);
            }

            Console.WriteLine("the score after reverse:");
            Array.Reverse(scores);

            for (int i = 0; i < scores.Length; i++)
            {
                Console.WriteLine(scores[i]);
            }
        }
        public static void ProductPriceFinder()
        {
            double[] prices = new double[5] { 4.99, 2.5, 10.75, 5.5, 15 };
            double targetPrice = 10.75;

            for (int i = 0; i < prices.Length; i++)
            {
                Console.WriteLine("Product " + (i + 1) + ":" + prices[i]);
            }

            int index = Array.IndexOf(prices, targetPrice);

            if (index == -1)
            {
                Console.WriteLine(targetPrice + "this price was not found");
            }
            else
            {
                Console.WriteLine(targetPrice + " this price was found at index: " + index); ;
            }
        }
        public static void RaceFinishTimes()
        {
            int[] finishTimes = new int[8] { 340, 315, 390, 300, 360, 330, 410, 325 };

            foreach (int time in finishTimes)
            {
                Console.WriteLine(time + "seconds");
            }

            Array.Sort(finishTimes);
            Console.WriteLine("the time after sort:");

            foreach (int time in finishTimes)
            {
                Console.WriteLine(time + "seconds");
            }

            Console.WriteLine("Total participants:" + finishTimes.Length);
        }
        public static void ClassroomGradeReport()
        {
            int[] grades = new int[10] { 78, 95, 66, 88, 91, 73, 84, 100, 59, 80 };

            Array.Sort(grades);
            Array.Reverse(grades);

            for (int i = 0; i < grades.Length; i++)
            {
                Console.WriteLine("Rank" + (i + 1) + ":" + grades[i]);
            }
        }
        public static void WarehouseInventoryCheck()
        {
            int[] quantities = new int[8] { 20, 50, 35, 10, 80, 45, 60, 25 };
            int total = 0;
            int targetQ = 50;

            for (int i = 0; i < quantities.Length; i++)
            {
                total = total + quantities[i];
            }

            Console.WriteLine("total stock:" + total);

            double average = (double)total / quantities.Length;

            Console.WriteLine(" the average stock per slot:" + average);

            int index = Array.IndexOf(quantities, targetQ);

            if (index == -1)
            {
                Console.WriteLine(targetQ + " this target quantity was not found");
            }
            else
            {
                Console.WriteLine(targetQ + " this target quantity is found at index:" + index);
            }
        }
        public static void LibraryBookShelfScanner()
        {
            int[] copies = new int[9] { 3, 0, 7, 2, 10, 5, 1, 4, 6 };

            Console.WriteLine(" copy counts in original order:");

            foreach (int copy in copies)
            {
                Console.WriteLine(copy);
            }

            Array.Sort(copies);

            Console.WriteLine("array after sorted");

            foreach (int copy in copies)
            {
                Console.WriteLine(copy);
            }

            Console.WriteLine("The book with the most copies has: " + copies[8]);

            bool Checkzero = false;

            for (int i = 0; i < copies.Length; i++)
            {
                if (copies[i] == 0)
                {
                    Checkzero = true;
                }
            }

            if (Checkzero == true)
            {
                Console.WriteLine("There is a book with zero copies");
            }
            else
            {
                Console.WriteLine("There are no books with zero copies.");
            }
        }
        public static void SalesPerformanceAnalyzer()
        {
            double[] revenue = new double[12] { 1200.50,1500.75,1100,800.25,1700.90,1600.40,2000,1900.30,1750.60,2100.80,1950.20,2200.00 };
            double[] sortedCopy = new double[12];

            Console.WriteLine("original monthly revenue:");

            for (int i = 0; i < revenue.Length; i++)
            {
                Console.WriteLine("month " + (i + 1) + ":" + revenue[i] + "OMR");
            }

            for (int i = 0; i < revenue.Length; i++)
            {
                sortedCopy[i] = revenue[i];
            }

            Array.Sort(sortedCopy);

            Console.WriteLine("sorted revenue trend:");

            for (int i = 0; i < sortedCopy.Length; i++)
            {
                Console.WriteLine(sortedCopy[i] + " OMR");
            }

            Console.WriteLine("worst month revenue: " + sortedCopy[0] + " OMR");
            Console.WriteLine("best month revenue: " + sortedCopy[11] + " OMR");

            double total = 0;

            for (int i = 0; i < revenue.Length; i++)
            {
                total = total + revenue[i];
            }

            double average = total / revenue.Length;

            Console.WriteLine("average monthly revenue: " + average + " OMR");
        }
        public static void FlightSeatAllocationDisplay()
        {
            int[] seats = new int[15] { 22, 5, 14, 30, 8, 19, 1, 27, 11, 35, 3, 40, 16, 25, 7 };
            int[] reverse = new int[15];
            int targetSeat = 19;

            Console.WriteLine("original seat assignment:");

            foreach (int seat in seats)
            {
                Console.WriteLine(seat);
            }

            Array.Sort(seats);

            Console.WriteLine("sorted boarding order:");

            foreach (int seat in seats)
            {
                Console.WriteLine(seat);
            }

            int index = Array.IndexOf(seats, targetSeat);

            if (index == -1)
            {
                Console.WriteLine(targetSeat + " the target seat was not found");
            }
            else
            {
                Console.WriteLine(targetSeat + "the target seat found at sorted index: " + index);
            }

            for (int i = 0; i < seats.Length; i++)
            {
                reverse[i] = seats[i];
            }

            Array.Reverse(reverse);

            Console.WriteLine("sorted and reversed reats side by side:");

            for (int i = 0; i < seats.Length; i++)
            {
                Console.WriteLine("Sorted: " + seats[i] + "Reversed: " + reverse[i]);
            }

            Console.WriteLine("total seat count: " + seats.Length);
        }
        public static void HospitalPatientPriorityQueue()
        {
            int[] severity = new int[20] { 10, 7, 1, 5, 2, 9, 4, 6, 3, 10, 8, 2, 5, 1, 7, 6, 4, 3, 9, 8 };
            int[] sortedSeverity = new int[20];
            int targetSeverity = 3;

            for (int i = 0; i < severity.Length; i++)
            {
                sortedSeverity[i] = severity[i];
            }

            Array.Sort(sortedSeverity);

            //int position1 = (sortedSeverity.Length/2);
            //int position2 = (sortedSeverity.Length / 2) - 1;
            //double firstNum = sortedSeverity[position1];
            //double secondNum = sortedSeverity[position2];
            //double median = (firstNum + secondNum) / 2.0;

            //alternative way for calculate median
            //
            double median = (sortedSeverity[sortedSeverity.Length / 2]+ sortedSeverity[(sortedSeverity.Length / 2) - 1])/ 2.0;
            Console.WriteLine("the meaian is:" + median);
            Array.Reverse(sortedSeverity);

            Console.WriteLine("triage priority List:");

            for (int i = 0; i < sortedSeverity.Length; i++)
            {
                Console.WriteLine("Rank" + (i + 1) + ": Severity" + sortedSeverity[i]);
            }

            int count = 0;

            for (int i = 0; i < severity.Length; i++)
            {
                if (severity[i] <= 3)
                {
                   count++;
                }
            }

            Console.WriteLine("Number of critical cases: " + count);

            int index = Array.IndexOf(sortedSeverity, targetSeverity);

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
                Console.WriteLine("Main menu:");
                Console.WriteLine("0. Temperature Log");
                Console.WriteLine("1.  Student Score Board");
                Console.WriteLine("2. Product Price Finder");
                Console.WriteLine("3. Race Finish Times ");
                Console.WriteLine("4. Classroom Grade Report");
                Console.WriteLine("5. Warehouse Inventory Check ");
                Console.WriteLine("6. Library Book Shelf Scanner");
                Console.WriteLine("7. Sales Performance Analyzer");
                Console.WriteLine("8. Flight Seat Allocation Display");
                Console.WriteLine("9. Hospital Patient Priority Queue  ");


                Console.WriteLine("please select an option from the menu:");
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

