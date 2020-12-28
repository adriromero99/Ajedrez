using System;
using System.Collections.Generic;
using System.Text;

public abstract class TipoPieza {

	public abstract string obtenerRutaImagen();
	public abstract bool esValidaLaNuevaPosicion(Pieza pieza, Posicion nuevaPosicion, Tablero tablero);

}
