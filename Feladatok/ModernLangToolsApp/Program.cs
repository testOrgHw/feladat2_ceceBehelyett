using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Xml.Serialization;

namespace ModernLangToolsApp
{
    class Program
    {

        static void MessageReceived(string message) //ezzel a függvénnyel iratkozunk fel az eseményre, ez fut le a hatására
        {
            Console.WriteLine(message);
        }

        static void Main(string[] args) //a három feladat függvényei hívódnak sorban
        {
            Jedi jedi = new Jedi(); //állatorvosi ló
            jedi.Name = "Obi-Wan";
            jedi.MidiChlorianAmount = 15000;

            XmlSerializer serializer = new XmlSerializer(typeof(Jedi));  //szerializáló inicializálása
            FileStream stream = new FileStream("jedi.txt", FileMode.Create); //stream, megadjuk, hogy hova menjen
            serializer.Serialize(stream, jedi); //tényleges szerializáció
            stream.Close();

            FileStream fs = new FileStream("jedi.txt", FileMode.Open); //kell egy másik tulajdonságú stream, ami nem új fájlt hoz létre, hanem olvas
            Jedi clone = (Jedi)serializer.Deserialize(fs); //deszerializálás
            fs.Close();

            Console.WriteLine("Jedi neve: {0},\tTapasztalat: {1}", clone.Name, clone.MidiChlorianAmount);
            //kiírja a console-ra a klón tulajdonságait, ez megegyezik az eredetiével
            JediCouncil council = new JediCouncil();
            council.CouncilChanged += MessageReceived; //feliratkozunk az eseményre

            council.Add(new Jedi("Anakin Skywalker", 20000));  //feltöltjük, majd kirugdaljuk az embereket
            council.Add(new Jedi("Kylo Ren", 18012));
            council.Remove();
            council.Remove();
            council.CouncilChanged -= MessageReceived; //leiratkozunk
            JediCouncil council = new JediCouncil();
            council.Add(new Jedi("Anakin Skywalker", 20000));
            council.Add(new Jedi("Kylo Ren", 18012));
            council.Add(new Jedi("Han Solo", 200));
            council.Add(new Jedi("Jarjar Bings", 100));
            List<Jedi> ujoncok = council.GetBeginners(); //itt történik a szűrés
            foreach (Jedi j in ujoncok)
            {
                Console.WriteLine(j.Name); //kiírjuk a feltételnek megfelelő Jedik neveit
            }
        }        
  }
    }


