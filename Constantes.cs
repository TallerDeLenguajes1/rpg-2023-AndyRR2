namespace EspacioConstantes;
public class Constantes{
    public int GeneraAleatorio(int a, int b){
        Random random = new Random();
        int aleatorio = random.Next(a-1,b);
        return(aleatorio);    
    }
    public string[] nombres = {"del Abismo","de Sangre","Fantasmal","Antiguo","del Inframundo","Incendiario","Venenoso","Gelido","Oscuro","Ejecutador"};
    public string[] monstruo = {"Dragon","No Muerto","Demonio"};
}












