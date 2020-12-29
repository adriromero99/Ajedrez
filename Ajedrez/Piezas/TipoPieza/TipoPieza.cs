using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

public abstract class TipoPieza {

	public abstract Bitmap obtenerImagen(Pieza pieza);
	public abstract bool esValidaLaNuevaPosicion(Pieza pieza, Posicion nuevaPosicion, Tablero tablero);

	public virtual void actualizar(Pieza pieza, Tablero tablero) {
		return;
	}

}
