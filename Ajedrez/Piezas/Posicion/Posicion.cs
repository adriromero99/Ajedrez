using System;
using System.Collections.Generic;
using System.Text;

public class Posicion {
	private int x;
	private int y;

	public Posicion(int x, int y) {
		this.x = x;
		this.y = y;
	}

	public int obtenerX() {
		return this.x;
	}

	public int obtenerY() {
		return this.y;
	}
}
