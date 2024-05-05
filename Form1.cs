using pryLopezEtapa3;

namespace pryLopezEtapa5
{
    public partial class frmVahiculos : Form
    {
        private List<clsVehiculo> vehiculos; // Lista para almacenar los vehículos

        private int imagenesMostradas = 0;

        public frmVahiculos()
        {
            vehiculos = new List<clsVehiculo>();

            InitializeComponent();

            // Inicializar y configurar el temporizador
            Movimiento.Tick += MoverImagenes;
        }

        private void MoverImagenes(object sender, EventArgs e)
        {
            foreach (Control control in this.Controls)
            {
                if (control is PictureBox pictureBox)
                {
                    // Obtener la información de dirección y velocidad de la imagen
                    object[] movimientoInfo = (object[])pictureBox.Tag;
                    bool moviendoDerecha = (bool)movimientoInfo[0];
                    int velocidadMovimiento = (int)movimientoInfo[1];

                    // Mover la imagen en la dirección actual
                    if (moviendoDerecha)
                    {
                        pictureBox.Left += velocidadMovimiento;
                    }
                    else
                    {
                        pictureBox.Left -= velocidadMovimiento;
                    }

                    // Verificar si la imagen alcanzó el límite de la pantalla
                    if (pictureBox.Left <= 0 || pictureBox.Right >= this.ClientSize.Width)
                    {
                        // Cambiar la dirección de la imagen
                        moviendoDerecha = !moviendoDerecha;
                        pictureBox.Tag = new object[] { moviendoDerecha, velocidadMovimiento };
                    }
                }
            }
        }

        private void MostrarVehiculo(clsVehiculo vehiculo)
        {
            // Verificar si ya no hay espacio para mostrar más imágenes
            if (imagenesMostradas >= (this.ClientSize.Width * this.ClientSize.Height) / (80 * 100))
            {
                MessageBox.Show("Ya no hay espacio disponible para mostrar más imágenes.", "Sin espacio", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Generar una posición aleatoria dentro del formulario
            Random rnd = new Random();
            int x, y;

            do
            {
                x = rnd.Next(0, this.ClientSize.Width - 80); // Restamos 80 para que la imagen no se salga del formulario
                y = rnd.Next(0, this.ClientSize.Height - 100); // Restamos 100 para que la imagen no se salga del formulario
            } while (ExisteSuperposicion(x, y));

            // Crear una nueva imagen con el tamaño especificado
            Bitmap resizedImage = new Bitmap(80, 100);
            using (Graphics g = Graphics.FromImage(resizedImage))
            {
                g.DrawImage(vehiculo.Imagen, new Rectangle(0, 0, 80, 100));
            }

            // Mostrar la imagen en el formulario en la posición aleatoria
            PictureBox pictureBox = new PictureBox();
            pictureBox.Location = new Point(x, y);
            pictureBox.Size = new Size(80, 100);
            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox.Image = resizedImage;
            this.Controls.Add(pictureBox);

            // Asignar dirección aleatoria
            bool moviendoDerecha = rnd.Next(2) == 0; // True para derecha, False para izquierda
                                                     // Asignar velocidad aleatoria entre 1 y 10
            int velocidadMovimiento = rnd.Next(1, 11);

            pictureBox.Tag = new object[] { moviendoDerecha, velocidadMovimiento };

            // Agregar el vehículo a la lista
            vehiculos.Add(vehiculo);

            // Incrementar el contador de imágenes mostradas
            imagenesMostradas++;
        }

        private bool ExisteSuperposicion(int x, int y)
        {
            // Verificar si la posición (x, y) está ocupada por alguna imagen existente
            foreach (Control control in this.Controls)
            {
                if (control is PictureBox pictureBox)
                {
                    if (pictureBox.Bounds.IntersectsWith(new Rectangle(x, y, 80, 100)))
                    {
                        return true;
                    }
                }
            }
            return false;
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

        private void btnMover_Click(object sender, EventArgs e)
        {
            if (!Movimiento.Enabled)
            {
                Movimiento.Start();
            }
            else
            {
                Movimiento.Stop();
            }
        }
    }
}