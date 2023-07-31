using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Security;

namespace Kursachik
{
    public partial class Sale : Form
    {
        ProductList productList;  //объявляем класс для его использования
        Basket basket; 
        double summaBasket = 0;
        public Sale()
        {
            productList = new ProductList();
            InitializeComponent();
            button1.Visible = false; //делаем невидимыми кнопки перед дальнейшим их испольованием
            label5.Visible = false;
            numericUpDown1.Visible = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect; //строка, чтоб в корзине выделялась вся строка
        }
        public Sale(ProductList productList)
        {
            this.productList = productList;
            basket = new Basket(this.productList);
            InitializeComponent();
            button1.Visible = false; //делаем невидимыми кнопки перед дальнейшим их испольованием
            label5.Visible = false;
            numericUpDown1.Visible = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect; //строка, чтоб в корзине выделялась вся строка
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            string s = "";
            double check = 0;
            productList.Check(comboBox2.Text, comboBox3.Text, out s, out check); //отправлем данные в метод
            if (check == 0) //если продукции нет, то выводим сообщение об этом
            {
                label4.ForeColor = Color.Red;
                label4.Text = "На складе не осталось запчасти";
                button1.Visible = false;
                label5.Visible = false;
                numericUpDown1.Visible = false;
            }
            else //выводим кнопку об добавлении в корзину
            {
                label4.ForeColor = Color.Black;
                label4.Text = s + string.Format("\nОсталось {0} шт. на складе", check);
                button1.Visible = true;
                label5.Visible = true;
                numericUpDown1.Visible = true;
                numericUpDown1.Maximum = Convert.ToInt32(check); //присваеваем максимум для выбора количества продукции
                numericUpDown1.Minimum = 1; //присваеваем минимум
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e) //делаем так, чтобы было невозможно выбрать продукцию без выбора категории
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
                    comboBox3.Items.AddRange(new string[] { "Нож 4075.00.001 95кг (обр.)", "Нож левый Д610-0101-05 22кг.(обр.)", "Нож правый Д610-0101-04 22кг.(обр.)", "Плита дробящая СМД60-117.3430.01.033 №14 1060кг (обр)", "Плита дробящая СМД60-117.3430.01.031 №16 670кг (обр)", "Футеровка 3023.00.005 398кг.(обр.)", "Футеровка 3023.00.002-01 270кг (обр.)", "Футеровка 3023.00.001 181кг (обр)", "Клин 1601.00.001-01 29,8кг", "Нож Д 610-01.01 31кг", "Нож Д 610-01.01-01 31кг", "Нож Д610-0101 31кг.", "Сухарь 2922.00.002-10 515кг", "Футеровка боковая 3462.01.006-01 370кг" });
                    break;
                case "Отсев фракционированный":
                    comboBox3.Items.Clear();
                    comboBox3.Items.AddRange(new string[] { "фракции 2,5-5 мм" });
                    break;
            }
        }

        private void button1_Click(object sender, EventArgs e) //кнопка добавления товара в корзину
        {
            productList.Check(comboBox2.Text, comboBox3.Text, out string nothing, out double count);
            if (count != 0) //если продукции не 0 на складе, то добавляем в корзину
            {
                basket.AddBasket(comboBox2.Text, comboBox3.Text, Convert.ToInt32(numericUpDown1.Value), out string s, out double sum); //добавляем товар в лист заказа
                summaBasket += sum * Convert.ToDouble(numericUpDown1.Value); //вычисляем общую сумму
                label6.Text = string.Format("Общая сумма: {0} руб.", summaBasket);
                dataGridView1.Rows.Add(comboBox3.Text, numericUpDown1.Value, sum * Convert.ToDouble(numericUpDown1.Value)); //добавляем в таблицу заказанные товары
            }
            else //если продукция закончилась, выводим сообщение
            {
                label4.ForeColor = Color.Red;
                label4.Text = "На складе не осталось продукции";
                button1.Visible = false;
                label5.Visible = false;
                numericUpDown1.Visible = false;
            }
        }

        private void button3_Click(object sender, EventArgs e) //кнопка удаления товара из корзины
        {
            try
            {
                summaBasket -= Convert.ToDouble(dataGridView1.SelectedCells[2].Value); //отнимает удаляемую сумму
                basket.RemoveBasket(Convert.ToString(dataGridView1.SelectedCells[0].Value)); //удаляем товар из листа
                dataGridView1.Rows.RemoveAt(dataGridView1.SelectedCells[0].RowIndex); //удаляем товар из таблицы
                label6.Text = string.Format("Общая сумма: {0} руб.", summaBasket); //выводим обновленную сумму
            }
            catch (Exception) //если товара нет, то и удалять нечего
            {
                MessageBox.Show("Корзина пуста!");
            }
        }

        private void button4_Click(object sender, EventArgs e) //кнопка оформления заказа и вывода чека
        {
            string s = "";
            double check = 0;
            switch (basket.CheckBasket()) //проверяем пустая ли корзина
            {
                case true:
                    MessageBox.Show("Корзина пуста!");
                    break;
                case false: //если корзина не пустая, то выводим чек
                    string message = string.Format("------{0}------\n", DateTime.Now);
                    message += basket.Tab();
                    message += string.Format("К оплате: {0}\nВсего хорошего!", summaBasket);
                    string title = "Оформление заказа";
                    productList.RefreshItems(basket.GetProducts,ref productList.details);
                    basket.ClearBusket(); //очищаем корзину
                    dataGridView1.Rows.Clear(); //очищаем корзину
                    dataGridView1.Refresh(); //очищаем корзину
                    summaBasket = 0;
                    label6.Text = string.Empty; //очищаем корзину
                    productList.Check(comboBox2.Text, comboBox3.Text, out s, out check); //отправлем данные в метод
                    label4.Text = s + string.Format("\nОсталось {0} шт. на складе", check);
                    DialogResult result = MessageBox.Show(message + string.Format("\n\nРаспечатать чек?"), title, MessageBoxButtons.YesNo); //выводим чек
                    if (result == DialogResult.Yes)
                    {
                        FileDialog save = new SaveFileDialog(); //команды для сохранения чека в файл
                        save.InitialDirectory = "D:";
                        save.Filter = "txt files (*.txt)|*.txt";
                        if (save.ShowDialog() == DialogResult.OK)
                        {
                            StreamWriter writer = new StreamWriter(save.FileName, true);
                            writer.WriteLine(message);
                            writer.Close();
                        }
                    }
                    break;
            }
        }

        private void Sale_FormClosing(object sender, FormClosingEventArgs e) //выход приложения при закрытии формы
        {
            Environment.Exit(0);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
