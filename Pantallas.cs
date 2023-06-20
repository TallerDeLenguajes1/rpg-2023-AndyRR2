namespace EspacioPantallas;
using System;
using EspacioPersonaje;
using EspacioEnemigos;

public class Pantallas{
    public void SubisteDeNivel(Personaje Pj){
        Console.WriteLine("!Subiste de nivel¡");
        Console.WriteLine("Enter para continuar...");
        Console.ReadLine();
        int cant=3, opcion=0;
        Console.WriteLine("Tienes 3 puntos de Atributos para gastar.");
        while (cant!=0){
            Console.WriteLine("1-Gastar en Fuerza");
            Console.WriteLine("2-Gastar en Destreza");
            Console.WriteLine("3-Gastar en Inteligencia");
            string entrada = Console.ReadLine();
            bool result = int.TryParse(entrada,out opcion);
            while (!result || (opcion!=1&&opcion!=2&&opcion!=3)){
                Console.WriteLine("Opcion no valida.");
                Console.WriteLine("Seleccione otra opcion:");
            }
            switch (opcion){
                case 1:Pj.Atributos.Fuerza += 1;break;
                case 2:Pj.Atributos.Destreza += 1;break;
                case 3:Pj.Atributos.Inteligencia += 1;break;
            }
            cant--;
            Console.WriteLine("Le quedan {0} puntos de Atributos para gastar.",cant);
        }
    }
    public void PantallaPrincipal(){
        Console.WriteLine("           ╔════════+════════╗");
        Console.WriteLine("           ║ \"Dungeon Path.\" ║");
        Console.WriteLine("           ╚════════+════════╝");
        Console.WriteLine("               1-Continuar    ");
        Console.WriteLine("             2-Nueva Partida  ");
        Console.WriteLine("                 3-Salir      ");
    }
    public void Clases(){
        Console.WriteLine("         ╔═════════════════════╗");
        Console.WriteLine("         ║ Seleccione su clase ║");
        Console.WriteLine("         ╚═════════════════════╝");
        Console.WriteLine(@"          
   1-Guerrero   2-Mago       3-Asesino
  ╔══════════╗ ╔══════════╗ ╔══════════╗          
  ║ \  @     ║ ║       ▄  ║ ║    Ø/\,  ║
  ║  \/█|██| ║ ║   \Ô__|  ║ ║  \/█     ║
  ║  _/ \_   ║ ║   /█\ |  ║ ║  _/ \_   ║
  ║          ║ ║   ! !    ║ ║          ║
  ║ Fue: 30  ║ ║ Fue: 10  ║ ║ Fue: 10  ║
  ║ Dext: 20 ║ ║ Dext: 20 ║ ║ Dext: 30 ║
  ║ Int: 10  ║ ║ Int: 30  ║ ║ Int: 20  ║
  ╚══════════╝ ╚══════════╝ ╚══════════╝");
    }
    public void MostrarFichaPj(Personaje Pj, int pv, int pm){    
        Console.WriteLine(" ╔══════════════════════════════════════╗");
        Console.WriteLine(" ║ Nombre: " + Pj.Datos.Nombre.PadRight(10) + " Apodo: " + Pj.Datos.Apodo.PadRight(10) + " ║");
        Console.WriteLine(" ║ Nacimiento: " + Pj.Datos.Fechanac.ToString("dd/MM/yyyy") + "   Edad: " + Pj.Datos.Edad.ToString().PadRight(5) + " ║");
        Console.WriteLine(" ╚══════════════════════════════════════╝");
        Console.WriteLine("   " + Pj.Atributos.Caption + "                    ");
        Console.WriteLine(" ╔══════════════════════════════════════╗");
        Console.WriteLine(" ║ Clase: " + Pj.Atributos.Tipo.PadRight(10) + "  Nivel: " + Pj.Atributos.Nivel.ToString().PadRight(10) + " ║");
        Console.WriteLine(" ║ Fuerza: " + Pj.Atributos.Fuerza.ToString().PadRight(10) + " Salud: " + Pj.Atributos.Salud.ToString().PadRight(4) + "/"+pv.ToString().PadRight(4)+"  ║");
        Console.WriteLine(" ║ Destreza: " + Pj.Atributos.Destreza.ToString().PadRight(7) + "  Mana: " + Pj.Atributos.Mana.ToString().PadRight(4) + "/"+pm.ToString().PadRight(4)+"   ║");
        Console.WriteLine(" ║ Inteligencia: " + Pj.Atributos.Inteligencia.ToString().PadRight(5) + "Ataque: " + Pj.Atributos.Ataque.ToString().PadRight(8) + "  ║");
        Console.WriteLine(" ║                    Defensa: " + Pj.Atributos.Defensa.ToString().PadRight(8) + " ║");
        Console.WriteLine(" ╚══════════════════════════════════════╝");
        Console.WriteLine("\n");
    }
    public void Empezar(){
        Console.WriteLine("     ╔══════════════════════════════╗");
        Console.WriteLine("     ║ Precione Enter para comenzar ║");
        Console.WriteLine("     ╚══════════════════════════════╝");
    }
    public void PantallaMazmorra(Personaje Pj, Enemigos Enem, int pv, int pm, int Epv){
        int costo1 = pm*35/100;
        int costo2 = pm*20/100;
        int danio = (Pj.Atributos.Ataque + Pj.Atributos.Inteligencia*10 + Pj.Atributos.Destreza*5 + Pj.Atributos.Fuerza);
        Console.WriteLine("╔══════════════════════════════════════════════════════╗");
        Console.WriteLine("║ "+Enem.Datos.Nombre.PadRight(29)+" Salud: "+Enem.Atributos.Salud.ToString().PadRight(4)+"/"+Epv.ToString().PadRight(4)+"       ║");
        Console.WriteLine("║ Nivel : "+Enem.Atributos.Nivel.ToString().PadRight(2) + "                                           ║");
        Console.WriteLine("╚══════════════════════════════════════════════════════╝");
        Console.WriteLine(Enem.Atributos.Caption.PadLeft(10)+ " ");
        Console.WriteLine("-----------------------------------------------------");
        Console.WriteLine(Pj.Atributos.Caption.PadRight(10) + "   ");
        Console.WriteLine("╔══════════════════════════════════════════════════════╗");
        Console.WriteLine("║ ╔══════════════╗     ╔══════════════╗  Nivel: "+Pj.Atributos.Nivel.ToString().PadRight(3)+"    ║");
        Console.WriteLine("║ ║ 1-Atacar     ║     ║ 3-Escapar    ║  "+Pj.Datos.Apodo.PadRight(10)+"    ║");
        Console.WriteLine("║ ╚══════════════╝     ╚══════════════╝                ║");
        Console.WriteLine("║ ╔══════════════╗     ╔══════════════╗  PV: "+Pj.Atributos.Salud.ToString().PadRight(4)+"/"+pv.ToString().PadRight(4)+" ║");
        Console.WriteLine("║ ║ 2-Poder      ║     ║ 4-Curarse    ║                ║");
        Console.WriteLine("║ ║ Costo: "+costo1.ToString().PadRight(3)+"PM ║     ║ Costo: "+costo2.ToString().PadRight(3)+"PM ║  PM: "+Pj.Atributos.Mana.ToString().PadRight(4)+"/"+pm.ToString().PadRight(4)+" ║");
        Console.WriteLine("║ ║ Daño : "+danio.ToString().PadRight(4) + "  ║     ║ Cura: "+((pv*30)/100).ToString().PadRight(4)+"PV ║                ║");
        Console.WriteLine("║ ╚══════════════╝     ╚══════════════╝                ║");
        Console.WriteLine("╚══════════════════════════════════════════════════════╝");
    }
    public void MostrarEnemigo(Enemigos Enem){
        Console.WriteLine(" @════════<<<<══════vvvv══════>>>>════════@");
        Console.WriteLine(" ╬ " + Enem.Datos.Nombre.PadRight(39) + "╬");
        Console.WriteLine(" ╬ Tipo: " + Enem.Datos.Tipo.PadRight(33) + "╬");
        Console.WriteLine(" @════════<<<<══════vvvv══════>>>>════════@");
        Console.WriteLine("   " + Enem.Atributos.Caption+ "             ");
        Console.WriteLine(" @════════<<<<══════vvvv══════>>>>════════@");
        Console.WriteLine(" ╬ Nivel: " + Enem.Atributos.Nivel.ToString().PadRight(32) + "╬");
        Console.WriteLine(" ╬ Salud: " + Enem.Atributos.Salud.ToString().PadRight(32) + "╬");
        Console.WriteLine(" ╬ Ataque: " + Enem.Atributos.Ataque.ToString().PadRight(31) + "╬");
        Console.WriteLine(" ╬ Defensa: " + Enem.Atributos.Defensa.ToString().PadRight(30) + "╬");
        Console.WriteLine(" @════════<<<<══════vvvv══════>>>>════════@");
        Console.WriteLine("--------------------------------------------\n");
    }
}