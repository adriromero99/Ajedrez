using System;
using System.Drawing;


public class Rey : TipoPieza{
    public override bool esValidaLaNuevaPosicion(Pieza pieza, Posicion nuevaPosicion, Tablero tablero) {

        bool esValidaLaNuevaPosicion = false;
        Pieza torreDerecha;
        Pieza torreIzquierda;

        if (pieza.obtenerColor() == "Blanco") {
            torreDerecha = tablero.piezaEn(new Posicion(7, 0));
            torreIzquierda = tablero.piezaEn(new Posicion(0, 0));
        } else {
            torreDerecha = tablero.piezaEn(new Posicion(7, 7));
            torreIzquierda = tablero.piezaEn(new Posicion(0, 7));
        }

        if (Math.Abs(pieza.obtenerX() - nuevaPosicion.obtenerX()) == 1 && Math.Abs(pieza.obtenerY() - nuevaPosicion.obtenerY()) <= 1) {
            esValidaLaNuevaPosicion = true;
        } else if (Math.Abs(pieza.obtenerX() - nuevaPosicion.obtenerX()) == 0 && Math.Abs(pieza.obtenerY() - nuevaPosicion.obtenerY()) == 1) {
            esValidaLaNuevaPosicion = true;
        } else if (!torreIzquierda.seMovio() && sePuedeEnrocarIzquierda(pieza.obtenerColor(), tablero) && quiereEnrocarIzquierda(pieza, nuevaPosicion)) {
            enrocarIzquierda(pieza, tablero, nuevaPosicion);
        } else if (!torreIzquierda.seMovio() && sePuedeEnrocarDerecha(pieza.obtenerColor(), tablero) && quiereEnrocarDerecha(pieza, nuevaPosicion)) {
            enrocarDerecha(pieza, tablero, nuevaPosicion);
        }

        return esValidaLaNuevaPosicion && (pieza.obtenerColor() != tablero.piezaEn(nuevaPosicion).obtenerColor());
    }

    bool sePuedeEnrocarIzquierda(string color, Tablero tablero) {
        bool sePuedeEnrocarIzquierda = true;
        if (color == "Blanco") {
            for (int i = 1; i <= 3; i++) {
                if (tablero.piezaEn(new Posicion(i,0)).obtenerColor() != "") {
                    sePuedeEnrocarIzquierda = false;
                }
            }
        } else if (color == "Negro") {
            for (int i = 1; i <= 3; i++) {
                if (tablero.piezaEn(new Posicion(i, 7)).obtenerColor() != "") {
                    sePuedeEnrocarIzquierda = false;
                }
            }
        }
        return sePuedeEnrocarIzquierda;
    }

    bool sePuedeEnrocarDerecha(string color, Tablero tablero) {
        bool sePuedeEnrocarDerecha = true;
        if (color == "Blanco") {
            for (int i = 5; i <= 6; i++) {
                if (tablero.piezaEn(new Posicion(i, 0)).obtenerColor() != "") {
                    sePuedeEnrocarDerecha = false;
                }
            }
        } else if (color == "Negro") {
            for (int i = 5; i <= 6; i++) {
                if (tablero.piezaEn(new Posicion(i, 7)).obtenerColor() != "") {
                    sePuedeEnrocarDerecha = false;
                }
            }
        }
        return sePuedeEnrocarDerecha;
    }

    public bool quiereEnrocarIzquierda(Pieza pieza, Posicion nuevaPosicion) {

        bool quiereEnrocar = false;

        if (!pieza.seMovio() && pieza.obtenerColor() == "Blanco" && nuevaPosicion.obtenerX() == 2 && nuevaPosicion.obtenerY() == 0) {
            quiereEnrocar = true;
        } else if (!pieza.seMovio() && pieza.obtenerColor() == "Negro" && nuevaPosicion.obtenerX() == 2 && nuevaPosicion.obtenerY() == 7) {
            quiereEnrocar = true;
        }

        return quiereEnrocar;
    }

    public bool quiereEnrocarDerecha(Pieza pieza, Posicion nuevaPosicion) {

        bool quiereEnrocar = false;

        if (!pieza.seMovio() && pieza.obtenerColor() == "Blanco" && nuevaPosicion.obtenerX() == 6 && nuevaPosicion.obtenerY() == 0) {
            quiereEnrocar = true;
        } else if (!pieza.seMovio() && pieza.obtenerColor() == "Negro" && nuevaPosicion.obtenerX() == 6 && nuevaPosicion.obtenerY() == 7) {
            quiereEnrocar = true;
        }

        return quiereEnrocar;
    }

    public void enrocarIzquierda(Pieza pieza, Tablero tablero, Posicion nuevaPosicion) {

        pieza.efectuarMovimiento(nuevaPosicion, tablero);
        Pieza torreIzquierda;

        if (pieza.obtenerColor() == "Negro") {
            torreIzquierda = tablero.piezaEn(new Posicion(0, 7));
            torreIzquierda.efectuarMovimiento(new Posicion(3, 7), tablero);
            tablero.turnero.actualizarTurno();
        } else if (pieza.obtenerColor() == "Blanco") {
            torreIzquierda = tablero.piezaEn(new Posicion(0, 0));
            torreIzquierda.efectuarMovimiento(new Posicion(3, 0), tablero);
            tablero.turnero.actualizarTurno();
        }

    }

    public void enrocarDerecha(Pieza pieza, Tablero tablero, Posicion nuevaPosicion) {

        pieza.efectuarMovimiento(nuevaPosicion, tablero);
        Pieza torreDerecha;

        if (pieza.obtenerColor() == "Negro") {
            torreDerecha = tablero.piezaEn(new Posicion(7, 7));
            torreDerecha.efectuarMovimiento(new Posicion(5, 7), tablero);
        } else if (pieza.obtenerColor() == "Blanco") {
            torreDerecha = tablero.piezaEn(new Posicion(7, 0));
            torreDerecha.efectuarMovimiento(new Posicion(5, 0), tablero);
        }

    }

    public override Bitmap obtenerImagen(Pieza pieza) {
        if (pieza.obtenerColor() == "Blanco") {
            return new Bitmap(Ajedrez.Properties.Resources.reyBlanco);
        }
        return new Bitmap(Ajedrez.Properties.Resources.reyNegro);
    }
}

