### Módulo 12: Creación de tipos y ensamblajes reutilizables

### Lección 1: Examinar los metadatos de los objetos

#### Demostración: Ensambles de inspección

1. añadir namespace System.Reflection

usign System.Reflection;

2. Crear un objeto assembly

````
private Assembly GetAssembly(string path)
{
	// TODO: 02: Create an Assembly object. 
	return Assembly.ReflectionOnlyLoadFrom(path);

}
`````

3. Obtener todos los tipos de la tarea de ensamblaje actual 

````
private Type[] GetTypes(string path)
{
	var assembly = this.GetAssembly(path);

	// TODO: 03: Get all the types from the current assembly. 
	return assembly.GetTypes();


}
`````
4. Obtener un tipo específico de la tarea de ensamblaje actual .
````
        private Type GetType(string path, string typeName)
        {
            var assembly = this.GetAssembly(path);

            // TODO: 04: Get a specific type from the current assembly. 
            return assembly.GetType(typeName);


        }
````

![insepeccion1](./insepeccion1.PNG)