using System;
using System.Collections.Generic;
using System.Text;

public abstract class TipoPieza {

	public abstract string obtenerRutaImagen();
	public abstract bool esValidaLaNuevaPosicion(Pieza pieza, Posicion nuevaPosicion, Tablero tablero);

	public virtual void actualizar(Pieza pieza, Tablero tablero) {
		return;
	}

}
