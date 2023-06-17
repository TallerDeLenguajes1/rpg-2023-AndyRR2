using System;
using EspacioPersonaje;
using EspacioFabricaPersonaje;
using EspacioPantallas;
using EspacioEnemigos;
public class Program{
    private static void Main(){
        Pantallas print = new Pantallas();//para mostrar por pantalla lo necesario
        FabricaPersonaje fabrica = new FabricaPersonaje();//para cambiar valores del personaje cuando sea necesario
        Personaje PjPrincipal = new Personaje();//crea personaje principal
        PjPrincipal = fabrica.CrearPersonaje(PjPrincipal);//muestra menu principal y pide crear personaje
        PjPrincipal = fabrica.ActualizarValores(PjPrincipal);//actualiza los valores segun atributos y nivel
        print.MostrarDatosPj(PjPrincipal);//muestra datos iniciales
        
        var ListaEnemigos = new List<Enemigos>(); 
        //ListaEnemigos.EnsureCapacity(10);
        for (int i = 0; i < 10; i++){
            Enemigos Enem = new Enemigos();
            Enem = fabrica.GenerarEnemigo(Enem,1);
            ListaEnemigos.Add(Enem);
        }
        for (int i = 0; i < 10; i++){
            print.MostrarEnemigo(ListaEnemigos[i]);
        }
    }
}


