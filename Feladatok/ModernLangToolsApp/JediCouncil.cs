using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace ModernLangToolsApp
{
    public delegate void CouncilChangedDelegate(string message); //delegate deklaráció
    class JediCouncil
    {
        public event CouncilChangedDelegate CouncilChanged; //tagváltozóként felvétel, amin keresztül hivatkozunk a delegatere
        List<Jedi> members = new List<Jedi>(); //tagok listája
        
        public void Add(Jedi newJedi)
        {
            members.Add(newJedi);
            if (CouncilChanged != null) //le kell ellenőriznünk, mert a setternél különben probléma volna
                CouncilChanged("Új taggal bővültünk");
        }
        public void Remove() //eltávolítja a legutóbbi tagot
        {
            members.RemoveAt(members.Count - 1);
            if (CouncilChanged != null)
            {
                if (members.Count > 0) //feladat leírásának megfelelően írja a program az üzeneteket
                    PrintZavartErzek();
                else
                    TanacsElesett();
            }
        }

        public List<Jedi> GetBeginners() //vsiszaadja egy listában a kevés midichlorianszintű jediket
        {
            List<Jedi> beginners = new List<Jedi>();
            return members.FindAll(BeginnerFilter); //átadjuk, melyik függvény alapján akarjuk elvégezni a szűrést
            
        }

        static bool BeginnerFilter(Jedi j) //ez az a függvény, ami alapján szűrünk, true értéket ad vissza akkor, ha a midichlorianszint kicsi
        {
            if (j.MidiChlorianAmount < 300) return true;
            return false;
        }

        public void PrintZavartErzek()
            => CouncilChanged("Zavart érzek az erőben");

        public void TanacsElesett()
            => CouncilChanged("A tanács elesett!");

    }
}
