using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;

namespace client
{
    public partial class Form1 : Form
    {
        // TcpClient dùng để tạo kết nối TCP với server
        private readonly TcpClient client = new TcpClient();
        // NetworkStream là luồng dữ liệu được sử dụng để truyền tải hình ảnh qua mạng
        private NetworkStream manHinh;
        // Port để kết nối đến server
        private int port;

        // Hàm lấy toàn bộ màn hình desktop hiện tại dưới dạng hình ảnh
        private static Image LayManHinhDesktop()
        {
            // Lấy kích thước màn hình chính
            Rectangle kichThuocManHinh = Screen.PrimaryScreen.Bounds;
            // Tạo một bitmap có kích thước tương ứng với màn hình
            Bitmap chupManHinh = new Bitmap(kichThuocManHinh.Width, kichThuocManHinh.Height, PixelFormat.Format32bppArgb);
            // Sử dụng Graphics để vẽ màn hình hiện tại lên bitmap
            using (Graphics doHoa = Graphics.FromImage(chupManHinh))
            {
                doHoa.CopyFromScreen(kichThuocManHinh.X, kichThuocManHinh.Y, 0, 0, kichThuocManHinh.Size, CopyPixelOperation.SourceCopy);
            }
            return chupManHinh; // Trả về bitmap chứa hình ảnh màn hình
        }

        // Hàm gửi màn hình hiện tại tới server
        private void GuiManHinh()
        {
            // BinaryFormatter dùng để tuần tự hóa đối tượng hình ảnh
            BinaryFormatter binFormatter = new BinaryFormatter();
            // Lấy luồng dữ liệu để gửi màn hình
            manHinh = client.GetStream();
            // Tuần tự hóa đối tượng hình ảnh và gửi qua luồng mạng
            binFormatter.Serialize(manHinh, LayManHinhDesktop());
        }

        // Constructor mặc định của Form
        public Form1()
        {
            InitializeComponent(); // Hàm khởi tạo giao diện của Form
        }

        // Sự kiện load của Form1
        private void Form1_Load(object sender, EventArgs e)
        {
            // Khi Form mới load, nút chia sẻ màn hình bị vô hiệu hóa
            btnChiaSe.Enabled = false;
        }

        // Sự kiện khi nhấn nút "Kết nối"
        private void btnKetNoi_Click(object sender, EventArgs e)
        {
            // Lấy số cổng từ textbox và ép kiểu sang int
            port = int.Parse(txtPort.Text);
            try
            {
                // Kết nối tới server với địa chỉ IP và cổng đã nhập
                client.Connect(txtIP.Text, port);
                // Thay đổi trạng thái nút và thông báo đã kết nối thành công
                btnKetNoi.Text = "Đã kết nối";
                MessageBox.Show("Đã kết nối thành công");
                // Vô hiệu hóa nút "Kết nối" và kích hoạt nút "Chia sẻ"
                btnKetNoi.Enabled = false;
                btnChiaSe.Enabled = true;
            }
            catch (Exception)
            {
                // Nếu có lỗi khi kết nối, hiển thị thông báo lỗi
                MessageBox.Show("Không thể kết nối..");
                btnKetNoi.Text = "Không kết nối";
            }
        }

        // Sự kiện khi nhấn nút "Chia sẻ"
        private void btnChiaSe_Click(object sender, EventArgs e)
        {
            if (btnChiaSe.Text.StartsWith("Chia sẻ"))
            {
                // Nếu đang ở trạng thái chưa chia sẻ, bắt đầu chia sẻ màn hình và khởi động timer
                timer1.Start();
                btnChiaSe.Text = "Dừng chia sẻ";
            }
            else
            {
                // Nếu đang ở trạng thái chia sẻ, dừng chia sẻ và dừng timer
                timer1.Stop();
                btnChiaSe.Text = "Chia sẻ màn hình của tôi";
            }
        }

        // Sự kiện tick của timer, gọi hàm GuiManHinh mỗi khi timer tick (theo chu kỳ đặt trước)
        private void timer1_Tick(object sender, EventArgs e)
        {
            GuiManHinh(); // Gửi màn hình tới server
        }
    }
}
