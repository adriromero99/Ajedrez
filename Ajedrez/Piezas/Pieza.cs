using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;


public class Pieza {

	private string color;
	private TipoPieza tipoPieza;
	private Posicion posicion;
	private PiezaVista piezaVista;
	private bool estaEnPosicionInicial;

	public Pieza(TipoPieza tipoPieza, string color, Posicion posicionInicial) {
		this.tipoPieza = tipoPieza;
		this.posicion = posicionInicial;
		this.color = color;
		this.piezaVista = new PiezaVista(this);
		this.estaEnPosicionInicial = true;
	}

	public void inicializarVista(TableroVista tableroVista, ManejadorDeClicks manejadorDeClicks) {
		piezaVista.inicializarVista(tableroVista, manejadorDeClicks);
	}

	public bool seMovio() {
		return !estaEnPosicionInicial;
	}

	public Bitmap obtenerImagen(){
		return this.tipoPieza.obtenerImagen(this); 
	}

	public bool mover(Posicion nuevaPosicion, Tablero tablero) {
		bool sePuedeMover = tipoPieza.esValidaLaNuevaPosicion(this, nuevaPosicion, tablero);
		bool seEfectuoElMovimiento = false;

		if (sePuedeMover && tablero.turnero.esElTurnoCorrespondiente(color)) {
			efectuarMovimiento(nuevaPosicion, tablero);
			seEfectuoElMovimiento = true;
		}

		return seEfectuoElMovimiento;
	}

	public void efectuarMovimiento(Posicion nuevaPosicion, Tablero tablero) {
		//TAL VEZ TODAS LAS COSAS QUE LLAMO ACA DEL TABLERO LAS PUEDO PONER EN UNA FC DEL TABLERO
		tablero.removerPieza(this);
		tablero.piezaEn(nuevaPosicion).finalizarVista(); //Tal vez deberia estar en remover pieza
		posicion = nuevaPosicion;
		tablero.ubicarPieza(this);
		piezaVista.actualizar(posicion);
		tablero.turnero.actualizarTurno();
		estaEnPosicionInicial = false;
	}
	public void finalizarVista() {
		this.piezaVista.finalizar();
	}

	public string obtenerColor() {
		return this.color;
	}

	public int obtenerX() {
		return this.posicion.obtenerX();
	}

	public int obtenerY() {
		return this.posicion.obtenerY();
	}

	public void actualizar(Tablero tablero) {
		this.tipoPieza.actualizar(this, tablero);	
	}

	public void coronar(TipoPieza tipoPieza) {
		this.tipoPieza = tipoPieza;
		this.piezaVista.coronar();
    }



}

