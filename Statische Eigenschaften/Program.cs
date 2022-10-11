using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Statische_Eigenschaften
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Erzeugen Sie eine Zufallszahl von 1 bis 6.
            Random rng = new Random();
           
            int ergebnis = rng.Next(1, 7); //[1;7[
            int[] zahlen = Würfel.W6(5); //Die Methode W6 aus der Klasse Würfel
                                         //erzeugt ein Array, das als zahlen gespeichert
                                         //wird.
            WriteArray(zahlen);
            WriteArray(Würfel.W6(5));

            //--- 07.10.22 ---
            Console.WriteLine("--- Wir sind gerade hier ---");
            int spiel1 = Würfel.Spiel1();
            Console.WriteLine("Ihre Punktzahl beträgt: " + spiel1);

            // --- 11.10.22---
            /*Dem Spieler soll ein Gewinn in Euros ausgschüttet werden, wenn er
             * Punkte erzielt. 100 Punkte entrsprechen einem Euro.
             * (1): Schreiben Sie eine Methode in der Klasse Würfel, die
             * den Gewinn
             * in Euro berechnet und in die Konsole schreibt.
             * (2): Ermitteln Sie den Einsatz (den Preis zum Spielen), bei
             * dem das Spiel fair ist. (fair bedeutet, dass der Spieler
             * im Verlauf von sehr vielen Spielen keinen Gewinn und keinen
             * Verlust erzielt).
             */
            double Bel = Würfel.Belohnung(spiel1);
            Console.WriteLine("Das verdiente Geld ist " + Bel + " Euros");

            double geld = 100;
            for (int i = 0; i<50; i++)
            {
                geld -= 2.15;
                geld += Würfel.Belohnung(Würfel.Spiel1());
            }
            Console.WriteLine("Sie haben noch " + geld +" Euro");
            Console.WriteLine(geld / 50);

        }
        /* Erstellen Sie das folgende Würfelspiel:
         * Es werden 5 Würfel (W6) mit 6 Seiten geworfen.
         * Es gibt Punkte nach folgenden Regeln:
         * 3 Einsen ---> 1000 Punkte
         * 3 Sechsen --> 600  Punkte
         * 3 Fünfen ---> 500  Punkte
         * 3 Vieren ---> 400  Punkte
         * 3 Dreien ---> 300  Punkte
         * 3 Zweien ---> 200  Punkte
         * Eine Eins --> 100  Punkte
         * Eine Fünf --> 50   Punkte
         * Jeder Würfel wird nur ein Mal gezählt.
         * 
         * Beispiele: 
         * Würfel           Punkte
         * 1 2 3 2 2        300 (100 + 200)
         * 1 1 1 2 1        1100 (falsch: 1400; 2400)
         * 1 2 2 3 4        100
         * 3 3 3 3 3        300
         * 2 2 3 3 4        0
         * 
         * Hinweis: Sie können das Spiel in der Klasse Programm oder 
         * einer eigenen Klasse erstellen.
         * 
         * Tipps zur Lösung komplexer Aufgaben:
         *  - Versuchen Sie Ihre Probleme zu formulieren.
         *    (Was genau brauche ich, um das Problem zu lösen,
         *    welche Schritte kann ich gehen?)
         *  - Versuchen Sie das große Problem in kleinere Probleme zu
         *    zerlegen.
         *    (Bsp.: Wie bestimme ich die Anzahl von "2" in einem Array?)
         */
        static int ZweiZählen(int[] zahlenliste)
        {
            int anzahl2 = 0;
            for(int k = 0; k < zahlenliste.Length; k++)
            {
                if(zahlenliste[k] == 2)
                {
                    anzahl2++;
                }
            }
            return anzahl2++;
        }
        static void WriteArray(int[] array) //Diese Methode schreibt ein Array in die Konsole
        {
            for(int k = 0; k < array.Length; k++)
            {
                Console.Write(array[k] + " ");
            }
        }
    }
    /* Schreiben Sie die Klasse Würfel. In der Klasse gibt es KEINE Objekte.
     * In dieser Klasse soll es verschiedene Methoden geben, die Zufalls-
     * zahlen generieren.
     */
    class Würfel
    {
        //Eine Klasse ohne Objekte hat keinen Konstruktor.
        private static Random rng = new Random();
        /* Aufgabe 1: Erstellen Sie die Methode W6(int anzahl). In die
         * Methode wird die Anzahl der Würfel eingegeben, die geworfen
         * werden sollen. Die Methode gibt ein int[] mit den gewürfelten 
         * Ergebnissen zurück.
         * Achtung: Diese Methode bezieht sich nicht auf ein Objekt (wir haben
         * ja keine Objekte in dieser Klasse), deshalb muss die Methode
         * statisch sein (static).
         */
        public static int[] W6(int anzahlWürfel)
        {
            int[] result = new int[anzahlWürfel];
            for(int k = 0; k < result.Length; k++)
            {
                result[k] = rng.Next(1,7);
            }
            return result;
        }
        //Bsp: W6(4) -> { 2; 5; 6; 1 }
        public static int[] W20(int anzahlWürfel)
        {
            int[] result = new int[anzahlWürfel];
            for (int k = 0; k < result.Length; k++)
            {
                result[k] = rng.Next(1, 21);
            }
            return result;
        }
        public static int Spiel1()
        {
            int[] würfel = W6(5); //Wir würfeln 5 mal
            //Wir können den Wurf in die Konsole schreiben:
            SchreibeWurf(würfel);
            //Wir zählen die Würfel:
            int c1 = 0, c2 = 0, c3 = 0, c4 = 0, c5 = 0, c6 = 0;
            for(int k = 0; k < würfel.Length; k++)
            {
                switch (würfel[k])
                {
                    case 1: c1++; break;
                    case 2: c2++; break;
                    case 3: c3++; break;
                    case 4: c4++; break;
                    case 5: c5++; break;
                    case 6: c6++; break;
                    default: Console.WriteLine("Error!"); break;
                }
            }
            //Console.WriteLine("c1: " + c1);
            //Console.WriteLine("c2: " + c2);
            //Console.WriteLine("c3: " + c3);
            //Console.WriteLine("c4: " + c4);
            //Console.WriteLine("c5: " + c5);
            //Console.WriteLine("c6: " + c6);
            int result = 0;
            result += PunkteSpiel1(c1, 1);
            result += PunkteSpiel1(c2, 2);
            result += PunkteSpiel1(c3, 3);
            result += PunkteSpiel1(c4, 4);
            result += PunkteSpiel1(c5, 5);
            result += PunkteSpiel1(c6, 6);
            
            return result;
           
        }
        private static void SchreibeWurf(int[] wurf)
        {
            Console.Write("Sie haben gewürfelt: ");
            for (int k = 0; k < wurf.Length; k++)
            {
                Console.Write(wurf[k] + " ");
            }
            Console.WriteLine();
        }
        public static int PunkteSpiel1(int anzahl, int augenzahl)
        {
            //anzahl = 4; augenzahl = 2; --> Ergebnis: 200
            //anzahl = 2; augenzahl = 4 ---> Ergebnis: 0
            int punktzahl = 0;
            while (anzahl > 0)
            {
                if (anzahl >= 3)
                {
                    if (augenzahl > 1) { punktzahl += augenzahl * 100; }
                    else { punktzahl += 1000; }
                    anzahl -= 3;
                }
                else
                {
                    if (augenzahl == 1) { punktzahl += 100; }
                    else if (augenzahl == 5) { punktzahl += 50; }
                    anzahl--;
                }
            }
            return punktzahl; 

        }
        public static double Belohnung (double punkte)
        {
            double result = punkte / 100;
            return result;
        }
        
        
    }
}
