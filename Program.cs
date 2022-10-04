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
            //Erzeugen Sie eine Zufallszahl von1 bis 6.
            Random rng = new Random();
            int ergebnis = rng.Next(1, 7); //[1;7[
            Würfel.W6(3);

            //for (int i = 0; i < 100; i++)
            //{
            //    Console.Write(rng.Next(1, 7) + " ");
            //}
            int[] zahlen = Würfel.W6(5); //Die Methode W6 aus der Klasse Würfel erzeugt
                                         //ein Array, das als zahlen gespeichert wird.
            WriteArray(zahlen);
            WriteArray(Würfel.W6(5));

        }
        /* Erstellen Sie das folgende Würfspiel:
         * Es werden 5 Würfel (W6) mit 6 Seiten geworfen.
         * es gibt Punkte nach folgenden Regeln:
         * 3 Einsen ---> 1000 Punkte
         * 3 Sechsen --> 600 Punkte
         * 3 Funfen ---> 500 Punkte
         * 3 Vieren ---> 400 Punkte
         * 3 Dreien ---> 300 Punkte
         * 3 Zweien ---> 200 Punkte
         * Eine Eins --> 100 Punkte
         * Eine Fünf --> 50 Punkte
         * Jeder Würfel wird nur ein Mal gezählt.
         * 
         * Beispiel:
         * Würfel         Punkte
         * 1 2 3 2 2      300 (100 + 200)
         * 1 2 2 3 4      100  
         * 3 3 3 3 3      300
         * 2 2 3 3 4      0
         * 
         * Hinweis: Sie können das Spiel in der Klasse Program oder
         * einer eigenen Klasse erstellen.
         * 
         * Tipps zur Lösung komplexer Aufgaben:
         *  - Versuchen Sie Ihre Probleme zu formulieren.
         *    (Was genau brauche ich, um das Problem zu lösen,
         *    welche Schritte kann ich gehen?)
         *  - Versuchen Sie das große Problem kleinere Probleme zu
         *    zerlegen.
         *    (Bsp.: Wie bestimme ich die Anzahl von "2" in einem Array?)
         */
        static int ZweiZählen(int[] zahlenliste)
        {
            int counter = 0;
            for (int k = 0; k < zahlenliste.Length; k++)
            {
                if(zahlenliste[k] == 2)
                {
                    counter++;
                }
            }
            return counter++;
        }
        static void WriteArray(int[] array)
        {
            for (int k = 0; k < array.Length; k++)
            {
                Console.Write(array[k] + " ");
            }
        }
    }
    /*Schreiben Sie die Klasse Würfel. In der Klasse gibt es Keine Objekte.
     * In dieser Klasse soll es verschiedene Methoden geben, die Zufalls-
     * zahlen generieren.
     * 
     */
    class Würfel
    {
        //Eine Klasse ohne Objekte hat keinen Konstruktor.
        /*Aufgabe 1: Erstellen Sie die Methode W6(int anzahl). In die
         * Methode wird die Anzahl der Würfel eingegeben, die geworfen
         * werden sollen. Die Methode gibt ein int[] mit den gewürfelten
         * Ergebnissen zurück. 
         * Achtung: Diese Methode bezieht sich nichtauf ein Objekt (wir haben
         * ja kein Objekte in dieser Klasse), deshalb muss die Methode
         * statish sein (static).
         */
        private static Random rng = new Random();
        public static int[] W6(int anzahlWürfel)
        {
            //Random rng = new Random();
            //int Ergebnis = rng.Next(1, 6);
            //for (int i = 0; i < anzahlWürfel + 1; i++)
            //{
            //    Console.Write("{ " + rng.Next(1, 6) + ",");
            //}
            //Console.Write("}");
            Random rng = new Random();
            int[] result = new int[anzahlWürfel];
            for(int k = 0; k<result.Length; k++)
            {
                result[k] = rng.Next(1, 7);
            }
            return result;
        }
        //Bsp : W(6) -> {2;5;6;1}
        
    }
}



