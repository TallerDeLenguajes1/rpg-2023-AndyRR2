namespace EspacioConstantes;
using System;
public class Constantes{
    public ValoresMaxDePartida Valores{get;set;}
    public class ValoresMaxDePartida{
        private int pjPvMaximo;
        private int pjPmMaximo;
        private int enemPvMaximo;

        public int PjPvMaximo { get => pjPvMaximo; set => pjPvMaximo = value; }
        public int PjPmMaximo { get => pjPmMaximo; set => pjPmMaximo = value; }
        public int EnemPvMaximo { get => enemPvMaximo; set => enemPvMaximo = value; }
    }
    public string[] nombres = {"del Abismo","de Sangre","Fantasmal","Antiguo","del Inframundo","Incendiario","Venenoso","Gelido","Oscuro","Ejecutador"};
    public string[] monstruo = {"Dragon","No Muerto","Demonio"};

    
}












