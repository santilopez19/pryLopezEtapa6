using pryLopezEtapa3;

namespace pryLopezEtapa5
{
    public partial class frmVahiculos : Form
    {
        private List<clsVehiculo> vehiculos; // Lista para almacenar los vehículos

        public frmVahiculos()
        {
            vehiculos = new List<clsVehiculo>();

            InitializeComponent();
        }
        private void MostrarVehiculo(clsVehiculo vehiculo)
        {
            // Generar una posición aleatoria dentro del formulario
            Random rnd = new Random();
            int x = rnd.Next(0, this.ClientSize.Width - 40); // Restamos 40 para que la imagen no se salga del formulario
            int y = rnd.Next(0, this.ClientSize.Height - 50); // Restamos 50 para que la imagen no se salga del formulario

            // Crear una nueva imagen con el tamaño especificado
            Bitmap resizedImage = new Bitmap(40, 50);
            using (Graphics g = Graphics.FromImage(resizedImage))
            {
                g.DrawImage(vehiculo.Imagen, new Rectangle(0, 0, 40, 50));
            }

            // Mostrar la imagen en el formulario en la posición aleatoria
            PictureBox pictureBox = new PictureBox();
            pictureBox.Location = new Point(x, y);
            pictureBox.Size = new Size(80, 90);
            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox.Image = resizedImage;
            this.Controls.Add(pictureBox);

            // Agregar el vehículo a la lista
            vehiculos.Add(vehiculo);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Crea un nuevo objeto clsVehiculo y muestra la imagen
            clsVehiculo avion = new clsVehiculo("Avion", "Avion", Properties.Resources.avion);
            MostrarVehiculo(avion);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Crea un nuevo objeto clsVehiculo y muestra la imagen
            clsVehiculo auto = new clsVehiculo("Auto", "Auto", Properties.Resources.auto);
            MostrarVehiculo(auto);
        }

        private void button3_Click(object sender, EventArgs e)
        {

            // Crea un nuevo objeto clsVehiculo y muestra la imagen
            clsVehiculo barco = new clsVehiculo("Barco", "Barco", Properties.Resources.barco);
            MostrarVehiculo(barco);
        }
    }
}
