# Máquina de Turing - Simulador

## Sintaxis
- La máquina de turing es case sensitive.
- El caracter en blanco se representa como `_`.
- En la tabla de transiciones debe existir al menos una transición que tenga como 'Estado siguiente' un 'estado de aceptado'.
- Se entiende como 'estado de aceptado' una cadena que contenga 'accept'.
- Se entiende como 'estado de rechazado' una cadena que contenga 'reject'.
- Cada fila de la tabla de transiciones consta de:
    - Estado: una cadena de texto libre (`q0`, `q1`, `0`,`cero`).
    - Leer: un caracter libre (`0`, `1`, `_`).
    - Escribir: un caracter libre (`0`, `1`, `_`).
    - Dirección: un caraceter (`L`, `R`).
    - Estado siguiente: una cadena de texto libre (`q0`, `q1`, `0`,`cero`,`accept`,`qaccept`,`qreject`).
       
## Sección 'Configuración'

### Campos de texto
- Entrada: cadena de texto a procesar.
- Salida: cadena de texto procesada.
- Estado final: estado final de la ejecución.
- Pasos: cantidad de pasos que se hicieron para llegar al estado final.
- Estado inicial: se comenzará la ejecución en este estado.
- Velocidad: es la velocidad (representada en segundos) del intervalo de tiempo entre la ejecución de cada transición.
- Ejemplos: son ejemplos precargados. Cargan automaticamente la tabla de transiciones y una entrada.

### Botones
- Generar: genera la máquina de turing a partir de los datos cargados. Cada vez que haya un cambio en la configuración es necesario generar la máquina de turing nuevamente.
- Editar: habilita los campos de configuración para poder editarlos. Al finalizar es necesario presionar 'Generar' para guardar los cambios.
- Limpiar: limpia todos los campos de la sección 'configuración' (incluso la tabla de transiciones). 

## Sección 'Acciones'
- Correr: comienza la ejecución hasta encontrar un estado que contenga la cadena 'accept'. La velocidad entre cada transición está definida por el campo 'Velocidad'. Para pausar la ejecución se puede presionar 'Pausar'.
- Siguiente: ejecuta una sola transición. Si encuentra un estado 'accept' lo notifica.
- Pausar: pausa la ejecución.
- Detener: regresa la máquina de turing a su estado inicial.
