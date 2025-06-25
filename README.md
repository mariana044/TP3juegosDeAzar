# Tarea Programada 3 - Juegos de Azar

**Curso:** Programación Avanzada  
**Código:** SC-601  
**Profesor:** Luis Andrés Rojas Matey  
**Estudiante:** Mariana Hidalgo De La O  
**Carné:** FH23015127  

---

## Descripción

Este programa de consola permite gestionar productos de juegos de azar de forma interactiva, aplicando la técnica **Code First** con **Entity Framework 6** y **.NET Framework 4.8.1**.

El usuario puede:
- Ingresar productos (como Lotto, Chances, etc.)
- Generar números aleatorios asociados a cada producto
- Decidir si los números se repiten
- Guardar esta información en una base de datos (`TP3`)
- Visualizar todos los productos con sus números, ordenados por fecha de creación

---

## Repositorio
https://github.com/mariana044/TP3juegosDeAzar.git

---

## Recursos consultados

- [Microsoft Docs - DbContext Class](https://learn.microsoft.com/en-us/dotnet/api/system.data.entity.dbcontext)
- [Stack Overflow - Random sin repetición](https://stackoverflow.com/questions/273313/randomize-a-listt)
- [W3Schools - C# Collections](https://www.w3schools.com/cs/cs_arrays.php)
- ChatGPT

---

## Prompts de ChatGPT

**Prompt:**  
*¿Cómo valido que los números aleatorios no se repitan en una lista en C#?*  
**Respuesta:**  
Se puede usar una lista para almacenar los generados y un bucle `do-while` que repita la generación hasta encontrar un número que no esté en la lista:  
```csharp
do {
  numero = rand.Next(0, 100);
} while (lista.Contains(numero));
```
**Prompt:**  
*¿Cómo guardo un objeto con una colección relacionada en Entity Framework 6 usando Code First? Por ejemplo, un Producto que contiene una lista de Números.*  

**Respuesta:**  
Para guardar una entidad con relaciones, se puede construir la colección manualmente y asignarla a la propiedad de navegación. Luego basta con agregar solo el objeto padre (`Producto`), y EF6 guardará automáticamente los hijos (`Numeros`) gracias al seguimiento de cambios.

```csharp
var producto = new Producto
{
    Nombre = nombre,
    FechaHoraCreacion = DateTime.Now,
    Numeros = new List<Numero>
    {
        new Numero { Orden = 1, Valor = 25 },
        new Numero { Orden = 2, Valor = 77 }
    }
};

db.Productos.Add(producto);
db.SaveChanges();
```
