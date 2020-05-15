using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace ModernLangToolsApp
{
    [XmlRoot("Jedi")]
    public class Jedi
    {

        //Paraméteres konstruktor a könnyebb inicializáláshoz
        public Jedi(string name, int midichlorian)
        {
           Name = name;
           MidiChlorianAmount = midichlorian;
            //Propertyk által adunk értéket
        }
        public Jedi() { }
        private int midiChlorianAmount;
        //Attribútumok hozzárendelése a propetrykhez
        [XmlAttribute("Név")]

        //autoimplementált property elég, nincs ellenőrzés
        public string Name { get; set; }
        [XmlAttribute("MidiChlorianSzam")]
        public int MidiChlorianAmount
        {
            get { return midiChlorianAmount; }
            set
            {
                //ellenőrzés, hogy megfelelő értékeket állíthassunk csak be - nem elég az autoimplementált property
                if (value <= 10) throw new ArgumentException("You are not a true jedi!");
                midiChlorianAmount = value;
            }
        }
    }
}
