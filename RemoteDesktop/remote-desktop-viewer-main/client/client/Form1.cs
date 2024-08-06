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
using System.Drawing.Imaging;
using System.Runtime.Serialization.Formatters.Binary;

namespace client
{
    public partial class Form1 : Form
    {
        private readonly TcpClient client = new TcpClient();
        private NetworkStream manHinh;
        private int port;

        private static Image LayManHinhDesktop()
        {
            Rectangle kichThuocManHinh = Screen.PrimaryScreen.Bounds;
            Bitmap chupManHinh = new Bitmap(kichThuocManHinh.Width, kichThuocManHinh.Height, PixelFormat.Format32bppArgb);
            Graphics doHoa = Graphics.FromImage(chupManHinh);
            doHoa.CopyFromScreen(kichThuocManHinh.X, kichThuocManHinh.Y, 0, 0, kichThuocManHinh.Size, CopyPixelOperation.SourceCopy);

            return chupManHinh;
        }

        private void GuiAnhManHinh()
        {
            BinaryFormatter binFormatter = new BinaryFormatter();
            manHinh = client.GetStream();
            binFormatter.Serialize(manHinh, LayManHinhDesktop());
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            btnChiaSe.Enabled = false;
        }

        private void btnKetNoi_Click(object sender, EventArgs e)
        {
            port = int.Parse(txtPort.Text);
            try
            {
                client.Connect(txtIP.Text, port);
                btnKetNoi.Text = "Đã kết nối";
                MessageBox.Show("Đã kết nối thành công");
                btnKetNoi.Enabled = false;
                btnChiaSe.Enabled = true;
            }
            catch (Exception)
            {
                MessageBox.Show("Không thể kết nối..");
                btnKetNoi.Text = "Không kết nối";
            }
        }

        private void btnChiaSe_Click(object sender, EventArgs e)
        {
            if (btnChiaSe.Text.StartsWith("Chia sẻ"))
            {
                timer1.Start();
                btnChiaSe.Text = "Dừng chia sẻ";
            }
            else
            {
                timer1.Stop();
                btnChiaSe.Text = "Chia sẻ màn hình của tôi";
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            GuiAnhManHinh();
        }
    }
}
