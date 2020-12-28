using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

public class Tablero {


    private const int TAMANIO_TABLERO = 8;
    private Casillero[,] casillas = new Casillero[TAMANIO_TABLERO, TAMANIO_TABLERO];
    private TableroVista tableroVista;
    private List<Pieza> piezas = new List<Pieza>();
    public Turnero turnero = new Turnero();

    public Tablero() {
        for (int i = 0; i < TAMANIO_TABLERO; i++) {
            for (int j = 0; j < TAMANIO_TABLERO; j++) {
                casillas[i, j] = new Casillero();
            }       
        }
    }

    public void incializarVista(Form ajedrezWindow) {
        ajedrezWindow.Controls.Add(tableroVista.obtenerBox());
    }

    public void ubicarPieza(Pieza pieza) {
        this.casillas[pieza.obtenerX(), pieza.obtenerY()].ubicarPieza(pieza);
    }

    public bool moverPieza(Posicion posicion, Posicion posicionNueva) {
        return this.casillas[posicion.obtenerX(), posicion.obtenerY()].moverPieza(posicionNueva, this);
    }

    public void removerPieza(Pieza pieza) {
        this.casillas[pieza.obtenerX(), pieza.obtenerY()].vaciar();
    }

    public Pieza piezaEn(Posicion posicion) {
        Pieza pieza = casillas[posicion.obtenerX(), posicion.obtenerY()].obtenerPieza();
        return pieza;
    }


    public void inicializarTablero() {
        piezas.Add(new Pieza(new Torre(), "Blanco", new Posicion(0, 0)));
        piezas.Add(new Pieza(new Caballo(), "Blanco", new Posicion(1, 0)));
        piezas.Add(new Pieza(new Alfil(), "Blanco", new Posicion(2, 0)));
        piezas.Add(new Pieza(new Reina(), "Blanco", new Posicion(3, 0)));
        piezas.Add(new Pieza(new Rey(), "Blanco", new Posicion(4, 0)));
        piezas.Add(new Pieza(new Alfil(), "Blanco", new Posicion(5, 0)));
        piezas.Add(new Pieza(new Caballo(), "Blanco", new Posicion(6, 0)));
        piezas.Add(new Pieza(new Torre(), "Blanco", new Posicion(7, 0)));

        piezas.Add(new Pieza(new Torre(), "Negro", new Posicion(0, 7)));
        piezas.Add(new Pieza(new Caballo(), "Negro", new Posicion(1, 7)));
        piezas.Add(new Pieza(new Alfil(), "Negro", new Posicion(2, 7)));
        piezas.Add(new Pieza(new Reina(), "Negro", new Posicion(3, 7)));
        piezas.Add(new Pieza(new Rey(), "Negro", new Posicion(4, 7)));
        piezas.Add(new Pieza(new Alfil(), "Negro", new Posicion(5, 7)));
        piezas.Add(new Pieza(new Caballo(), "Negro", new Posicion(6, 7)));
        piezas.Add(new Pieza(new Torre(), "Negro", new Posicion(7, 7)));

        for (int i = 0; i < 8; i++) {
            piezas.Add(new Pieza(new Peon(), "Blanco", new Posicion(i, 1)));
            piezas.Add(new Pieza(new Peon(), "Negro", new Posicion(i, 6)));
        }

        for (int i = 0; i < 8; i++) {
            for (int j = 2; j < 6; j++) {
                piezas.Add(new Pieza(new PiezaNula(), "", new Posicion(i, j)));
            }
        }

        ManejadorDeClicks manejadorDeClicks = new ManejadorDeClicks(this);
        this.tableroVista = new TableroVista(manejadorDeClicks);

        foreach (Pieza pieza in piezas) {
            ubicarPieza(pieza);
            pieza.inicializarVista(tableroVista, manejadorDeClicks);
        }
    }

}

public class Casillero {

    private Pieza pieza;

    public Casillero() {
       
    }

    public Pieza obtenerPieza() { 
        return this.pieza;
    }
    public void ubicarPieza(Pieza pieza) {
        this.pieza = pieza;
    }

    public void vaciar() {
        this.pieza = new Pieza(new PiezaNula(), "", new Posicion(pieza.obtenerX(), pieza.obtenerY()));
    }

    public bool moverPieza(Posicion posicionNueva, Tablero tablero) {
        return pieza.mover(posicionNueva, tablero);
    }

}
