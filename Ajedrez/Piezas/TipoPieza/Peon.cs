using System;
using System.Drawing;


public class Peon : TipoPieza {
    public override bool esValidaLaNuevaPosicion(Pieza pieza, Posicion nuevaPosicion, Tablero tablero) {

        bool esYValido = false;
        bool esXValido = false;
        string colorPiezaEnNuevaPosicion = tablero.piezaEn(nuevaPosicion).obtenerColor();

        if(pieza.obtenerColor() == "Blanco") {
            if (nuevaPosicion.obtenerY() == pieza.obtenerY() + 1 ) {
                esYValido = true;
            } 
            if ((nuevaPosicion.obtenerX() == pieza.obtenerX() && colorPiezaEnNuevaPosicion == "")|| (colorPiezaEnNuevaPosicion == "Negro" && Math.Abs(nuevaPosicion.obtenerX() - pieza.obtenerX())==1 )) {
                esXValido = true;
            }
            if (nuevaPosicion.obtenerX() == pieza.obtenerX() && nuevaPosicion.obtenerY() == pieza.obtenerY() + 2 && pieza.obtenerY() == 1 && tablero.piezaEn(new Posicion(pieza.obtenerX(), 2)).obtenerColor() == "") {
                esYValido = true;
                esXValido = true;
            }
        } else if(pieza.obtenerColor() == "Negro") {
            if (nuevaPosicion.obtenerY() == pieza.obtenerY() - 1 ){
                esYValido = true;
            }
            if((nuevaPosicion.obtenerX() == pieza.obtenerX() && colorPiezaEnNuevaPosicion == "") || (colorPiezaEnNuevaPosicion == "Blanco" && Math.Abs(nuevaPosicion.obtenerX() - pieza.obtenerX()) == 1)) { 
                esXValido = true;
            }
            if (nuevaPosicion.obtenerX() == pieza.obtenerX() && nuevaPosicion.obtenerY() == pieza.obtenerY() - 2 && pieza.obtenerY() == 6 && tablero.piezaEn(new Posicion(pieza.obtenerX(), 5)).obtenerColor() == "") {
                esYValido = true;
                esXValido = true;
            }
        }

        return esXValido && esYValido && (pieza.obtenerColor() != tablero.piezaEn(nuevaPosicion).obtenerColor());
    }

    public override Bitmap obtenerImagen(Pieza pieza) {
        if (pieza.obtenerColor() == "Blanco") {
            return new Bitmap(Ajedrez.Properties.Resources.peonBlanco);
        }
        return new Bitmap(Ajedrez.Properties.Resources.peonNegro);
    }

    public override void actualizar(Pieza pieza, Tablero tablero) {
        if (pieza.obtenerY() == 0 || pieza.obtenerY() == 7) {
            tablero.coronar(pieza);
        }
    }

}

