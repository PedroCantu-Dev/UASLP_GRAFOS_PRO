# GRAFOS_PRO

Un editor de grafos en c# (windows forms). El editor de grafos es una herramienta que se genera como entregable en la materia de grafos del area de ciencias de la computacion de la UASLP

## Requisitos para correr el proyecto:

El proyecto esta hecho en windows forms por lo que se necesitara tener [Visual Studio](https://visualstudio.microsoft.com/es/free-developer-offers) , el cual está disponible para windows y IOS.

* Windows [Visual Studio Download](https://visualstudio.microsoft.com/es/free-developer-offers)

* IOS [Visual Studio Download](https://visualstudio.microsoft.com/es/free-developer-offers).

## Clonar el proyecto:

### Clonar el proyecto desde github:

En esta pagina del proyecto dentro de github puedes facilmente descargar el proyecto en un archivo zip, al descomprimirlo e ingresar a la carpeta encontraremos un archivo 
*.sln (editorGrafos.sln) que es el archivo de la solucion, para ingresar a ella se tiene que hacer doble click en este archivo, ya con el visual studio instalado, esto nos 
habre la solucion y podemos ver sus archivos y editarlos, asi coomo debugear el proyecto.

### Clonar el proyecto con Git:
A mi parecer clonar el proyecto desde terminal de comandos siempre acaba siendo mas sencillo y practico. Necesitas tener [git](https://git-scm.com/) instalado en tu ordenador lo mas facil es usar "git bash" pero cualquier terminal de comandos puede hacer la tarea siempre y cuando las variables de etorno correctamente configuradas.

#### clonar el repositorio:
Primero sitearse sobre una carpeta en la que pueda estar el proyecto y despues simplemente ingresar en linea de comandos el siguiente comando:

```
$ git clone https://github.com/Pedejeca135/GRAFOS_PRO
```

## Editor Sections (Secciones del editor):
El editor cuenta con varias secciones

### File options:
Estas opciones nos dejan guardar grafos hechos en el editor como un archivo de texto, para poder abrirlos cuando sea necesario. 

#### New(Nuevo):
Genera un nuevo archivo para trabajar, si se aprieta y el grafo en el que se esta trabajando tiene cambios si guardar pregunta si los quieres guardar o no.

#### Open(Abrir):
Abre un buscador de archivs para elegir el archivo que se quiere abrir, si el archivo es efectivo lo abrira sin problemas, de lo contrario mostrara un mensaje de error.
Si se desea abrir un archivo y el grafo en uso tiene cambios sin guardar se pregunta al usuario si los quiere salvar.

##### Ejemplos:
Puedes abrir grafos de ejemplo que sirven para verificar los algoritmos implementados dentro de la carpeta del proyecto en una carpeta que se llama ./GraphSamples, cada uno lleva el nombre de el algoritmo que intenta demostrar. Pero en si cualquier algoritmo es valido para cualquier grafo, el editor indica el error de incompatibilidad que puede presentar el grafo, con el algoritmo que se esta intentando correr.

#### Save(Guardar):
Guarda el archivo en uso en un archivo de texto.

### View (vista):
Estas son opciones de la vista del editor. Como por ejemplo si los pesos de las aristas son visibles, la vista de la matriz que representa el grafo, etc.

### Boxes:
Estos son cajas de texto que especifican el estado y caracteristicas del grafo y de los nodos en "tiempo real".

#### Graph Information Box:
Esta caja especifica informacion del grafo en cuestion, 

#### Node Selected Information Box:

#### Matrix Representation Box:

## Operaciones sobre el grafo y los nodos.
Las operaciones se refieren a todos los metodos basicos para trabajar con los nodos, estos van desde la creacion y eliminacion de nodos, generacion de aristas, etc.

### Selected Node States (Estados de seleccion de nodo):
Cualquier nodo puede ser elegi

#### State 0 - Black:
Es el estado inicial de los nodos.
##### Any
* **Left Click:** Selecciona el nodo y aumenta su estado de seleccion(1).

#### State 1 - Green:
##### Selected(Self)
* **Left Click:** Cambia el nodo seleccionado al siguiente estado(2).
* **Right Click:** Mueve el nodo
##### Other
* **Left Click:** Cambia el nodo seleccionado a other con el mismo estado(1).
* **Right Click:** -----

#### State 2 - Blue:
##### Selected(Self)
* **Left Click:** Cambia el nodo seleccionado al siguiente estado(3).
* **Right Click:** crea una oreja en el nodo.
##### Other
* **Left Click:** Crea un enlace **no dirigido** entre el nodo seleccionado(Self) y el nodo clickeado(Other). 
* **Right Click:** Cambia el nodo seleccionado a other con el mismo estado(2).

#### State 3 - Red:
##### Self
* **Left Click:** Cambia el estado de seleccion a 0.
* **Right Click:** Elimina el nodo seleccionado.
##### Other
* **Left Click:** Crea un enlace **dirigido** entre el nodo seleccionado y el nodo clickeado(other). 
* **Right Click:** Cambia el nodo seleccionado a other con el mismo estado(3).



### Operations (operaciones):
Son las operaciones que se pueden realizar sobre el grafo mediante el uso del mouse,si es que estan activadas.
Las operaciones son mutuamente excluyentes y cuando son activadas se deselecciona cualquier nodo.

A continuacion se muestra una tabla que especifica las distintas operaciones que se pueden realizar cuando estan activadas.

#### Move (M):
Se pueden mover cada uno de los nodos individualmente con los botones izquierdo y derecho.
#### Move All (A):
Se puede mover todo el grafo a la vez con el boton izquierdo y derecho.
#### Remove (R):
Se pueden eliminar cada nodo individualmente
#### MoRe (F):
Viene de Move-Remove. Los nodos se mueven con boton izquierdo del mouse y se eliminan con el boton derecho individualmente.
#### Linking (L):
Se pueden hacer enlaces **no dirigidos** con el boton izquerdo y **dirigidos** con el boton derecho.

##### Linking Undirected(U):
Se pueden hacer enlaces **no dirigidos** con cualquier boton.

##### Linking Directed (D):
Se pueden hacer enlaces **dirigidos** con cualquier boton


### Truncated weight(Peso truncado):
Esta opcion permite designar un peso especifico para las aristas que se crearan. Se debe de marcar un numero en la caja de texto y apretar el boton, el cual permanecera en verde mientras este activo. Si es así, el editor pondra este valor de peso en cualquier arista que se cree sin preguntar, de lo contrario se abrira una nueva Forma que le pedira un valor para el peso de la arista.

### Algoritmos:

#### DFS:
##### Tipo de Grafos:
* Dirigido.
* No dirigido.

##### Input:
Recibe el Nodo de inicio para llevar a cabo el recorrido en profundidad. Si este no es especificado el algoritmo elige uno por default.
##### Output:
Regresa un Forest(Bosque), un conjunto de Trees(arboles), que es una clase que hereda de Grafo y se caracteriza por no contener ciclos.

##### Procedimiento:

##### Invocacion:


#### BFS:
##### **Tipo de Grafos**
* Dirigido.
* No dirigido.
##### Input:
##### Output:
##### Procedimiento:
##### Invocacion:


#### Kruskal:
##### **Tipo de Grafos**
* No dirigidos.

##### Input:
##### Output:
##### Procedimiento:
##### Invocacion:


#### Prim:
##### **Tipo de Grafos**
* No dirigidos.
##### Input:
##### Output:
##### Procedimiento:
##### Invocacion:


#### Warshall:
##### **Tipo de Grafos**
* Dirigido.
* No dirigido.

##### Input:
##### Output:
##### Procedimiento:
##### Invocacion:


#### Floyd:
##### **Tipo de Grafos**
* Dirigido.
* No dirigido.
##### Input:
##### Output:
##### Procedimiento:
##### Invocacion:


#### Dijkstra:
##### **Tipo de Grafos**
* Dirigido.
* No dirigido.
##### Input:
##### Output:
##### Procedimiento:
##### Invocacion:


#### Caminos de Euler:
##### **Tipo de Grafos**
* Dirigido.
* No dirigido.
##### Input:
##### Output:
##### Procedimiento:
##### Invocacion:


#### Caminos de Hamilton:
##### **Tipo de Grafos**
* Dirigido.
* No dirigido.
##### Input:
##### Output:
##### Procedimiento:
##### Invocacion:


#### Isomorfismo:
##### **Tipo de Grafos**
* Dirigido.
* No dirigido.
##### Input:
##### Output:
##### Procedimiento:
##### Invocacion:


## Versiones

Cuenta con varias versiones. Para mas informacion revisar los [tags](https://github.com/Pedejeca135/GRAFOS_PRO) en la seccion de Branchs.

## Autoría

* **Pedro Cantú** [Pedejeca135](https://github.com/Pedejeca135)

## Licencia
[MIT](https://github.com/theupdateframework/specification/blob/master/LICENSE-MIT.txt)

Puedes usar parcial o totalmente el codigo en otros proyectos y repositorios.
