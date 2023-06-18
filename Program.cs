using System;
using EspacioPersonaje;
using EspacioFabricaPersonaje;
using EspacioPantallas;
using EspacioEnemigos;
using EspacioPersonajesJson;
public class Program{
    private static void Main(){
        string entrada;
        int opcion,nivel = 1;
        bool flag = true;
        FabricaPersonaje fabrica = new FabricaPersonaje();//para cambiar valores del personaje cuando sea necesario

        Personaje PjPrincipal = new Personaje();//crea nuevo personaje principal
        PjPrincipal.Atributos = new Personaje.atributos();
        PjPrincipal.Datos = new Personaje.datos();

        var ListaEnemigos = new List<Enemigos>();//crea lista de enemigos vacia

        PersonajesJson pers = new PersonajesJson();//para guardar o cargar personaje

        Pantallas print = new Pantallas();//para mostrar por pantalla lo necesario

        print.PantallaPrincipal();//muestra pantalla principal
        entrada = Console.ReadLine();
        bool result = int.TryParse(entrada,out opcion);
        while (!result || (opcion!=1 && opcion!=2 && opcion!=3)){
            Console.WriteLine("Opcion no valida.");
            Console.WriteLine("Entre otra opcion: ");
            entrada = Console.ReadLine();
            result = int.TryParse(entrada,out opcion);
        }
        if (opcion==2){//nueva partida
            print.Clases();
            PjPrincipal = fabrica.CrearPersonaje(PjPrincipal);//muestra menu principal y pide crear personaje
            PjPrincipal = fabrica.ActualizarValores(PjPrincipal,nivel);//actualiza los valores segun atributos y nivel
            pers.GuardarPjPrincipal(PjPrincipal,"Personajes_Principales");//guarda el personaje en archivo json
            nivel = PjPrincipal.Atributos.Nivel;//establece el nivel de los nemegiso segun el del personaje
            for (int i = 0; i < 10; i++){//crea cada uno de los enemigos y los fabrica
                Enemigos Enem = new Enemigos();
                Enem.Datos = new Enemigos.datos();
                Enem.Atributos =new Enemigos.atributos();
                Enem = fabrica.GenerarEnemigo(Enem,nivel);
                ListaEnemigos.Add(Enem);
            }
            pers.GuardarEnemigo(ListaEnemigos,"Enemigos");
        }else if(opcion==1){//continuar
            PjPrincipal = pers.LeerPjPrincipal("Archivos/Personajes_Principales.json");
            ListaEnemigos = pers.LeerEnemigo("Archivos/Enemigos.json");
        }else if (opcion==3){
            flag = false;
        }
        print.MostrarFichaPj(PjPrincipal);//muestra Ficha con datos y aributos iniciales
        print.Empezar();
        Console.ReadLine();//presiona enter y continua el programa
        /*foreach (var Enem in ListaEnemigos){//muestra ficha de los enemigos
            print.MostrarEnemigo(Enem);
        }*/
        if (flag){
            int Pjpv,Pjpm,Epv, i=0;
            Pjpv = PjPrincipal.Atributos.Salud;
            Pjpm = PjPrincipal.Atributos.Mana;
            Epv = ListaEnemigos[i].Atributos.Salud;
            while (ListaEnemigos.Count!=0){
                print.MostrarEnemigo(ListaEnemigos[0]);
                print.PantallaMazmorra(PjPrincipal,ListaEnemigos[0],Pjpv,Pjpm,Epv); 
                entrada = Console.ReadLine();
                result = int.TryParse(entrada, out opcion);
                while ((!result && entrada!="D")&&opcion!=1&&opcion!=2&&opcion!=3&&opcion!=4){
                    Console.WriteLine("Opcion invalida.");
                    Console.WriteLine("entre otra opcion: ");
                    entrada = Console.ReadLine();
                    result = int.TryParse(entrada, out opcion);
                }
                while (opcion!=3){
                    if (entrada == "D"){//opcion oculta del administrador
                    ListaEnemigos = fabrica.DestruirEnemigo(ListaEnemigos,ListaEnemigos[0]);
                    pers.GuardarEnemigo(ListaEnemigos,"Enemigos");
                    }   
                    switch (opcion){
                        case 1:;break;
                        case 2:;break;
                        case 4:;break;
                    }    
                }
            }  
            Console.WriteLine("Fin del Juego");  
        }
        Console.WriteLine("Juego Cerrado.");
    }
}


