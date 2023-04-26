using vizsgagyak1;

namespace vizsgavinform
{
    public partial class Form1 : Form
    {
        List<Sorsolas> sorsolas_list = new List<Sorsolas>();
        List<NySzam> nySzams_list = new List<NySzam>();
        public Form1()
        {

            

            InitializeComponent();

            string[] lines = File.ReadAllLines("sorsolas.txt");
            foreach (var item in lines)
            {
                string[] values = item.Split(';');
                Sorsolas sorsolas_object = new Sorsolas(values[0], values[1], values[2], values[3], values[4], values[5]);
                sorsolas_list.Add(sorsolas_object);
            }
            int db = 0;
            for (int i = 1; i < 91; i++)
            {
                foreach (var item in sorsolas_list)
                {
                    if (i == item.szam1)
                        db++;
                    if (i == item.szam2)
                        db++;
                    if (i == item.szam3)
                        db++;
                    if (i == item.szam4)
                        db++;
                    if (i == item.szam5)
                        db++;
                }
                NySzam nySzams_object = new NySzam(i, db);
                nySzams_list.Add(nySzams_object);
                db = 0;
            }

            //3 feladat

            int max = int.MinValue;
            int max_nySzam = 0;

            foreach (var item in nySzams_list)
            {
                if (max < item.db)
                {
                    max = item.db;
                    max_nySzam = item.szam;
                }
            }
            label2.Text=$"3. Feladat: {max_nySzam} {max}";

            //4 feladat
            int paratlanSum = 0;
            foreach (var item in nySzams_list)
            {
                if (item.szam % 2 == 1)
                {
                    paratlanSum += item.db;
                }
            }
            label3.Text=$"4. Feladat, páros számok kihúzva: {paratlanSum}";


            //5-6. feladat
            int szam4 = 0;
            int szam73 = 0;

            foreach (var item in nySzams_list)
            {
                if (item.szam == 4)
                    szam4 = item.db;
                if (item.szam == 73)
                    szam73 = item.db;
            }
            label4.Text=$"5. feladat: {szam4}"; 
            label5.Text=$"6. feladat: {szam73}";


            // 7 feladat
            foreach (var item in nySzams_list)
            {
                dataGridView1.Rows.Add(item.szam, item.db);
            }
        }


        // 2 feladat
        private void button1_Click(object sender, EventArgs e)
        {
            int szam = (int)numericUpDown1.Value;
            foreach (var item in sorsolas_list)
            {
                if (szam == item.het)
                    label1.Text = $"2, feladat:{item.het},{item.szam1},{item.szam2},{item.szam3},{item.szam4},{item.szam5}";
            }
        }
    }
}