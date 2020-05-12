using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Diagnostics;

/*
  Erstellt von Fabian Sieder
 
  Erstelle eine Implementierung des Quicksort-Algorithmus in C/C++/C#. 
  Dabei soll eine Liste von N zufällig erstellten Fließkommazahlen sortiert werden.
  Erstelle zusätzlich eine Analyse der Geschwindigkeit:
  Für gewählte N (100,1.000,10.000,....) mache jeweils 10 Durchläufe der Sortierung und notiere die Ausführungszeit.
  Stelle die jeweilige durchschnittliche Ausführungszeit in einem ExcelDiagramm dar. Gib das Programm und die Tabelle im Register ab.
*/

namespace Quicksort
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 1000000; //Länge des Arrays festlegen
            Random r = new Random();
            double[] Zahlen = new double[n];
            Stopwatch timer = new Stopwatch();

            Console.WriteLine("Unsortiertes Array:");

            for (int i = 0; i < n; i++) //Array mit zufälligen Fließkommazahlen füllen
            {
                Zahlen[i] = r.NextDouble();
                Console.Write(Zahlen[i] + " ");
            }

            timer.Start();

            Quicksort(Zahlen, 0, (n - 1));

            Console.WriteLine("\nSortiertes Array:");  

            for (int i = 0; i < n; i++) //sortiertes Array ausgeben
            {
                Console.Write(Zahlen[i] + " ");
            }

            timer.Stop();

            Console.ForegroundColor = ConsoleColor.Green;

            Console.WriteLine("\nLaufzeit: {0}ms", timer.ElapsedMilliseconds);

            Console.ReadKey();
        }

        static void Quicksort(double[] Array, int links, int rechts)
        {
            int i = links;
            int j = rechts;

            double pivot = Array[(links + rechts) / 2];

            while (i <= j)
            {
                while (Array[i] < pivot)
                    i++;

                while (Array[j] > pivot)
                    j--;

                if (i <= j)
                {
                    double hilfsvar = Array[i];
                    Array[i] = Array[j];
                    Array[j] = hilfsvar;

                    i++;
                    j--;
                }
            }

            if (links < j)
                Quicksort(Array, links, j);

            if (i < rechts)
                Quicksort(Array, i, rechts);
        }
    }
}
