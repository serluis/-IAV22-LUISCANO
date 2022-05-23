# -IAV22-LUISCANO
PROYECTO FINAL IA 22 LUIS CANO
# P5
** Práctica 5 de Inteligencia Artificial para Videojuegos UCM **

Sergio Alberto Luis Cano Grupo 18


# Práctica 5: Flocking 3D Animalista
------

<p align="center">
  <img src="https://github.com/serluis/-IAV22-LUISCANO/blob/main/IA22LuisCano/imagenesMD/titulo.jpg">
</p>


## 1. Resumen de la práctica:
------
La práctica consistirá en un simulador de vida (Peces o pájaros), con movimiento en manada. (Flocking).
Se prevee hacer una práctica en Unity con movimiento tridimensional de peces inicialmente, ampliable a bandadas de pájaros, insectos y similares.
Inicialmente el contenido inicial y la propuesta consistirá en crear unos cubos que reaccionen al movimiento entre ellos y según nos vayamos adentrando más y más añadir funcionalidades extra cada vez más complejas.

## 2. Planteamiento del proyecto
------

Creación de un grupo minoritario de 5 game objects.
Establecimiento de un sistema de merodeo en 3 dimensiones. Puede establecerse con movimiento directo con vectores 3D, aplicando fuerzas físicas o recurriendo a los cuaterniones de Unity.

Posteriormente una vez establecido se puede crear un sistema con arboles de comportamientos o con Bolt para llamar a los distintos comportamientos que se desean implementar, a saber:
- Que los game objects sean conscientes de la cercanía de otros game objects ya sea por raycasting, por detección de colliders más grandes que el propio game object
que le permita conocer la ubicación de otros en su radio de acción.
- Una vez detectados se deberá llamar a los distintos comportamientos dependiendo de ciertas condiciones.
Si es un individuo solitario:
  * Si el otro game object tiene un tamaño superior a si mismo considerará que es un depredador y entrará en comportamiento de huida.
  * Si tiene un tamaño similar considerará que es de su misma especie y entrará a formar parte de su manada o banco, moviendose en conjunto.
  * Si tiene un tamaño inferior considerará que es una presa y procederá a atacarlo y si lo alcanza lo devorará, destruyéndolo.
Si ya está grupo y encuentran un solo individuo:
  * Si el otro game object tiene un tamaño superior al más grande del grupo considerará que es un depredador y entrarán en comportamiento de huida.
  * Si tiene un tamaño similar considerará que es de su misma especie y entrará a formar parte de su manada o banco, moviendose en conjunto.
  * Si tiene un tamaño inferior considerará que es una presa y procederá a atacarlo el líder del grupo y si lo alcanza lo devorará, destruyéndolo.
Si se encuentran dos grupos:
  * Si los líderes de ambos son de un tamaño similar se unirán los grupos formando uno solo.
  * Si el líder de un grupo es superior al del otro aún no se ha decidido que sucederá dado que puede dar lugar a colisiones con los otros comportamientos.
  

Primero deberé investigar posibles referentes en youtube, stackoverflow y libros de inteligencia artificial de la biblioteca de la Universidad Complutense.
Buscaré acercamientos similares a la propuesta de esta práctica.


## 3. Funcionalidades
------

Las funcionalidades que se desean realizar son las siguientes:
### A
- Movimiento automático + Merodeo + Animación (Realizado)

### B
- Detección de presas. (Realizado)

Éste es nuestro tiburón, es de color rojo para llamar la atención.

<p align="center">
  <img src="https://github.com/serluis/-IAV22-LUISCANO/blob/main/IA22LuisCano/imagenesMD/tiburon.jpg">
</p>

Tiene un método que le permite detectar peces cercanos y dirigirse hacia ellos para una vez alcanzados, devorarlos. Ésto a su vez desencadenará una generación de un pez de color anaranjadonuevo para que nunca nos quedemos sin peces.

<p align="center">
  <img src="https://github.com/serluis/-IAV22-LUISCANO/blob/main/IA22LuisCano/imagenesMD/detectaPeces.jpg">
</p>

### C
- Detección de predadores.

El banco de peces detecta al tiburón como un obstáculo. Los peces rodearán al tiburón como si fuera un obstáculo más.

### D
- Movimiento en banco. (Realizado)

Cuando un pez encuentra a otro ajusta su dirección a la media de los demás y se convierte en un banco.

<p align="center">
  <img src="https://github.com/serluis/-IAV22-LUISCANO/blob/main/IA22LuisCano/imagenesMD/banco.jpg">
</p>

### E
- Evasión de obstáculos. (Realizado)

En la imagen se muestra como la dirección general son las flechas naranjas, mientras que la amarilla representa como se desplazan por la izquierda, separándose del banco principal y la verde como el resto del banco hace un giro hacia abajo.

<p align="center">
  <img src="https://github.com/serluis/-IAV22-LUISCANO/blob/main/IA22LuisCano/imagenesMD/esquiva.jpg">
</p>

