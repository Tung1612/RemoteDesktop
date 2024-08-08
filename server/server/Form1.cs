using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace server
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnKetNoi_Click(object sender, EventArgs e)
        {
            new Form2(int.Parse(txtPort.Text)).Show();
            btnKetNoi.Enabled = false; // Vô hiệu hóa nút "Kết nối" để tránh việc tạo thêm nhiều kết nối.
        }
    }
}

