namespace EspacioConstantes;
public class Constantes{
    public int GeneraAleatorio(int a, int b){
        Random random = new Random();
        int aleatorio = random.Next(a-1,b);
        return(aleatorio);    
    }
    public string[] nombres = {"Nombre1","Nombre2","Nombre3","Nombre4","Nombre5","Nombre6","Nombre7","Nombre8","Nombre9","Nombre10"};
    public string[] monstruo = {"Dragon","No Muerto","Demonio"};
}