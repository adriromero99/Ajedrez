using System;
using System.Drawing;

public class Alfil : TipoPieza{
	public override bool esValidaLaNuevaPosicion(Pieza pieza, Posicion nuevaPosicion, Tablero tablero) {

		bool esValidaLaNuevaPosicion = false;
		bool esUnMovimientoValido = Math.Abs(nuevaPosicion.obtenerX() - pieza.obtenerX()) == Math.Abs(nuevaPosicion.obtenerY() - pieza.obtenerY()) && nuevaPosicion.obtenerX() != pieza.obtenerX();

		if (esUnMovimientoValido) {
			esValidaLaNuevaPosicion = !hayPiezasBloqueandoElCamino(pieza, nuevaPosicion, tablero);
		}

		return esValidaLaNuevaPosicion;
	}
	
	public bool hayPiezasBloqueandoElCamino(Pieza pieza, Posicion nuevaPosicion, Tablero tablero) {

		bool seEncontroUnaPiezaEnElCamino = false;
		bool laPiezaEnLaNuevaPosicionEsDelMismoColor = false;
		int i = pieza.obtenerX();
		int j = pieza.obtenerY();

		while (i != nuevaPosicion.obtenerX() && j!=nuevaPosicion.obtenerY() &&!seEncontroUnaPiezaEnElCamino) {

			if (i != pieza.obtenerX() && j != pieza.obtenerY() && tablero.piezaEn(new Posicion(i, j)).obtenerColor() != "") {
				seEncontroUnaPiezaEnElCamino = true;
			}

			if(j < nuevaPosicion.obtenerY()) {
				j++;
			} else if (j > nuevaPosicion.obtenerY()) {
				j--;
			}

			if (i < nuevaPosicion.obtenerX()) {
				i++;
			} else if (i > nuevaPosicion.obtenerX()) {
				i--;
			}

		}

		if (pieza.obtenerColor() == tablero.piezaEn(nuevaPosicion).obtenerColor()) {
			laPiezaEnLaNuevaPosicionEsDelMismoColor = true;
		}

		return seEncontroUnaPiezaEnElCamino || laPiezaEnLaNuevaPosicionEsDelMismoColor;
	}

	public override Bitmap obtenerImagen(Pieza pieza) {
		if (pieza.obtenerColor() == "Blanco") {
			return new Bitmap(Ajedrez.Properties.Resources.alfilBlanco);
		}
		return new Bitmap(Ajedrez.Properties.Resources.alfilNegro);
	}


}

