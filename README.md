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


### Selected Node States (Estados de seleccion de nodo)

### Operations (operaciones):
Son las operaciones que se pueden realizar sobre el grafo mediante el uso del mouse,si es que estan activadas.

A continuacion se muestra una tabla que especifica las distintas operaciones que se pueden realizar cuando estan activadas.

#### Move (M):
Se pueden mover cada uno de los nodos individualmente.
#### Move All (A):
Se puede mover todo el grafo a la vez.
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

### View (vista):

### Boxes:

#### Graph Information Box:

#### Node Selected Information Box:

#### Matrix Representation Box:

### Algoritmos:

#### DFS:
#### BFS:
#### Kruskal:
#### Prim:
#### Warshall:
#### Floyd:
#### Dijkstra:
#### Caminos de Euler:
#### Caminos de Hamilton:
#### Isomorfismo:

## Versiones

Cuenta con varias versiones. Para mas informacion revisar los [tags](https://github.com/Pedejeca135/Gigamesh2D) en la seccion de Branchs.

## Autoría

* **Pedro Cantú** [Pedejeca135](https://github.com/Pedejeca135)

## Licencia
[MIT](https://github.com/theupdateframework/specification/blob/master/LICENSE-MIT.txt)

Puedes usar parcial o totalmente el codigo en otros proyectos y repositorios.
