using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Goods
{
    public partial class Form1 : Form
    {
        private TextBox _price;
        private TextBox _amount;
        private TextBox _name;

        private Label _priceLb;
        private Label _amountLb;
        private Label _nameLb;
        public Form1()
        {
            InitializeComponent();
            save.Enabled = false;
        }

        private void add_Click(object sender, EventArgs e)
        {
            CreateInputFields();
            CreateInputLabels();

            mainPanel.Controls.Add(_price);
            mainPanel.Controls.Add(_amount);
            mainPanel.Controls.Add(_name);

            mainPanel.Controls.Add(_priceLb);
            mainPanel.Controls.Add(_amountLb);
            mainPanel.Controls.Add(_nameLb);

            add.Enabled = false;
        }

        private void CreateInputFields()
        {
            _price = new TextBox();
            _amount = new TextBox();
            _name = new TextBox();

            _name.Location = new Point(30, 20);
            _price.Location = new Point(350, 20);
            _amount.Location = new Point(500, 20);
            _name.Size = new Size(250, 20);

            save.Enabled = true;
        }

        private void ClearInputFields()
        {
            _name.Text = String.Empty;
            _price.Text = String.Empty;
            _amount.Text = String.Empty;
        }

        private void CreateInputLabels()
        {
            _priceLb = new Label();
            _amountLb = new Label();
            _nameLb = new Label();

            _nameLb.Location = new Point(30, 0);
            _priceLb.Location = new Point(350, 0);
            _amountLb.Location = new Point(500, 0);

            _nameLb.Text = "Наименование";
            _priceLb.Text = "Цена";
            _amountLb.Text = "Количество";
        }

        private void save_Click(object sender, EventArgs e)
        {
            try
            {
                Save.SaveProduct(_name.Text, _price.Text, _amount.Text);
                ShowResults.Text = "Товар успешно сохраен";
                ClearInputFields();
            }
            catch(Exception ex)
            {
                ShowResults.Text = ex.Message;
            }
        }

        private void PrintData_Click(object sender, EventArgs e)
        {
            ShowResults.Text = String.Empty;
            DataBase.FormGoodsList();
            foreach (var a in DataBase.goods)
            {
                ShowResults.Text += $"Товар {a.Name}, по цене {a.Price}, в количестве {a.Amount}";
                ShowResults.Text += "\n\n";
            }
        }
    }
}
