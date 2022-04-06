﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hrdina_a_drak___streda_12
{
    public abstract class Postava : IComparable<Postava>, IZasazitelny
    {

        public string Jmeno { get; set; }
        public double Zdravi { get; set; }
        public double ZdraviMax { get; set; }
        public double PoskozeniMax { get; set; }
        public double ZbrojMax { get; set; }
        public bool Utekl { get; set; }

        public Postava(string jmeno, double zdravi, double zdraviMax, double poskozeniMax, double zbrojMax)
        {
            Jmeno = jmeno;
            Zdravi = zdravi;
            ZdraviMax = zdraviMax;
            PoskozeniMax = poskozeniMax;
            ZbrojMax = zbrojMax;
            Utekl = false;
        }

        /// <summary>
        /// útok postavy na oponenta
        /// </summary>
        /// <param name="oponent">oponent postavy</param>
        /// <returns>hodnota utoku</returns>
        /// <exception cref="Exception">postava již nemůže bojovat</exception>
        public virtual double Utok(IZasazitelny oponent)
        {
            return Utok(oponent, PoskozeniMax);
        }

        protected double Utok(IZasazitelny oponent, double poskozeniMax)
        {
            if (MuzeBojovat())
            {
                double hodnotaUtoku = 0;

                Random rnd = new Random();
                hodnotaUtoku = rnd.NextDouble() * poskozeniMax;
                hodnotaUtoku -= oponent.Obrana();
                oponent.SnizZdravi(hodnotaUtoku);

                return hodnotaUtoku;
            }
            else
                throw new Exception($"{Jmeno} útočí a přitom už nemůže bojovat!");
        }

        public virtual double Obrana()
        {
            double hodnotaObrany = 0;

            //dodelat

            return hodnotaObrany;
        }

        public Postava VyberOponenta(List<Postava> postavy)
        {
            foreach(var postava in postavy)
            {
                if (postava.MuzeBojovat() && postava != this && KontrolaOponenta(postava))
                {
                    return postava;
                }
            }
            return null;
        }

        public abstract bool KontrolaOponenta(Postava oponent);

        public bool MuzeVybratOponenta(List<Postava> postavy)
        {
            Postava oponent = VyberOponenta(postavy);
            if (oponent != null)
                return true;
            else
                return false;
        }

        public void SnizZdravi(double hodnotaSnizeni)
        {
            if (hodnotaSnizeni > 0)
            {
                Zdravi -= hodnotaSnizeni;
            }
        }

        public bool MuzeBojovat()
        {
            return JeZivy() && Utekl == false;
        }

        public bool JeZivy()
        {
            if (Zdravi > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public int CompareTo(Postava other)
        {
            if (other == null)
                return 1;

            return this.SilaPostavy().CompareTo(other.SilaPostavy());
        }

        public virtual double SilaPostavy()
        {
            return 0.3 * Zdravi + 0.4 * PoskozeniMax + 0.3 * ZbrojMax;
        }

        public override string ToString()
        {
            return $"{Jmeno}, Zdravi: {Zdravi}, poskozeniMax: {PoskozeniMax}, zbrojMax: {ZbrojMax}, Utekl: {Utekl}, Sila: {SilaPostavy()}";
        }
    }
}
