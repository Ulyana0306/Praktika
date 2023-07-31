using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Kursachik
{
    public partial class Load : Form
    {
        ProductList productList; //объявляем класс для дальнейшего использования методов из него
        public Load()
        {
            productList = new ProductList();
            InitializeComponent();
        }
        public Load(ProductList productList)
        {
            InitializeComponent();
            this.productList = productList;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (productList.AddList(comboBox2.Text, comboBox3.Text, Convert.ToInt32(textBox1.Text))==true) //проверяем, если добавился товар, то выводм сообщение
            {
                label5.Text = "Добавлено!";
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e) //делаем так, чтобы было невозможно выбрать делать без выбора категории
        {
            switch (comboBox2.Text)
            {
                case "Щебень из плотных горных пород":
                    comboBox3.Items.Clear();
                    comboBox3.Items.AddRange(new string[] { "фракции 5-10 мм III группы", "фракции 5-20 мм I группы", "фракции 5-20 мм II группы", "фракции 5-20 мм III группы", "фракции 5-20 мм IVгруппы", "фракции 10-20 мм I группы", "фракции 10-20 мм III группы", "фракция 10-15 мм I группы", "фракция 20-40 мм II группы", "фракции 20-40 мм III группы", "фракции 40-70 мм II группы", "фракции 40-70 мм IV группы", "фракция 70-120 мм II группы" });
                    break;
                case "Щебень кубовидный из плотных горных пород":
                    comboBox3.Items.Clear();
                    comboBox3.Items.AddRange(new string[] { "фракции 5-10 мм II сорта" });
                    break;
                case "Щебень для балластного слоя":
                    comboBox3.Items.Clear();
                    comboBox3.Items.AddRange(new string[] { "фракции 31,5/63 мм", "фракции 31,5/50 мм FL15", "фракция 31,5/50 мм FL35" });
                    break;
                case "Щебень из горных пород":
                    comboBox3.Items.Clear();
                    comboBox3.Items.AddRange(new string[] { "фракции 8-16 мм Л10", "фракция 8-16 мм Л25", "фракция 4-16 мм Л25", "фракции 4-16 мм Л15", "фракции 16-31,5 мм Л20", "фракции 31,5-63 мм Л30", "фракция 16-22,4 Л10" });
                    break;
                case "Крупный заполнитель для бетона":
                    comboBox3.Items.Clear();
                    comboBox3.Items.AddRange(new string[] { "фракции 4/8 мм FL15", "фракции 4/8 мм FL35", "фракции 4/16 мм FL15", "фракции 4/16 мм FL15 ДСЦ-2", "фракции 4/16 мм FL35", "фракции 8/16 мм FL15", "фракции 8/16 мм FL35", "фракции 16/22 мм FL15", "фракции 16/32 мм FL15" });
                    break;
                case "Щебеночно-песчаная смесь для дорожного строительства":
                    comboBox3.Items.Clear();
                    comboBox3.Items.AddRange(new string[] { "марки С5", "марки С6" });
                    break;
                case "Смесь заполнителей":
                    comboBox3.Items.Clear();
                    comboBox3.Items.AddRange(new string[] { "фракции 0/32 мм", "фракции 0/4 мм" });
                    break;
                case "Неликвиды":
                    comboBox3.Items.Clear();
                    comboBox3.Items.AddRange(new string[] { "Нож 4075.00.001 95кг (обр.)", "Нож левый Д610-0101-05 22кг.(обр.)", "Нож правый Д610-0101-04 22кг.(обр.)", "Плита дробящая СМД60-117.3430.01.033 №14 1060кг (обр)", "Плита дробящая СМД60-117.3430.01.031 №16 670кг (обр)", "Футеровка 3023.00.005 398кг.(обр.)", "Футеровка 3023.00.002-01 270кг (обр.)", "Футеровка 3023.00.001 181кг (обр)", "Клин 1601.00.001-01 29,8кг", "Нож Д 610-01.01 31кг", "Нож Д 610-01.01-01 31кг", "Нож Д610-0101 31кг", "Сухарь 2922.00.002-10 515кг", "Футеровка боковая 3462.01.006-01 370кг" });
                    break;
                case "Отсев фракционированный":
                    comboBox3.Items.Clear();
                    comboBox3.Items.AddRange(new string[] { "фракции 2,5-5 мм" });
                    break;
            }
        }

        private void Load_FormClosed(object sender, FormClosedEventArgs e) //выводим первоначальную форму, если закроем эту форму
        {
            Form f = Application.OpenForms[0];
            f.Show();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void Quite_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Form1 first = new Form1(productList);
            first.StartPosition = FormStartPosition.Manual; // меняем параметр StartPosition у Form1, иначе она будет использовать тот, который у неё прописан в настройках и всегда будет открываться по центру экрана
            first.Left = this.Left; // задаём открываемой форме позицию слева равную позиции текущей формы
            first.Top = this.Top; // задаём открываемой форме позицию сверху равную позиции текущей формы
            first.Show(); // отображаем Form1 
            this.Hide();
        }
    }
}
