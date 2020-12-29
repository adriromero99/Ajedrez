using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Drawing;
public class ManejadorDeCoronacion {

    Form ajedrezWindow;
    Button botonCaballo;
    Button botonTorre;
    Button botonAlfil;
    Button botonReina;

    Pieza piezaACoronar;
    public ManejadorDeCoronacion(Form ajedrezWindow) {
        this.ajedrezWindow = ajedrezWindow;

        botonCaballo = new Button();
        botonCaballo.Visible = false;
        botonCaballo.Location = new Point(270, 250);
        botonCaballo.Size = new Size(100, 100);
        botonCaballo.Click += BotonCaballo_Click;
        botonCaballo.BackgroundImageLayout = ImageLayout.Stretch;

        botonTorre = new Button();
        botonTorre.Visible = false;
        botonTorre.Location = new Point(370, 250);
        botonTorre.Size = new Size(100, 100);
        botonTorre.Click += BotonTorre_Click;
        botonTorre.BackgroundImageLayout = ImageLayout.Stretch;

        botonAlfil = new Button();
        botonAlfil.Visible = false;
        botonAlfil.Location = new Point(370, 350);
        botonAlfil.Size = new Size(100, 100);
        botonAlfil.Click += BotonAlfil_Click;
        botonAlfil.BackgroundImageLayout = ImageLayout.Stretch;

        botonReina = new Button();
        botonReina.Visible = false;
        botonReina.Location = new Point(270, 350);
        botonReina.Size = new Size(100, 100);
        botonReina.Click += BotonReina_Click;
        botonReina.BackgroundImageLayout = ImageLayout.Stretch;

        ajedrezWindow.Controls.Add(botonCaballo);
        ajedrezWindow.Controls.Add(botonTorre);
        ajedrezWindow.Controls.Add(botonAlfil);
        ajedrezWindow.Controls.Add(botonReina);

        botonCaballo.BringToFront();
        botonTorre.BringToFront();
        botonAlfil.BringToFront();
        botonReina.BringToFront();

    }

    private void BotonReina_Click(object sender, EventArgs e) {
        piezaACoronar.coronar(new Reina());
        esconderBotones();
    }

    private void BotonAlfil_Click(object sender, EventArgs e) {
        piezaACoronar.coronar(new Alfil());
        esconderBotones();
    }

    private void BotonTorre_Click(object sender, EventArgs e) {
        piezaACoronar.coronar(new Torre());
        esconderBotones();
    }

    private void BotonCaballo_Click(object sender, EventArgs e) {
        piezaACoronar.coronar(new Caballo());
        esconderBotones();
    }

    public void coronar(Pieza piezaACoronar) {
        cargarImagenesDeBotones(piezaACoronar.obtenerColor());
        revelarBotones();
        this.piezaACoronar = piezaACoronar;
    }

    private void revelarBotones() {
        botonTorre.Visible = true;
        botonAlfil.Visible = true;
        botonCaballo.Visible = true;
        botonReina.Visible = true;
    }

    private void esconderBotones() {
        botonTorre.Visible = false;
        botonAlfil.Visible = false;
        botonCaballo.Visible = false;
        botonReina.Visible = false;
    }

    private void cargarImagenesDeBotones(string color) {

        botonTorre.BackgroundImage = Image.FromFile(@"C:\Users\Adrian\source\repos\Ajedrez\Ajedrez\Imagenes\torre"+color+".png");
        botonAlfil.BackgroundImage = Image.FromFile(@"C:\Users\Adrian\source\repos\Ajedrez\Ajedrez\Imagenes\alfil"+color+".png");
        botonCaballo.BackgroundImage = Image.FromFile(@"C:\Users\Adrian\source\repos\Ajedrez\Ajedrez\Imagenes\caballo"+color+".png");
        botonReina.BackgroundImage = Image.FromFile(@"C:\Users\Adrian\source\repos\Ajedrez\Ajedrez\Imagenes\reina"+color+".png");

    }

}