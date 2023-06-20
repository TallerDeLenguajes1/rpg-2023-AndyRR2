﻿using System;
using EspacioPersonaje;
using EspacioFabricaPersonaje;
using EspacioPantallas;
using EspacioEnemigos;
using EspacioPersonajesJson;
using EspacioMecanicas;
using EspacioConstantes;
public class Program{
    private static void Main(){
        string entrada;
        bool flag = true;

    //Instaciacion de clases a usar----------------------------------------------------------------------------------
        Pantallas print = new Pantallas();//para mostrar por pantalla lo necesario
        FabricaPersonaje fabrica = new FabricaPersonaje();//para cambiar valores del personaje cuando sea necesario
        Mecanicas mec = new Mecanicas();//mecanicas y calculos
        Constantes cons = new Constantes();//instancia constantes de partida
        cons.Valores = new Constantes.ValoresMaxDePartida();
        PersonajesJson pers = new PersonajesJson();//para guardar o cargar personaje
        Personaje PjPrincipal = new Personaje();//inctancia nuevo personaje principal
        PjPrincipal.Atributos = new Personaje.atributos();
        PjPrincipal.Datos = new Personaje.datos();
        var ListaEnemigos = new List<Enemigos>();//inctancia lista de enemigos vacia
    //Instaciacion de clases a usar- fina----------------------------------------------------------------------------

    //Comienza el juego

    //Pantalla principal----------------------------------------------------------------------------------------------------------
    int opcion=0;
    int opcion2=3;
    while (flag==true){
        print.PantallaPrincipal();//muestra pantalla principal
        entrada = Console.ReadLine();
        bool result = int.TryParse(entrada,out opcion);
        while (!result || (opcion!=1 && opcion!=2 && opcion!=3)){//no se ingreso una opcion valida
            Console.WriteLine("Opcion no valida.");
            Console.WriteLine("Entre otra opcion: ");
            entrada = Console.ReadLine();
            result = int.TryParse(entrada,out opcion);
        }
    //cuando no hay partida guardada----------------------------------------------------------------------------------------------------------
        while (opcion==1 && (!pers.ExisteArch("Personajes_Principales") || !pers.ExisteArch("Enemigos") || !pers.ExisteArch("Constantes"))){
        Console.WriteLine("No hay ninguna partida en progreso.");
        Console.WriteLine("Entre otra opcion: ");
        entrada = Console.ReadLine();
        result = int.TryParse(entrada,out opcion);
        }
    //cuando no hay partida guardada-fin------------------------------------------------------------------------------------------------------   
        //creacion de personaje----------------------------------------------------------------------------------------------
        if (opcion==2){//nueva partida
            print.Clases();//muestra las distintas clases a elegir
            PjPrincipal = fabrica.CrearPersonaje(PjPrincipal);//pide datos para crear personaje
            PjPrincipal = mec.ActualizarValores(PjPrincipal,1,PjPrincipal.Atributos.Salud,PjPrincipal.Atributos.Mana);//actualiza los valores segun atributos y nivel
            pers.GuardarPjPrincipal(PjPrincipal,"Personajes_Principales");//guarda el personaje en archivo json
        //creacion de personaje-fin-------------------------------------------------------------------------------------------

        //creacion de enemigos----------------------------------------------------------------
            for (int i = 0; i < 10; i++){//instancia cada uno de los enemigos y los fabrica
                Enemigos Enem = new Enemigos();//instancia nuevo enemigo
                Enem.Datos = new Enemigos.datos();
                Enem.Atributos =new Enemigos.atributos();
                Enem = fabrica.GenerarEnemigo(Enem,1);//genera aleatoriamente un enemigo
                ListaEnemigos.Add(Enem);//agrega al enemigo a la lista de enemigos
            }
            pers.GuardarEnemigo(ListaEnemigos,"Enemigos");
        //creacion de enemigos-fin------------------------------------------------------------  
        //establecer constantes--------------------------------------------------------------------------------
            cons.Valores.PjPvMaximo = PjPrincipal.Atributos.Salud;//guarda la salud inicial
            cons.Valores.PjPmMaximo = PjPrincipal.Atributos.Mana;//guarda el mana inicial
            cons.Valores.EnemPvMaximo = ListaEnemigos[0].Atributos.Salud;//establece vida del enemigo actual
        //establecer constantes-fin----------------------------------------------------------------------------
            pers.GuardarConstantes(cons,"Constantes");
        }else if(opcion==1){//continuar con la partida guardada
            PjPrincipal = pers.LeerPjPrincipal("Archivos/Personajes_Principales.json");//lee el personaje guardado
            ListaEnemigos = pers.LeerEnemigo("Archivos/Enemigos.json");//lee los enemigos guardados
            cons = pers.LeerConstantes("Archivos/Constantes.json");
        }else if (opcion==3){//salir del juego (con flag en false no entra al siguiente if y termian el juego)
            flag = false;
        }
    //Pantalla principal-fin-------------------------------------------------------------------------------------------------------  

    //Opcional-Pantalla de ficha de enemigos----------------------------------    
        /*foreach (var Enem in ListaEnemigos){//muestra ficha de los enemigos
            print.MostrarEnemigo(Enem);
        }*/
    //Pantalla de ficha de enemigos-fin--------------------------------------- 

    //Desarrollo del juego------------------------------------------------------------------------------------------------------------------------     
        int requiere = 1000;
        int costoPm1,costoPm2;
        if (flag){//si flag es true sigue el programa
    //Pantalla de ficha de personaje-------------------------------------------------------------------------------------------------------
        print.MostrarFichaPj(PjPrincipal, cons.Valores.PjPvMaximo, cons.Valores.PjPmMaximo);//muestra Ficha con datos y aributos iniciales
        print.Empezar();
        Console.ReadLine();//presiona enter y continua el programa
    //Pantalla de ficha de personaje-fin---------------------------------------------------------------------------------------------------
        
        //Repeticion de escenario-----------------------------------------------------------------------------------------------------------
            opcion2=0;
            while (ListaEnemigos.Count!=0 && PjPrincipal.Atributos.Salud>0 && opcion2!=3 ){
                costoPm1 = cons.Valores.PjPmMaximo*35/100;//establece un nuevo costo del poder segun el PM
                costoPm2 = cons.Valores.PjPmMaximo*20/100;//establece un nuevo costo del poder segun el PM
                //print.MostrarEnemigo(ListaEnemigos[0]);
            
                print.PantallaMazmorra(PjPrincipal,ListaEnemigos[0],cons.Valores.PjPvMaximo,cons.Valores.PjPmMaximo,cons.Valores.EnemPvMaximo);//muestra pantalla de combate 
                string entrada2 = Console.ReadLine();
                result = int.TryParse(entrada2, out opcion2);
                while ((!result && entrada2!="D")&&opcion2!=1&&opcion2!=2&&opcion2!=3&&opcion2!=4){//no se ingreso una opcion valida
                    Console.WriteLine("Opcion invalida.");
                    Console.WriteLine("Entre otra opcion: ");
                    entrada2 = Console.ReadLine();
                    result = int.TryParse(entrada2, out opcion2);
                }
                /*if (entrada2 == "D"){//opcion oculta del administrador
                ListaEnemigos = mec.DestruirEnemigo(ListaEnemigos,ListaEnemigos[0]);
                }*/   

            //acciones segun la opcion2---------------------------------------------------------------------------------------
                switch (opcion2){//realiza acciones segun la opcion
                    case 1:
                    ListaEnemigos[0]=mec.RestarPvEnemigo(ListaEnemigos[0],PjPrincipal,1,costoPm1);//ejecuta ataque
                    Console.WriteLine("Atacaste...");
                    break;
                    case 2:
                    ListaEnemigos[0]=mec.RestarPvEnemigo(ListaEnemigos[0],PjPrincipal,2,costoPm1);//ejecuta poder
                    Console.WriteLine("Usaste poder...");
                    break;
                    case 3:
                    //flag=false;//falsea a flag para escapar y salir del juego
                    Console.WriteLine("Escapaste...");
                    break;
                    case 4:PjPrincipal=mec.GanarPvPersonaje(PjPrincipal,(cons.Valores.PjPvMaximo*30)/100,costoPm2,cons.Valores.PjPvMaximo);//ejecuta curacion
                    Console.WriteLine("Te curaste...");
                    break;
                }    
                //print.MensajeAccion(opcion2,PjPrincipal,ListaEnemigos[0],cons.Valores.PjPvMaximo);//muestra mensaje segun la opcion tomada
            //acciones segun la opcion2-fin-----------------------------------------------------------------------------------
            
            //continuacion del juego si no se ha escapado-----------------------------------------------------------------------------------------
                if (opcion2!=3){
                //cuando se abate a un enemigo---------------------------------------------------------------------------------------------    
                    if (ListaEnemigos[0].Atributos.Salud<=0){
                    Console.WriteLine("Enemigo abatido...");//mensaje
                    Console.ReadLine();
                    //subir de nivel de Pj----------------------------------------------------------------------------------------------
                        PjPrincipal.Atributos.Exp += ListaEnemigos[0].Atributos.Nivel*500;//gana experiencia
                        if (requiere <= PjPrincipal.Atributos.Exp){//sube de nivel si cumple el requerimiento
                            print.SubisteDeNivel(PjPrincipal);///mensaje y aumento de atributos
                            PjPrincipal = mec.ActualizarValores(PjPrincipal,PjPrincipal.Atributos.Nivel+1,cons.Valores.PjPvMaximo,cons.Valores.PjPmMaximo);//sube un nivel
                            requiere = requiere*2;//actualiza el requerimiento    
                            cons.Valores.PjPvMaximo = PjPrincipal.Atributos.Salud;//guarda una nueva salud inicial
                            cons.Valores.PjPmMaximo = PjPrincipal.Atributos.Mana;//guarda un nuevo mana inicial
                        }
                    //subir de nivel de Pj-fin------------------------------------------------------------------------------------------

                    //pasar al siguiente enemigo-------------------------------------------------------------------------------------    
                        ListaEnemigos = mec.DestruirEnemigo(ListaEnemigos, ListaEnemigos[0]);//destruye al enemigo actual
                        if (ListaEnemigos.Count!=0){//si aun quedan enemigos en la lista
                            foreach (var Enem in ListaEnemigos){//sube de nivel a los enemigos restantes
                                Enem.Atributos.Nivel += 1;
                            }
                            ListaEnemigos[0] = mec.ActualizarValoresE(ListaEnemigos[0]);//actualiza valores de enemigos + un nivel
                            cons.Valores.EnemPvMaximo = ListaEnemigos[0].Atributos.Salud;//reestablece vida del enemigo actual 
                        }
                    //pasar al siguiente enemigo-fin---------------------------------------------------------------------------------
                    
                //cuando se abate a un enemigo-fin----------------------------------------------------------------------------------------

                //turno enemigo---------------------------------------------------------------------------------------
                    }else{
                        Console.WriteLine("Enemigo ataca...");
                        Console.ReadLine();
                        PjPrincipal = mec.RestarPvPersonaje(ListaEnemigos[0], PjPrincipal);//ejecuta ataque enemigo
                    }
                //turno enemigo-fin-----------------------------------------------------------------------------------    
                }
                pers.GuardarPjPrincipal(PjPrincipal,"Personajes_Principales");//guarda el personaje al final de la ronda en archivo json 
                pers.GuardarEnemigo(ListaEnemigos,"Enemigos");//se guarda la nueva lista de enemigos el final de la ronda en archivo json 
                pers.GuardarConstantes(cons,"Constantes");
            //continuacion del juego si no se ha escapado-fin-------------------------------------------------------------------------------------    
            }
        //Repeticion de escenario-fin-------------------------------------------------------------------------------------------------------

        //cuando ganas el juego---------------------------------------    
            if (ListaEnemigos.Count==0){
                Console.WriteLine("Abatiste a todos los enemigos.");
                Console.WriteLine("!Has Ganado¡");
                Console.ReadLine(); 
                File.Delete("Archivos/Constantes.json"); 
                File.Delete("Archivos/Enemigos.json");
                File.Delete("Archivos/Personajes_Principales.json");
            }
        //cuando ganas el juego-fin----------------------------------- 

        //cuando pierdes----------------------------------------------
            if (PjPrincipal.Atributos.Salud<=0){
                Console.WriteLine("You Are Die.");
                Console.ReadLine();
                File.Delete("Archivos/Constantes.json"); 
                File.Delete("Archivos/Enemigos.json");
                File.Delete("Archivos/Personajes_Principales.json");
            }  
        //cuando pierdes-fin------------------------------------------ 
        }
        Console.WriteLine("Fin del Juego");  
    }
        Console.WriteLine("Juego Cerrado...");
    }
    //Desarrollo del juego-fin--------------------------------------------------------------------------------------------------------------------
}


