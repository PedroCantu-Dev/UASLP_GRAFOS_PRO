# GRAFOS_PRO

Un editor de grafos en c# (windows forms). El editor de grafos permite crear grafos visualmente y generar archivos que los representan. Utiliza una estructura de listas para representar las aristas.

![editor Presentacion](https://user-images.githubusercontent.com/44269967/134715454-d9c4f09b-e8c8-431c-91b7-a8501e0760dd.PNG)



## Requisitos para correr el proyecto:

El proyecto esta hecho en Windows Forms por lo que se necesitara tener [Visual Studio](https://visualstudio.microsoft.com/es/free-developer-offers) , el cual está disponible para windows y IOS.

* Windows [Visual Studio Download](https://visualstudio.microsoft.com/es/free-developer-offers)

* IOS [Visual Studio Download](https://visualstudio.microsoft.com/es/free-developer-offers).

## Clonar el proyecto:

### Clonar el proyecto desde github:

En esta pagina del proyecto dentro de github puedes facilmente descargar el proyecto en un archivo zip, al descomprimirlo e ingresar a la carpeta encontraremos un archivo 
*.sln (editorGrafos.sln) 


![download zip](https://user-images.githubusercontent.com/44269967/134695997-35c5c780-ae53-4980-ba27-b89c59d8e45d.gif)



el archivo *.sln (editorGrafos.sln), es el archivo de la solucion, para ingresar a ella se tiene que hacer doble click en este archivo, ya con el visual studio instalado, esto nos 
habre la solucion y podemos ver sus archivos y editarlos, asi mismo debugear el proyecto.

![editor sln](https://user-images.githubusercontent.com/44269967/134696847-ec0b5813-30be-43ce-8dd5-bdf024457237.gif)


### Clonar el proyecto con Git:
A mi parecer clonar el proyecto desde terminal de comandos siempre acaba siendo mas sencillo y practico. Necesitas tener [git](https://git-scm.com/) instalado en tu ordenador lo mas facil es usar "git bash" pero cualquier terminal de comandos puede hacer la tarea siempre y cuando las variables de etorno correctamente configuradas.




#### clonar el repositorio:
Primero sitearse sobre una carpeta en la que pueda estar el proyecto y despues simplemente ingresar en linea de comandos el siguiente comando:

```
$ git clone https://github.com/Pedejeca135/GRAFOS_PRO
```
![image](https://user-images.githubusercontent.com/44269967/134713951-d6ee9a5d-5b03-43c5-ab0e-2f1ac256f02d.png)


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

### Boxes:
Estos son cajas de texto que especifican el estado y caracteristicas del grafo y de los nodos en "tiempo real".

#### Graph Information Box:
Esta caja especifica informacion del grafo en cuestion, 

#### Node Selected Information Box:

#### Matrix Representation Box:

## Operaciones sobre el grafo y los nodos.
Las operaciones se refieren a todos los metodos basicos para trabajar con los nodos, estos van desde la creacion y eliminacion de nodos, generacion de aristas, etc.

### Selected Node States (Estados de seleccion de nodo):
Cualquier nodo puede ser selccionado, estos cuentan con tres estados de sleccion aciva, a continuacion se detallan las operaciones queestos estados pemiten hacer sobre el nodo.


![NodeSelectionStates2](https://user-images.githubusercontent.com/44269967/134720120-bb7bbd76-2689-4f6e-96ca-a9237fb09ec5.gif)


#### State 0 - Black:
![image](https://user-images.githubusercontent.com/44269967/134719052-48c1e802-649d-4ba3-91ac-d9e54522a2b6.png)

Es el estado inicial de los nodos.
Solo un nodo puede ser selecionadoa la vez, cando haya alguno su informacion aparecera en lacaja de infomacion de nodo seleccionado.
![image](https://user-images.githubusercontent.com/44269967/134719538-1cb9154a-d956-47d3-aef2-58879e5396ec.png)

##### Any
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



### Operations (operaciones):
Son las operaciones que se pueden realizar sobre el grafo mediante el uso del mouse,si es que estan activadas.
Las operaciones son mutuamente excluyentes y cuando son activadas se deselecciona cualquier nodo.

A continuacion se muestra una tabla que especifica las distintas operaciones que se pueden realizar cuando estan activadas.

#### Move (M):
Se pueden mover cada uno de los nodos individualmente con los botones izquierdo y derecho.
![Move_M_Operation](https://user-images.githubusercontent.com/44269967/134717821-14e9f9da-071c-4a3e-9884-10ace13076f4.gif)

#### Move All (A):
Se puede mover todo el grafo a la vez con el boton izquierdo y derecho.
![MoveAll_A_Operation](https://user-images.githubusercontent.com/44269967/134717838-6e99b2d8-39ee-4e6f-af8b-74ec4802efb1.gif)

#### Remove (R):
Se pueden eliminar cada nodo individualmente
![Remove_R_Operation](https://user-images.githubusercontent.com/44269967/134717854-76710021-9f91-49fe-8ff7-dd29fef6f942.gif)

#### MoRe (F):
Viene de Move-Remove. Los nodos se mueven con boton izquierdo del mouse y se eliminan con el boton derecho individualmente.
![MoRe_F_Operation](https://user-images.githubusercontent.com/44269967/134717869-6fef26f9-248e-4477-a7e6-1518de89d90b.gif)

#### Linking (L):
Se pueden hacer enlaces **no dirigidos** con el boton izquerdo y **dirigidos** con el boton derecho.

##### Linking Undirected(U):
Se pueden hacer enlaces **no dirigidos** con cualquier boton.

##### Linking Directed (D):
Se pueden hacer enlaces **dirigidos** con cualquier boton


### Truncated weight(Peso truncado):
![image](https://user-images.githubusercontent.com/44269967/134716314-0ec3f583-c59a-4e46-af81-c82f60c7e588.png)

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

Cuenta con varias versiones. Para mas informacion revisar los [tags](https://github.com/Pedejeca135/GRAFOS_PRO/tags) en la seccion de Branchs.

## Autoría

* **Pedro Cantú** [Pedejeca135](https://github.com/Pedejeca135)

## Licencia
[MIT](https://github.com/theupdateframework/specification/blob/master/LICENSE-MIT.txt)

Puedes usar parcial o totalmente el codigo en otros proyectos y repositorios.
