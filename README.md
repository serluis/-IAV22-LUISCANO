# -IAV22-LUISCANO
PROYECTO FINAL IA 22 LUIS CANO
# P5
** Práctica 5 de Inteligencia Artificial para Videojuegos UCM **

Sergio Alberto Luis Cano Grupo 18


# Práctica 5: Flocking 3D Animalista
------

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

- Movimiento automático + Merodeo + Animación (Realizado)

<p align="center">
  <img src="https://github.com/-IAV22-LUISCANO/IA22LuisCano/imagenesMD/banco.jpg">
</p>


- Detección de presas. (Realizado)
- Detección de predadores.
- Movimiento en banco. (Realizado)
- Evasión de obstáculos. (Realizado)
- Desbandada. 
- Spawners de los distintos tipos de peces. (Realizado)


## 4. Ampliaciones
------

Toma de decisiones
- Valoración de incomodidad de terreno frente a hambre.
- Salir de zona de comfort para cazar/huir.
- Pérdida de vida a través del tiempo.
- Recuperación de vida a traves de alimento.
- vida no baja en terreno preferencial.
- no come si vida llena.
- Reproducción de ejemplares. (Realizado)

Distintas razas con diferentes comportamientos.
- Pirañas ( atacan en manada pese a pérdidas)
- Alevines ( son alimento, se reproducen pero no pierden vida con el tiempo)
- Peces normales según tamaño comen o huyen.

- Malla con preferencias de lugares
- Coberturas + Intransitable + Zonas con Temperaturas + Profundidad.

Extra:
- Tu puedes controlar un pez con teclado. (Realizado)
- Comer. (Realizado)
- Moverse. (Realizado)
- Movimiento de cámara. (Realizado)

## Proceso de Trabajo

- Descargo un ejemplo de la Unity store para poder exportar los prefab de los peces y sus animaciones para usarlos en el proyecto.
La carpeta ha sido renombrada a paquete exportado.
- Busco información con la palabra clave "flocking". Recibiendo múltiples resultados acerca de estudios de 1987 en los que se habla de un proceso llamado "boids" y sigo esa línea de investigación.
- Se estima que el acercamiento inicial de la práctica no es viable y puede requerir de una enorme cantidad de tiempo.
- Los cambios que se estiman oportunos es lograr que inicialmente los individuos se puedan mover según boids y no por merodeo como inicialmente se había planeado.

*Que los game objects sean conscientes de la cercanía de otros game objects ya sea por raycasting, por detección de colliders más grandes que el propio game object
que le permita conocer la ubicación de otros en su radio de acción.*

- Establezco un entorno en Unity siimilar a un acuario y con obstáculos que serán necesarios más adelante.
- Creo las clases: 
  **Boid
  **BoidManager
  **Spawner
  **BoidOpciones
  **BoidRayos
  ( Hay eplicaciones detalladas en los comentarios del código.)
  
- Creo un tiburón que devorará peces si choca su collider con ellos y cada vez que se coma un pez se generará otro nuevo de color naranja. Los scripts son Shark y DeadSpawner.
- Agrego un controlador sencillo para la cámara. Script Movement.
- Dejo una cámara fija y creo un botón en la pantalla con el cual alternar entre controlar un pez mediante WASD y ratón y la cámara fija.

- Agrego funcionalidad de perseguir al tiburón que va comiendo peces.

## Referencias y Bibliografía

- Información acerca de movimiento en manada y boids.
  https://en.wikipedia.org/wiki/Boids
  http://www.cs.toronto.edu/~dt/siggraph97-course/cwr87/
