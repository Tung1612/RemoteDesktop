using System;
using System.Windows.Forms;

namespace server
{
    public partial class Form1 : Form
    {
        // Constructor mặc định của Form
        public Form1()
        {
            InitializeComponent(); // Hàm khởi tạo giao diện của Form
        }

        // Sự kiện khi nhấn nút "Kết nối"
        private void btnKetNoi_Click(object sender, EventArgs e)
        {
            // Mở Form2 và truyền số cổng để lắng nghe kết nối
            new Form2(int.Parse(txtPort.Text)).Show();
            // Sau khi mở Form2, vô hiệu hóa nút "Kết nối"
            btnKetNoi.Enabled = false;
        }
    }
}
