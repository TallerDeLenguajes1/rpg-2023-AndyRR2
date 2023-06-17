namespace EspacioPantallas;
using System;
using EspacioPersonaje;
using EspacioEnemigos;

public class Pantallas{
    public void MostrarDatosPj(Personaje pj){
        string caption="";    
        switch (pj.Tipo)
        {
            case "Guerrero":
                caption = @"        
                \  @
                 \/█|▒▒|
                 _/ \_";
                break;
            case "Mago":
                caption = @"       
                     ▄
                 \Ô__|
                 /▓\ |
                 ! !";
                break;
            case "Asesino":
                caption = @"    
                   Ø/\,
                 \/║
                 _/ \_";
                break;
        }
        Console.WriteLine(" ╔══════════════════════════════════════╗");
        Console.WriteLine(" ║ Nombre: " + pj.Nombre.PadRight(10) + " Apodo: " + pj.Apodo.PadRight(10) + " ║");
        Console.WriteLine(" ║ Nacimiento: " + pj.Fechanac.ToString("dd/MM/yyyy") + "   Edad: " + pj.Edad.ToString().PadRight(5) + " ║");
        Console.WriteLine(" ║                                      ║");
        Console.WriteLine("   " + caption + "                    ");
        Console.WriteLine(" ║                                      ║");
        Console.WriteLine(" ║ Clase: " + pj.Tipo.PadRight(10) + "  Nivel: " + pj.Nivel.ToString().PadRight(10) + " ║");
        Console.WriteLine(" ║ Fuerza: " + pj.Fuerza.ToString().PadRight(10) + " Salud: " + pj.Salud.ToString().PadRight(10) + " ║");
        Console.WriteLine(" ║ Destreza: " + pj.Destreza.ToString().PadRight(7) + "  Mana: " + pj.Mana.ToString().PadRight(10) + "  ║");
        Console.WriteLine(" ║ Inteligencia: " + pj.Inteligencia.ToString().PadRight(5) + "Ataque: " + pj.Ataque.ToString().PadRight(8) + "  ║");
        Console.WriteLine(" ║                    Defensa: " + pj.Defensa.ToString().PadRight(8) + " ║");
        Console.WriteLine(" ╚══════════════════════════════════════╝");
    }
    public void MostrarEnemigo(Enemigos Enem){
        Console.WriteLine("Enemigo: " + Enem.Nombre);
        Console.WriteLine("Tipo: " + Enem.Tipo);
        Console.WriteLine("Salud: " + Enem.Salud);
        Console.WriteLine("Ataque: " + Enem.Ataque);
        Console.WriteLine("Defensa: " + Enem.Defensa + "\n");
    }
}