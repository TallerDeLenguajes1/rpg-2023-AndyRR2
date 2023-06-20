namespace EspacioMecanicas;
using System;
using EspacioEnemigos;
using EspacioPersonaje;
public class Mecanicas{
    public Personaje GanarPvPersonaje(Personaje Pj, int ganarPv, int costoPm, int maximoPv){
        if (costoPm <= Pj.Atributos.Mana){
            if (Pj.Atributos.Salud + ganarPv >= maximoPv){
                Pj.Atributos.Salud = maximoPv;
            }else{
                Pj.Atributos.Salud += ganarPv;
            }
            Pj.Atributos.Mana = Pj.Atributos.Mana - costoPm;
        }else{
            Console.WriteLine("Fallaste, no tienes suficiente mana.");
            Console.WriteLine("Enter para continuar...");
            Console.ReadLine();
        }
        return(Pj);
    }
    public Enemigos RestarPvEnemigo(Enemigos Enem,Personaje Pj, int opcion, int costoPm){
        switch (opcion){
            case 1:Enem.Atributos.Salud -= (Pj.Atributos.Ataque-(Enem.Atributos.Defensa*25)/100);break;
            case 2:
            if (Pj.Atributos.Mana >= costoPm){
            Enem.Atributos.Salud -= (Pj.Atributos.Ataque + Pj.Atributos.Inteligencia*10 + Pj.Atributos.Destreza*5 + Pj.Atributos.Fuerza);
            Pj.Atributos.Mana -= costoPm;
            }else{
                Console.WriteLine("Fallaste, no tienes suficiente mana.");
                Console.WriteLine("Enter para continuar...");
                Console.ReadLine();
            }
            break;
        }
        return(Enem);
    }
    public Personaje RestarPvPersonaje(Enemigos Enem,Personaje Pj){
        Pj.Atributos.Salud = Pj.Atributos.Salud - (Enem.Atributos.Ataque /*-(Pj.Atributos.Defensa*50)/100*/);
        return(Pj);
    }    
    public List<Enemigos> DestruirEnemigo(List<Enemigos> ListEnem,Enemigos Enem){
        ListEnem.Remove(Enem);
        return(ListEnem);
    }
    public Personaje ActualizarValores(Personaje Pj, int nivel, int pv, int pm){
        Pj.Atributos.Nivel = nivel;
        Pj.Atributos.Salud = pv + Pj.Atributos.Fuerza*10 + Pj.Atributos.Nivel*20;
        Pj.Atributos.Mana = pm + Pj.Atributos.Inteligencia*5 + Pj.Atributos.Nivel*10;
        Pj.Atributos.Ataque = Pj.Atributos.Ataque + Pj.Atributos.Destreza*5 + Pj.Atributos.Fuerza*3 + Pj.Atributos.Inteligencia*2 + Pj.Atributos.Nivel*2;
        Pj.Atributos.Defensa = Pj.Atributos.Defensa +Pj.Atributos.Fuerza*5 +Pj.Atributos.Destreza*2 + Pj.Atributos.Inteligencia + Pj.Atributos.Nivel*2;
        return(Pj);
    } 
    public Enemigos ActualizarValoresE(Enemigos Enem){
        Enem.Atributos.Salud = Enem.Atributos.Salud + Enem.Atributos.Nivel*750;
        Enem.Atributos.Ataque = Enem.Atributos.Ataque + Enem.Atributos.Nivel*15;
        Enem.Atributos.Defensa = Enem.Atributos.Defensa + Enem.Atributos.Nivel*10;
        return(Enem);
    }
    public int GeneraAleatorio(int a, int b){
        Random random = new Random();
        int aleatorio = random.Next(a-1,b);
        return(aleatorio);    
    }
}