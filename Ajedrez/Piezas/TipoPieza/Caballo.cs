using System;
using System.Drawing;


public class Caballo : TipoPieza {
 
    public override bool esValidaLaNuevaPosicion(Pieza pieza, Posicion nuevaPosicion, Tablero tablero){
        bool esUnMovimientoValido = false;

        if (nuevaPosicion.obtenerX() == pieza.obtenerX() + 1 &&
            (nuevaPosicion.obtenerY() == pieza.obtenerY() + 2 || nuevaPosicion.obtenerY() == pieza.obtenerY() - 2)) {
            esUnMovimientoValido = true;
        } else if (nuevaPosicion.obtenerX() == pieza.obtenerX() - 1 &&
            (nuevaPosicion.obtenerY() == pieza.obtenerY() + 2 || nuevaPosicion.obtenerY() == pieza.obtenerY() - 2)) {
            esUnMovimientoValido = true;
        } else if (nuevaPosicion.obtenerX() == pieza.obtenerX() + 2 &&
            (nuevaPosicion.obtenerY() == pieza.obtenerY() + 1 || nuevaPosicion.obtenerY() == pieza.obtenerY() - 1)) {
            esUnMovimientoValido = true;
        } else if (nuevaPosicion.obtenerX() == pieza.obtenerX() - 2 &&
            (nuevaPosicion.obtenerY() == pieza.obtenerY() + 1 || nuevaPosicion.obtenerY() == pieza.obtenerY() - 1)) {
            esUnMovimientoValido = true;
        }

        return esUnMovimientoValido && (pieza.obtenerColor() != tablero.piezaEn(nuevaPosicion).obtenerColor());
    }

    public override Bitmap obtenerImagen(Pieza pieza) {
        if (pieza.obtenerColor() == "Blanco") {
            return new Bitmap(Ajedrez.Properties.Resources.caballoBlanco);
        }
        return new Bitmap(Ajedrez.Properties.Resources.caballoNegro);
    }

}

