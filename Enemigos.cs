namespace EspacioEnemigos;
using System;


public class Enemigos{
    private string tipo;
    private string nombre;
    private int nivel=1;
    private int defensa=100;
    private int ataque=100;
    private int salud=1000;
    
    public string Tipo { get => tipo; set => tipo = value; }
    public string Nombre { get => nombre; set => nombre = value; }
    public int Nivel { get => nivel; set => nivel = value; }
    public int Defensa { get => defensa; set => defensa = value; }
    public int Ataque { get => ataque; set => ataque = value; }
    public int Salud { get => salud; set => salud = value; }
}

