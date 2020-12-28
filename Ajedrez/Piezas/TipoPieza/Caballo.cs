using System;
using System.Collections.Generic;
using System.Text;


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

    public override string obtenerRutaImagen() {
        return @"C:\Users\Adrian\source\repos\Ajedrez\Ajedrez\Imagenes\caballo";
    }

}