### F
- Spawners de los distintos tipos de peces. (Realizado)

Hay 3 Spawners de peces de diferentes colores y uno extra invisible que será el encargado de generar tantos peces como haya devorado el tiburón.

<p align="center">
  <img src="https://github.com/serluis/-IAV22-LUISCANO/blob/main/IA22LuisCano/imagenesMD/spawners.jpg">
</p>

### G
- Desbandada. (No realizado)

## 4. Ampliaciones
------

Extras Realizados:
- Reproducción de ejemplares. (Realizado)
- Comer. (Realizado)
- Tu puedes controlar un pez con teclado. (Realizado)
- Moverse. (Realizado)
- Movimiento de cámara. (Realizado)

Esta imagen muestra el pez que podemos controlar de color azul con una cámara en tercera persona.
El botón para activarlo está arriba a la izquierda con la leyenda "Controlar pez".
Los controles serán WASD para moverse y shift para acelerar, la cámara también tiene cierto giro con el movimiento del ratón.

<p align="center">
  <img src="https://github.com/serluis/-IAV22-LUISCANO/blob/main/IA22LuisCano/imagenesMD/control pez.jpg">
</p>


Toma de decisiones
- Valoración de incomodidad de terreno frente a hambre.
- Salir de zona de comfort para cazar/huir.
- Pérdida de vida a través del tiempo.
- Recuperación de vida a traves de alimento.
- vida no baja en terreno preferencial.
- no come si vida llena.

Distintas razas con diferentes comportamientos.
- Pirañas ( atacan en manada pese a pérdidas)
- Alevines ( son alimento, se reproducen pero no pierden vida con el tiempo)
- Peces normales según tamaño comen o huyen.

- Malla con preferencias de lugares
- Coberturas + Intransitable + Zonas con Temperaturas + Profundidad.


## Proceso de Trabajo

- Descargo un ejemplo de la Unity store para poder exportar los prefab de los peces y sus animaciones para usarlos en el proyecto.
La carpeta ha sido renombrada a paquete exportado.
- Busco información con la palabra clave "flocking". Recibiendo múltiples resultados acerca de estudios de 1987 en los que se habla de un proceso llamado "boids" y sigo esa línea de investigación.
- Se estima que el acercamiento inicial de la práctica no es viable y puede requerir de una enorme cantidad de tiempo.
- Los cambios que se estiman oportunos es lograr que inicialmente los individuos se puedan mover según boids y no por merodeo como inicialmente se había planeado.

*Que los game objects sean conscientes de la cercanía de otros game objects ya sea por raycasting, por detección de colliders más grandes que el propio game object
que le permita conocer la ubicación de otros en su radio de acción.*

- Finalmente el uso de RayCasting es más útil.

- Establezco un entorno en Unity siimilar a un acuario, con obstáculos que serán necesarios más adelante.
- Creo las clases: 

  ** Boid: Encargado de la inteligencia de los peces y su movimiento.
  
  ** BoidManager: Encargado del movimiento en banco, de manejar las colisiones y cálculos.
  
  ** Spawner: Encargado de generar los peces.
 
  ** BoidOpciones: Encargado de las variables necesarias.
  
  ** BoidRayos: Encargado de calcular los rayos de detección.
  
  ( Hay eplicaciones detalladas en los comentarios del código.)
  
- Creo un tiburón que devorará peces si choca su collider con ellos y cada vez que se coma un pez se generará otro nuevo de color naranja. Los scripts son Shark y DeadSpawner.
- Agrego un controlador sencillo para la cámara. Script Movement.
- Dejo una cámara fija y creo un botón en la pantalla con el cual alternar entre controlar un pez mediante WASD y ratón y la cámara fija.

- Agrego funcionalidad de perseguir al tiburón que va comiendo peces.

<p align="center">
  <img src="https://github.com/serluis/-IAV22-LUISCANO/blob/main/IA22LuisCano/imagenesMD/scripts.jpg">
</p>

## Referencias y Bibliografía

 Información acerca de movimiento en manada y boids.

 * https://en.wikipedia.org/wiki/Boids
 * http://www.cs.toronto.edu/~dt/siggraph97-course/cwr87/
 
 Manual de Unity para diversas tareas.

 * Manual de Unity  https://docs.unity3d.com/es/530/Manual/UnityManual.html

 Inteligencia Artificial

 * Unity 2018 Artificial Intelligence Cookbook, Second Edition (Repositorio) https://github.com/PacktPublishing/Unity-2018-Artificial-Intelligence-Cookbook-Second-Edition
 * Unity Artificial Intelligence Programming, Fourth Edition (Repositorio) https://github.com/PacktPublishing/Unity-Artificial-Intelligence-Programming-Fourth-Edition
  
Tutoriales diversos de YouTube

* https://www.youtube.com/watch?v=RQ_peeoXTLo
* https://www.youtube.com/watch?v=QSqAz5ohODo&t
* https://www.youtube.com/watch?v=axb5twzRgUo&t
