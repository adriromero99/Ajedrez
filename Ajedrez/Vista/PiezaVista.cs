using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;


public class PiezaVista {

    private PictureBox piezaBox;
    private Pieza pieza;
    private ManejadorDeClicks manejadorDeClicks;

    public PiezaVista(Pieza pieza) {
        this.pieza = pieza;
        piezaBox = new PictureBox();
        piezaBox.Image = Image.FromFile(pieza.obtenerRutaImagen()); 
        piezaBox.SizeMode = PictureBoxSizeMode.StretchImage;
        piezaBox.Visible = true;
        piezaBox.Width = 90;
        piezaBox.Height = 90;        
        piezaBox.BackColor = Color.Transparent;
        piezaBox.MouseClick += PiezaBox_MouseClick;
        piezaBox.Paint += PiezaBox_Paint;

        piezaBox.Tag = Color.Transparent;
        this.actualizar(new Posicion(pieza.obtenerX(), pieza.obtenerY()));
    }

    private void PiezaBox_Paint(object sender, PaintEventArgs e) {
        ControlPaint.DrawBorder(e.Graphics, piezaBox.ClientRectangle, (Color)piezaBox.Tag, ButtonBorderStyle.Solid);
    }

    public void finalizar() {
        desresaltarPiezaBox();
        piezaBox.SendToBack();
        piezaBox.Image = null;
    }

    private void PiezaBox_MouseClick(object sender, MouseEventArgs e) {
        Posicion posicionClickeada = new Posicion(pieza.obtenerX(), pieza.obtenerY());
        manejadorDeClicks.manejar(posicionClickeada, this);

    }

    public void resaltarPiezaBox() {
        if (piezaBox.Image != null && pieza.obtenerColor() != "") {
            piezaBox.Tag = Color.Black;
            piezaBox.Refresh();
        }
    }

    public void desresaltarPiezaBox() {
        piezaBox.Tag = Color.Transparent;
        piezaBox.Refresh();
    }
    public void inicializarVista(TableroVista tableroVista, ManejadorDeClicks manejadorDeClicks) {
        this.manejadorDeClicks = manejadorDeClicks;
        tableroVista.agregarPiezaBox(piezaBox);
    }

    public void actualizar(Posicion posicion) {
        piezaBox.Location = new Point(posicion.obtenerX() * 90, 630 - posicion.obtenerY() * 90);
    }

    public void serNulo() {
        piezaBox.Image = Image.FromFile(pieza.obtenerRutaImagen());
    }


}

