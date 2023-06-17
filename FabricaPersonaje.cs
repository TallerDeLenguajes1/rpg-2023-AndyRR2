namespace EspacioFabricaPersonaje;
using System;
using EspacioPersonaje;
using EspacioEnemigos;
using EspacioConstantes;
public class FabricaPersonaje{
    public Personaje CrearPersonaje(Personaje PjPrincipal){
        string entrada="";
        bool result;
        DateTime fecha;
        int edad, clase;
        Console.WriteLine("\n                    +\"Dungeon Path\"+\n");
        Console.WriteLine("                   Seleccione su clase ");
        Console.WriteLine(@"          
           1-Guerrero   2-Mago       3-Asesino
          ╔══════════╗ ╔══════════╗ ╔══════════╗          
          ║ \  @     ║ ║       ▄  ║ ║    Ø/\,  ║
          ║  \/█|▒▒| ║ ║   \Ô__|  ║ ║  \/║     ║
          ║  _/ \_   ║ ║   /▓\ |  ║ ║  _/ \_   ║
          ║          ║ ║   ! !    ║ ║          ║
          ║ Fue: 30  ║ ║ Fue: 10  ║ ║ Fue: 10  ║
          ║ Dext: 20 ║ ║ Dext: 20 ║ ║ Dext: 30 ║
          ║ Int: 10  ║ ║ Int: 30  ║ ║ Int: 20  ║
          ╚══════════╝ ╚══════════╝ ╚══════════╝");
        entrada = Console.ReadLine();
        result = int.TryParse(entrada,out clase);
        Console.WriteLine("Entre nombre: ");
        entrada = Console.ReadLine();
        PjPrincipal.Nombre=entrada;
        Console.WriteLine("Entre apodo: ");
        entrada = Console.ReadLine();
        PjPrincipal.Apodo=entrada;
        Console.WriteLine("Entre la fecha de nacimiento (mes/dia/año): ");
        entrada = Console.ReadLine();
        result = DateTime.TryParse(entrada, out fecha);
        PjPrincipal.Fechanac=fecha;
        Console.WriteLine("Entre la edad: ");
        entrada = Console.ReadLine();
        result = int.TryParse(entrada,out edad);
        PjPrincipal.Edad=edad;
        switch (clase){
            case 1: PjPrincipal.Fuerza = 30;PjPrincipal.Destreza=20;PjPrincipal.Inteligencia=10;PjPrincipal.Tipo="Guerrero";break;
            case 2: PjPrincipal.Fuerza = 10;PjPrincipal.Destreza=20;PjPrincipal.Inteligencia=30;PjPrincipal.Tipo="Mago";break;
            case 3: PjPrincipal.Fuerza = 10;PjPrincipal.Destreza=30;PjPrincipal.Inteligencia=20;PjPrincipal.Tipo="Asesino";break;
        }
        return(PjPrincipal);
    }
    public Personaje ActualizarValores(Personaje pj){
        pj.Salud = pj.Salud + pj.Fuerza*10 + pj.Nivel*20;
        pj.Mana = pj.Mana + pj.Inteligencia*5 +pj.Nivel*10;
        pj.Ataque = pj.Ataque + pj.Destreza*5 + pj.Fuerza*3 + pj.Inteligencia*2 + pj.Nivel*2;
        pj.Defensa = pj.Defensa +pj.Fuerza*5 +pj.Destreza*2 + pj.Inteligencia + pj.Nivel*2;
        return(pj);
    }
    public Enemigos GenerarEnemigo(Enemigos Enem, int nivel){
        Constantes Const = new Constantes(); 
        Enem.Nombre = Const.nombres[Const.GeneraAleatorio(1,10)];
        Enem.Tipo = Const.monstruo[Const.GeneraAleatorio(1,3)];
        switch (Enem.Tipo){
            case "Dragon":
            Enem.Salud = 1000 + Enem.Nivel*100;
            Enem.Ataque = 100 + Enem.Nivel*10;
            Enem.Defensa = 100 + Enem.Nivel*5;
            break;
            case "No Muerto":
            Enem.Salud = 800 + Enem.Nivel*100;
            Enem.Ataque = 80 + Enem.Nivel*10;
            Enem.Defensa = 90 + Enem.Nivel*5;
            break;
            case "Demonio":
            Enem.Salud = 900 + Enem.Nivel*100;
            Enem.Ataque = 90 + Enem.Nivel*10;
            Enem.Defensa = 80 + Enem.Nivel*5;
            break;
        }
        return(Enem);
    } 

}



