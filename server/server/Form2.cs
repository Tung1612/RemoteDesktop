using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;
using System.Threading;
using System.Runtime.Serialization.Formatters.Binary;

namespace server
{
    public partial class Form2 : Form
    {
        // Khai báo các biến thành viên.
        private readonly int port; // Lưu trữ cổng kết nối.
        private TcpClient client; // Đối tượng client để kết nối với client khác.
        private TcpListener server; // Đối tượng server để lắng nghe kết nối từ client.
        private NetworkStream manHinh; // Luồng mạng để truyền dữ liệu.

        // Khai báo các luồng (threads) để xử lý đa luồng.
        private readonly Thread DangKetNoi; // Luồng để bắt đầu kết nối.
        private readonly Thread LayHinhAnh; // Luồng để nhận hình ảnh.

        // Phương thức khởi tạo của Form2, nhận tham số cổng kết nối.
        public Form2(int Port)
        {
            port = Port; // Gán giá trị cổng kết nối.
            client = new TcpClient(); // Khởi tạo đối tượng client.
            DangKetNoi = new Thread(BatDauKetNoi); // Khởi tạo luồng để bắt đầu kết nối.
            LayHinhAnh = new Thread(NhanHinhAnh); // Khởi tạo luồng để nhận hình ảnh.
            InitializeComponent(); // Khởi tạo các thành phần của form.
        }

        // Phương thức bắt đầu kết nối.
        private void BatDauKetNoi()
        {
            while (!client.Connected) // Vòng lặp để kiểm tra kết nối.
            {
                server.Start(); // Bắt đầu lắng nghe kết nối từ client.
                client = server.AcceptTcpClient(); // Chấp nhận kết nối từ client.
            }
            LayHinhAnh.Start(); // Bắt đầu luồng nhận hình ảnh.
        }

        // Phương thức dừng kết nối.
        private void DungKetNoi()
        {
            server.Stop(); // Dừng lắng nghe kết nối.
            client = null; // Giải phóng đối tượng client.
            if (DangKetNoi.IsAlive) DangKetNoi.Abort(); // Dừng luồng bắt đầu kết nối nếu còn sống.
            if (LayHinhAnh.IsAlive) LayHinhAnh.Abort(); // Dừng luồng nhận hình ảnh nếu còn sống.
        }

        // Phương thức nhận hình ảnh.
        private void NhanHinhAnh()
        {
            BinaryFormatter binFormatter = new BinaryFormatter(); // Khởi tạo bộ định dạng nhị phân.
            while (client.Connected) // Vòng lặp để kiểm tra kết nối.
            {
                manHinh = client.GetStream(); // Lấy luồng mạng từ client.
                pictureBox1.Image = (Image)binFormatter.Deserialize(manHinh); // Giải mã dữ liệu và hiển thị hình ảnh.
            }
        }

        // Phương thức xử lý sự kiện khi form được tải.
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e); // Gọi phương thức OnLoad của lớp cơ sở.
            server = new TcpListener(IPAddress.Any, port); // Khởi tạo đối tượng server với địa chỉ IP bất kỳ và cổng kết nối.
            DangKetNoi.Start(); // Bắt đầu luồng bắt đầu kết nối.
        }

        // Phương thức xử lý sự kiện khi form đóng lại.
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e); // Gọi phương thức OnFormClosing của lớp cơ sở.
            DungKetNoi(); // Dừng kết nối.
        }
    }
}
// dậdjadadaaa