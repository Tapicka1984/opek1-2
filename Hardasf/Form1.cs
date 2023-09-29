using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hardasf
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            list.Clear();
        }

        List<int> list = new List<int>();
        List<char> charList = new List<char>();

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            listBox3.Items.Clear();
            listBox4.Items.Clear();
            try
            {
                int N = int.Parse(textBox1.Text);
                Random rng = new Random();
                int n = 0;
                while (n < N)
                {
                    int cislo = rng.Next(-4, 101);
                    list.Add(cislo);
                    n++;
                }
                Vypis(list, listBox1);
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Smazani_dokonalych_cisel(list);
            Vypis(list, listBox2);
        }

        void Smazani_dokonalych_cisel(List<int> list)
        {
            List<int> dokonala_cisla = new List<int>();
            foreach (int i in list)
            {
                if (DokonaleCisloJeNeni(i))
                    dokonala_cisla.Add(i);
            }
            foreach (int i in dokonala_cisla)
            {
                list.Remove(i);
            }
        }

        public bool DokonaleCisloJeNeni(int cislo)
        {
            List<int> delitele = new List<int>();
            for (int i = 1; i <= cislo / 2; i++)
            {
                if (cislo % i == 0)
                {
                    delitele.Add(i);
                }
            }

            int soucet = 0;
            foreach (int i in delitele)
                soucet += i;
            if (soucet == cislo)
                return true;
            else
                return false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Sorting(list);
            Vypis(list, listBox3);
        }

        public void Sorting(List<int> list)
        {
            list.Sort();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Prumer(list);
        }

        void Prumer(List<int> list)
        {
            int soucet = 0;
            int pocet = 0;
            foreach(int i in list)
            {
                soucet += i;
                pocet++;
            }
            MessageBox.Show("aritmeticky prumer cisel je: " + soucet / pocet);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Druhe max: " + Maximum(list));
        }

        public int Maximum(List<int>list)
        {
            int max = int.MinValue;
            int dMax = 0;
            foreach (int i in list)
            {
                if (i > max)
                {
                    dMax = max;
                    max = i;
                }
            }
            if (dMax != int.MinValue)
                return dMax;
            else
                return 0;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Cif_soucet (list);
        }

        void Cif_soucet(List<int> list)
        {
            int cislo = list.Max();
            int soucet = 0;
            while (cislo > 0)
            {
                soucet += cislo % 10;
                cislo /= 10;
            }

            MessageBox.Show("ciferny soucet je: " + soucet);
        }

        void Vypis(List<int> list, ListBox listbox)
        {
            listbox.Items.Clear();
            foreach(int i in list)
            {
                listbox.Items.Add(i);
            }
        }
        void Vypis(List<char> list, ListBox listbox)
        {
            listbox.Items.Clear();
            foreach (char i in list)
            {
                listbox.Items.Add(i);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            charList.Clear();
            foreach (int i in list)
            {
                if (i >= 'A' && i <= 'Z')
                {
                    charList.Add((char)i);
                }
                else
                {
                    charList.Add('*');
                }
            }
            Vypis(charList, listBox4);
        }


        //xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx

        private void button8_Click(object sender, EventArgs e)
        {
            int n;
            try
            {
                Random rng = new Random();
                n = int.Parse(textBox2.Text);
                int[] pole = new int[n];
                for (int i = 0; i < n; i++)
                {
                    pole[i] = rng.Next(1, 26);
                }

                Vypis(pole, listBox5);
                int index = 0;
                int posledniPrvocislo = PoslPrvocislo(pole, ref index);
                if (index != -1)
                    MessageBox.Show("Poslední prvočíslo: " + posledniPrvocislo + " na pozici: " + index);
                else
                    MessageBox.Show("V poli nebylo nalezeno žádné prvočíslo.");
                Vymen(pole);
                Vypis(pole, listBox6);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Zadejte platné číslo: " + ex.Message);
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            MessageBox.Show(Maximalni(textBox3.Text, textBox4.Text));
        }

        public int PoslPrvocislo(int[] pole, ref int index)
        {
            int cislo = 0;
            index = -1;
            for (int i = 0; i < pole.Length; i++)
            {
                if (JePrvocislo(pole[i]))
                {
                    cislo = pole[i];
                    index = i;
                }
            }

            return cislo;
        }

        void Vymen(int[] pole)
        {
            if (pole.Length >= 2) 
            {
                int pomocna = pole[0];
                pole[0] = pole[pole.Length - 1];
                pole[pole.Length - 1] = pomocna;
            }
        }

        public void Vypis(int[] pole, ListBox lb)
        {
            lb.Items.Clear();
            foreach (int i in pole)
                lb.Items.Add(i);
        }

        bool JePrvocislo(int cislo)
        {
            if (cislo <= 1)
                return false;
            if (cislo == 2)
                return true;
            if (cislo % 2 == 0)
                return false;

            for (int i = 3; i * i <= cislo; i += 2)
            {
                if (cislo % i == 0)
                    return false;
            }
            return true;
        }

        string Maximalni(string veta, string parametr)
        {
            string[] slova = veta.Split(' ');
            int index = -1, maxDelka = 0;
            foreach (string s in slova)
            {
                if (s.Contains(parametr) && s.Length > maxDelka)
                {
                    index = Array.IndexOf(slova, s); 
                    maxDelka = s.Length;
                }
            }
            if (index != -1)
                return slova[index];
            else
                return "";
        }
    }
}
