using System;
using System.Drawing;


class PiezaNula : TipoPieza {
    public override bool esValidaLaNuevaPosicion(Pieza pieza, Posicion nuevaPosicion, Tablero tablero) {
        return false;
    }

	public override Bitmap obtenerImagen(Pieza pieza) {
		return new Bitmap(Ajedrez.Properties.Resources.piezaNula);
	}
}

