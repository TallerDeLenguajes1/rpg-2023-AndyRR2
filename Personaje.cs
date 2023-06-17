namespace EspacioPersonaje;
using System;

public class Personaje{
    private string tipo;
    private string nombre;
    private string apodo;
    private DateTime fechanac;
    private int edad;
    private int inteligencia;
    private int destreza;
    private int fuerza;
    private int nivel=1;
    private int defensa=100;
    private int ataque=100;
    private int salud=1000;
    private int mana=300;
    
    public string Tipo { get => tipo; set => tipo = value; }
    public string Nombre { get => nombre; set => nombre = value; }
    public string Apodo { get => apodo; set => apodo = value; }
    public DateTime Fechanac { get => fechanac; set => fechanac = value; }
    public int Edad { get => edad; set => edad = value; }
    public int Inteligencia { get => inteligencia; set => inteligencia = value; }
    public int Destreza { get => destreza; set => destreza = value; }
    public int Fuerza { get => fuerza; set => fuerza = value; }
    public int Nivel { get => nivel; set => nivel = value; }
    public int Defensa { get => defensa; set => defensa = value; }
    public int Ataque { get => ataque; set => ataque = value; }
    public int Salud { get => salud; set => salud = value; }
    public int Mana { get => mana; set => mana = value; }

}
