# GRAFOS_PRO

Un editor de grafos en c# (windows forms). El editor de grafos permite crear grafos visualmente y generar archivos que los representan. Utiliza una estructura de listas para representar las aristas.

<img src="https://user-images.githubusercontent.com/44269967/134715454-d9c4f09b-e8c8-431c-91b7-a8501e0760dd.PNG" width="900" />



## Requisitos para correr el proyecto:

El proyecto esta hecho en Windows Forms por lo que se necesitara tener [Visual Studio](https://visualstudio.microsoft.com/es/free-developer-offers) en la version 2019 o posterior, el cual está disponible para windows y IOS.

* Windows [Visual Studio Download](https://visualstudio.microsoft.com/es/free-developer-offers)

* IOS [Visual Studio Download](https://visualstudio.microsoft.com/es/free-developer-offers).

## Clonar el proyecto:

### Clonar el proyecto desde github:

En esta pagina del proyecto dentro de github puedes facilmente descargar el proyecto en un archivo zip, al descomprimirlo e ingresar a la carpeta encontraremos un archivo 
*.sln (editorGrafos.sln) 

<img src="https://user-images.githubusercontent.com/44269967/134695997-35c5c780-ae53-4980-ba27-b89c59d8e45d.gif" width="900" />



el archivo *.sln (editorGrafos.sln), es el archivo de la solucion, para ingresar a ella se tiene que hacer doble click en este archivo, ya con el visual studio instalado, esto nos 
habre la solucion y podemos ver sus archivos y editarlos, asi mismo debugear el proyecto.


<img src="https://user-images.githubusercontent.com/44269967/134696847-ec0b5813-30be-43ce-8dd5-bdf024457237.gif" width="700" />




### Clonar el proyecto con Git:
A mi parecer clonar el proyecto desde terminal de comandos siempre acaba siendo mas sencillo y practico. Necesitas tener [git](https://git-scm.com/) instalado en tu ordenador lo mas facil es usar "git bash" pero cualquier terminal de comandos puede hacer la tarea siempre y cuando las variables de etorno correctamente configuradas.




#### clonar el repositorio:
Primero sitearse sobre una carpeta en la que pueda estar el proyecto y despues simplemente ingresar en linea de comandos el siguiente comando:

```
$ git clone https://github.com/Pedejeca135/GRAFOS_PRO
```
<img src="https://user-images.githubusercontent.com/44269967/134730375-68c92628-4ee1-4761-86ab-b38e67afccb6.png" width="700" />


## Editor Sections (Secciones del editor):
El editor cuenta con varias secciones

![editor PresentacionBySection](https://user-images.githubusercontent.com/44269967/134715382-3d878769-cc0c-4bc5-b7fe-b2a995d12ca3.png)


### File options:
![image](https://user-images.githubusercontent.com/44269967/134715687-93fb910c-774b-4434-b918-ba7e03337a20.png)

Estas opciones nos dejan manejar los grafos hechos en el editor como un archivo de texto, para poder abrirlos y editarlos de nuevo cuando sea necesario.

#### New(Nuevo):
![image](https://user-images.githubusercontent.com/44269967/134715821-e8726114-5f21-4619-9864-c7352c0f62ff.png)

Genera un nuevo archivo para trabajar, si se aprieta y el grafo en el que se esta trabajando tiene cambios si guardar pregunta si los quieres guardar o no.

#### Open(Abrir):
![image](https://user-images.githubusercontent.com/44269967/134715855-fb016a92-5967-41bc-af04-381f52d1b8cb.png)

Abre un buscador de archivs para elegir el archivo que se quiere abrir, si el archivo es efectivo lo abrira sin problemas, de lo contrario mostrara un mensaje de error.
Si se desea abrir un archivo y el grafo en uso tiene cambios sin guardar se pregunta al usuario si los quiere salvar.

##### Ejemplos:
Puedes abrir grafos de ejemplo que sirven para verificar los algoritmos implementados dentro de la carpeta del proyecto en una carpeta que se llama ./GraphSamples, cada uno lleva el nombre de el algoritmo que intenta demostrar. Pero en si cualquier algoritmo es valido para cualquier grafo, el editor indica el error de incompatibilidad que puede presentar el grafo, con el algoritmo que se esta intentando correr.

#### Save(Guardar):
![image](https://user-images.githubusercontent.com/44269967/134715892-8dcbb1b2-00e9-4d0f-90ef-5df165963afd.png)

Guarda el archivo en uso en un archivo de texto.

### View (vista):
Estas son opciones de la vista del editor. Como por ejemplo si los pesos de las aristas son visibles, la vista de la matriz que representa el grafo, etc.


## Operaciones sobre el grafo y los nodos.
Las operaciones se refieren a todos los metodos basicos para trabajar con los nodos, estos van desde la mas basica que es la creacion y eliminacion de nodos,y ademas la generacion de aristas, etc.

### Operations (operaciones):
Son las operaciones que se pueden realizar sobre el grafo mediante el uso del mouse,facilitan la creacion y manipulacion de grafos, solo funcionan si es que estan activadas.
Las operaciones son mutuamente excluyentes y cuando son activadas se deselecciona cualquier nodo. Pra la creacion de un nodo basta con dar click en la seccion para el grado del editor, esta accion creara un nodo con un identificador unico, el indice se maneja para la lista de nodos dentro del grafo por lo que puede varier dependiendo de si un nodo es eliminado, pues esto altera el indice de los nodos con indice mayor.

###############A continuacion se muestra una tabla que especifica las distintas operaciones que se pueden realizar cuando estan activadas.

#### Move (M):
Se pueden mover cada uno de los nodos individualmente con los botones izquierdo y derecho.

<img src="https://user-images.githubusercontent.com/44269967/134717821-14e9f9da-071c-4a3e-9884-10ace13076f4.gif" width="600" />

#### Move All (A):
Se puede mover todo el grafo a la vez con el boton izquierdo y derecho.

<img src="https://user-images.githubusercontent.com/44269967/134717838-6e99b2d8-39ee-4e6f-af8b-74ec4802efb1.gif" width="600" />

#### Remove (R):
Se pueden eliminar cada nodo individualmente

<img src="https://user-images.githubusercontent.com/44269967/134717854-76710021-9f91-49fe-8ff7-dd29fef6f942.gif" width="600" />

#### MoRe (F):
Viene de Move-Remove. Los nodos se mueven con boton izquierdo del mouse y se eliminan con el boton derecho individualmente.

<img src="https://user-images.githubusercontent.com/44269967/134717869-6fef26f9-248e-4477-a7e6-1518de89d90b.gif" width="600" />

#### Linking (L):
Se pueden hacer enlaces **no dirigidos** con el boton izquerdo y **dirigidos** con el boton derecho.

<img src="https://user-images.githubusercontent.com/44269967/134731747-c675b38b-f28c-4451-8dd8-19f49f518234.gif" width="600" />

##### Linking Undirected(U):
Se pueden hacer enlaces **no dirigidos** con cualquier boton.

<img src="https://user-images.githubusercontent.com/44269967/134732269-1a77d735-30c0-4e94-9d97-2873d122fa55.gif" width="600" />

##### Linking Directed (D):
Se pueden hacer enlaces **dirigidos** con cualquier boton

<img src="https://user-images.githubusercontent.com/44269967/134732916-72e63500-f5c3-472a-976a-4ce4d0cda76a.gif" width="600" />

### Truncated weight(Peso truncado):
![image](https://user-images.githubusercontent.com/44269967/134716314-0ec3f583-c59a-4e46-af81-c82f60c7e588.png)

Esta opcion permite designar un peso especifico para las aristas que se crearan. Se debe de marcar un numero en la caja de texto y apretar el boton, el cual permanecera en verde mientras este activo. Si es así, el editor pondra este valor de peso en cualquier arista que se cree sin preguntar, de lo contrario se abrira una nueva Forma que le pedira un valor para el peso de la arista.

![image](https://user-images.githubusercontent.com/44269967/134733603-8d352258-fceb-4c66-9549-cfbcb8063dee.png)

### Selected Node States (Estados de seleccion de nodo):
Cualquier nodo puede ser selccionado, estos cuentan con tres estados de sleccion aciva, a continuacion se detallan las operaciones queestos estados pemiten hacer sobre el nodo.

<img src="https://user-images.githubusercontent.com/44269967/134720120-bb7bbd76-2689-4f6e-96ca-a9237fb09ec5.gif" width="800" />


#### State 0 - Black:

![image](https://user-images.githubusercontent.com/44269967/134719052-48c1e802-649d-4ba3-91ac-d9e54522a2b6.png)

Es el estado inicial de los nodos.
Solo un nodo puede ser selecionadoa la vez, cando haya alguno su informacion aparecera en la caja de infomacion de nodo seleccionado.

![image](https://user-images.githubusercontent.com/44269967/134719538-1cb9154a-d956-47d3-aef2-58879e5396ec.png)

##### Any Node
* **Left Click:** Selecciona el nodo y aumenta su estado de seleccion (1).

#### State 1 - Green:

![image](https://user-images.githubusercontent.com/44269967/134719112-6ba48c15-693e-4a8e-8990-9a15a6a83f82.png)
##### Selected(Self)
* **Left Click:** Cambia el nodo seleccionado al siguiente estado (2).
* **Right Click:** Mueve el nodo
##### Other
* **Left Click:** Cambia el nodo seleccionado a other con el mismo estado (1).
* **Right Click:** -----

#### State 2 - Blue:

![image](https://user-images.githubusercontent.com/44269967/134719161-f1a0c319-0dfd-42fd-b768-dd3d1927e5cb.png)

##### Selected(Self)
* **Left Click:** Cambia el nodo seleccionado al siguiente estado (3).
* **Right Click:** crea una oreja en el nodo.
##### Other
* **Left Click:** Crea un enlace **no dirigido** entre el nodo seleccionado (Self) y el nodo clickeado (Other). 
* **Right Click:** Cambia el nodo seleccionado a Other con el mismo estado (2).

#### State 3 - Red:

![image](https://user-images.githubusercontent.com/44269967/134719190-37f9569b-33c1-4065-ae4f-09048467552c.png)

##### Self
* **Left Click:** Cambia el estado de seleccion a 0.
* **Right Click:** Elimina el nodo seleccionado.
##### Other
* **Left Click:** Crea un enlace **dirigido** entre el nodo seleccionado (Self) y el nodo clickeado (Other). 
* **Right Click:** Cambia el nodo seleccionado a other con el mismo estado (3).

#### Ejemplo de como recrear grafos mediante seleccion de nodos:
es importante mencionar que al crear aristas estas se denominan con un tipo, ya sea dirigidas y no dirigidas, si un grafo contiene almenos una arista dirigida se considera grafo dirigido no importando que sus otras aristas se hayan creado como dirigidas.

Para recrear el siguiente grafo dirigido operando con los nodos:

![image002](https://user-images.githubusercontent.com/44269967/134723849-11010d08-a86c-4b67-95bd-14344924f702.gif)

Esta seria una de las posibilidades para el dirigido:

![ejemplo1](https://user-images.githubusercontent.com/44269967/134725766-a9283f9e-93b9-4c71-9c6a-9785cfd000d0.gif)

Para el no dirigido:

![ejemplo2](https://user-images.githubusercontent.com/44269967/134726748-2a1dedae-4d0a-4bf5-93fc-9c9b60fd6c04.gif)



### Boxes:
Estos son cajas de texto que especifican el estado y caracteristicas del grafo y de los nodos en "tiempo real".

#### Graph Information Box:
Esta caja especifica informacion del grafo en cuestion, 

#### Node Selected Information Box:

#### Matrix Representation Box:



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

Cuenta con varias versiones. Para mas informacion revisar los [tags](https://github.com/Pedejeca135/GRAFOS_PRO/tags) en la seccion de Branchs.

## Autoría

* **Pedro Cantú** [Pedejeca135](https://github.com/Pedejeca135)

## Licencia
[MIT](https://github.com/theupdateframework/specification/blob/master/LICENSE-MIT.txt)

Puedes usar parcial o totalmente el codigo en otros proyectos y repositorios.
