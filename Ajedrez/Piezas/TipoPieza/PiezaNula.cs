using System;
using System.Collections.Generic;
using System.Text;


class PiezaNula : TipoPieza {
    public override bool esValidaLaNuevaPosicion(Pieza pieza, Posicion nuevaPosicion, Tablero tablero) {
        return false;
    }

    public override string obtenerRutaImagen() {
        return @"C:\Users\Adrian\source\repos\Ajedrez\Ajedrez\Imagenes\piezaNula";
    }
}

