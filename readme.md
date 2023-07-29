Creador: Rodriguez Rodriguez Andy Alejandro 
DNI: 95885779

**** Reglas y explicación del juego: ****

-Se trata de un Juego RPG para 1 solo jugador, donde el usuario selecciona una clase de personaje entre (Guerrero, Mago y Asesino), cada clase tiene un total de 60 puntos de atributos iniciales que estan distribuidos de forma diferente segun la clase elegida y las estadisticas del personaje se calculan segun estos atributos.

-Ganas cuando derrotas los 10 enemigos y pierdes cuando pierdes toda la salud.
-Puedes abandonar la partida en mitad del juego y continuar donde te quedaste en otro momento.
-Si ganas o pierdes, al salir del juego se borran los datos de tu personaje, solo quedan guardados si aun no has terminado.

-Al comenzar el juego se empieza en nivel 1 de personaje y se genera aleatoriamnete (usando una API) cada parte de tu armadura y armas iniciales segun tu clase.
-(Las objetos de equipo generados o dropeados no aportan nada a las estadisticas, es solo una mecanica de estetica).

-Luego se generan 10 enemigos de nivel 1 aleatoriamente con los cuales hay que combatir, cuando un enemigo es abatido, todos los otros suben un nivel y por lo tanto todas sus estadisticas de manera que aumenta la dificultad, ademas te dropea un objeto nuevo aleatorio y es reemplazado en tu equipo por el del mismo tipo (Ej: si dropea un Casco lo reemplaza por el Casco que ya tenias).

-Cada vez que un enemigo muere ganas experiencia igual a la salud de ese enemigo, al acumular sierta cantidad de experiencia subes de nivel. 
-Cando subes de nivel te curas hasta el maximo de PV, se te regenera todo el PM gastado y obtienes 3 puntos de atributos para distribuir como quieras, cada vez es mas dificil subir de nivel.

-Cuenta con un menu de combate con 4 opciones, 1-ataque basico, 2-poder, 3-escapar y 4-curarse, las opciones de curarse y poder tienen un costo de PM
-Si intentas usar poder o curarte y no tienes suficiente PM, tu accion falla y pierdes el turno, pero el enemigo si te ataca a ti.

-Menu de combate:
1-Atacar: ataque basico, basado en los atributos y nivel
2-Poder: ataque mas fuerte, basado en ataque, atributos y nivel
  Costo: 35 % PM_maximo (para Mago el Costo se reduce un 50%)
3-Escapar: sales del combate
4-Curarse: te cura una parte de tu salud, basado en la cantidad de PV y cantidad de PM
  Costo: 25 % PM_maximo (para Mago el Costo se reduce un 50%)

-Calculo de estadisticas y acciones:
Salud: Fuerza*10 + Destreza*5 + Inteligencia*3 + nivel*200;
Mana: Inteligencia*10 + nivel*100;
Ataque: Destreza*10 + Fuerza*5 + Inteligencia*3 + nivel*10;
Poder: Ataque + Inteligencia*10 + Destreza*5 + Fuerza
Defensa: Fuerza*10 + Destreza*5 + Inteligencia*3 + nivel*10;
Curarse: 30 % PV + 30 % PM

Consejos de como jugar para ganar:
-Elige bien el momento para usar el poder o curarte.
-Trata de gastar todo tu PM ya sea en el poder o curandote cuando estes a punto de subir de nivel ya que luego se regenera todo.
-Con enemigos de alto nivel dependiendo de la clase puede ser mas util curarse varias veces en vez de usar el poder.
