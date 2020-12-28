using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

public class TableroVista {

    private PictureBox tableroBox;
    ManejadorDeClicks manejadorDeClicks;

    public TableroVista(ManejadorDeClicks manejadorDeClicks) {
        this.manejadorDeClicks = manejadorDeClicks;
        tableroBox = new PictureBox();
        tableroBox.Image = Image.FromFile(@"C:\Users\Adrian\source\repos\Ajedrez\Ajedrez\Imagenes\tablero.png");
        tableroBox.SizeMode = PictureBoxSizeMode.StretchImage;
        tableroBox.Visible = true;
        tableroBox.Width = 90*8;
        tableroBox.Height = 90*8;
        tableroBox.Location = new Point(0, 0);
        tableroBox.MouseClick += TableroBox_MouseClick;
    }

    private void TableroBox_MouseClick(object sender, MouseEventArgs e) {
        manejadorDeClicks.manejar(new Posicion(obtenerXTablero(e.X), obtenerYTablero(e.Y)));
    }

    public void agregarPiezaBox(PictureBox piezaBox) {
        this.tableroBox.Controls.Add(piezaBox);
    }

    public PictureBox obtenerBox() {
        return this.tableroBox;
    }

    private int obtenerYTablero(int yMouse) {
        int yTablero = 7 - yMouse / 90;
        return yTablero;
    }

    private int obtenerXTablero(int xMouse) {
        int xTablero = xMouse / 90;
        return xTablero;
    }

}

