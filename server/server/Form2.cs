using System;
using System.Drawing;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;
using System.Windows.Forms;

namespace server
{
    public partial class Form2 : Form
    {
        // Biến lưu cổng để lắng nghe kết nối từ client
        private readonly int port;
        // Đối tượng TcpClient để nhận kết nối từ client
        private TcpClient client;
        // Đối tượng TcpListener để lắng nghe kết nối từ client
        private TcpListener server;
        // Luồng dữ liệu để nhận hình ảnh màn hình từ client
        private NetworkStream manHinh;
        // Hai luồng riêng biệt: một để lắng nghe kết nối, một để nhận hình ảnh
        private readonly Thread DangKetNoi;
        private readonly Thread LayHinhAnh;

        // Constructor của Form2
        public Form2(int Port)
        {
            port = Port; // Lưu số cổng được truyền vào từ Form1
            client = new TcpClient(); // Khởi tạo đối tượng TcpClient
            DangKetNoi = new Thread(BatDauKetNoi); // Khởi tạo luồng lắng nghe kết nối từ client
            LayHinhAnh = new Thread(NhanHinhAnh); // Khởi tạo luồng nhận hình ảnh từ client
            InitializeComponent(); // Khởi tạo giao diện của Form
        }

        // Hàm bắt đầu lắng nghe kết nối từ client
        private void BatDauKetNoi()
        {
            while (!client.Connected) // Vòng lặp liên tục cho đến khi có kết nối từ client
            {
                server.Start(); // Bắt đầu lắng nghe kết nối từ client
                client = server.AcceptTcpClient(); // Chấp nhận kết nối từ client
            }
            LayHinhAnh.Start(); // Bắt đầu luồng nhận hình ảnh khi đã kết nối thành công
        }

        // Hàm dừng kết nối và ngắt các luồng đang chạy
        private void DungKetNoi()
        {
            server.Stop(); // Dừng lắng nghe kết nối
            client = null; // Đặt đối tượng client về null
            // Dừng luồng lắng nghe kết nối nếu nó đang chạy
            if (DangKetNoi.IsAlive) DangKetNoi.Abort();
            // Dừng luồng nhận hình ảnh nếu nó đang chạy
            if (LayHinhAnh.IsAlive) LayHinhAnh.Abort();
        }

        // Hàm nhận hình ảnh từ client và hiển thị trên PictureBox
        private void NhanHinhAnh()
        {
            BinaryFormatter binFormatter = new BinaryFormatter(); // Khởi tạo BinaryFormatter để giải tuần tự hóa đối tượng hình ảnh
            while (client.Connected) // Vòng lặp liên tục khi client vẫn đang kết nối
            {
                manHinh = client.GetStream(); // Lấy luồng dữ liệu từ client
                pictureBox1.Image = (Image)binFormatter.Deserialize(manHinh); // Giải tuần tự hóa đối tượng hình ảnh và gán cho PictureBox
                pictureBox1.Dock = DockStyle.Fill; // Đặt PictureBox chiếm toàn bộ Form
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage; // Điều chỉnh hình ảnh cho vừa với PictureBox
            }
        }

        // Sự kiện load của Form2
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e); // Gọi phương thức OnLoad của lớp cha
            server = new TcpListener(IPAddress.Any, port); // Khởi tạo TcpListener với bất kỳ địa chỉ IP nào và cổng đã cung cấp
            DangKetNoi.Start(); // Bắt đầu luồng lắng nghe kết nối
        }

        // Sự kiện đóng của Form2
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e); // Gọi phương thức OnFormClosing của lớp cha
            DungKetNoi(); // Dừng kết nối khi Form bị đóng
        }
    }
}
