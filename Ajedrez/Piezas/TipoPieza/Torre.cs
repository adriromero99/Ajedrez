using System;
using System.Drawing;

public class Torre : TipoPieza{
	public override bool esValidaLaNuevaPosicion(Pieza pieza, Posicion nuevaPosicion, Tablero tablero) {
		bool esValidaLaNuevaPosicion = false;
		bool lasPosicionesXSonIguales = pieza.obtenerX() == nuevaPosicion.obtenerX();
		bool lasPosicionesYSonIguales = pieza.obtenerY() == nuevaPosicion.obtenerY();


		if (lasPosicionesXSonIguales && !lasPosicionesYSonIguales) {
			esValidaLaNuevaPosicion = !hayPiezasBloqueandoElCaminoVertical(pieza, nuevaPosicion, tablero) ;
		} else if (!lasPosicionesXSonIguales && lasPosicionesYSonIguales) {
			esValidaLaNuevaPosicion = !hayPiezasBloqueandoElCaminoHorizontal(pieza, nuevaPosicion, tablero);
		}

		return esValidaLaNuevaPosicion ;
	}

	public bool hayPiezasBloqueandoElCaminoHorizontal(Pieza pieza, Posicion nuevaPosicion, Tablero tablero) {
		bool seEncontroUnaPiezaEnElCamino = false;
		bool laPiezaEnLaNuevaPosicionEsDelMismoColor = false;
		int i = pieza.obtenerX();

		while (i != nuevaPosicion.obtenerX() && !seEncontroUnaPiezaEnElCamino) {

			if (i != pieza.obtenerX() && tablero.piezaEn(new Posicion(i, pieza.obtenerY())).obtenerColor() != "") {
				seEncontroUnaPiezaEnElCamino = true;
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

	public bool hayPiezasBloqueandoElCaminoVertical(Pieza pieza, Posicion nuevaPosicion, Tablero tablero) {
		
		bool seEncontroUnaPiezaEnElCamino = false;
		bool laPiezaEnLaNuevaPosicionEsDelMismoColor = false;
		int i = pieza.obtenerY();

		while (i != nuevaPosicion.obtenerY() && !seEncontroUnaPiezaEnElCamino) {

			if (i != pieza.obtenerY() && tablero.piezaEn(new Posicion(pieza.obtenerX(), i)).obtenerColor() != "") {
				seEncontroUnaPiezaEnElCamino = true;
			}

			if (i < nuevaPosicion.obtenerY()) {
				i++;
			} else if (i > nuevaPosicion.obtenerY()) {
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
			return new Bitmap(Ajedrez.Properties.Resources.torreBlanco);
		} 
		return new Bitmap(Ajedrez.Properties.Resources.torreNegro);
	}

}
