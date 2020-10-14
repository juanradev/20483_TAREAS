## Módulo 3: Desarrollo del código para una aplicación gráfica
### Laboratorio: Redacción del código para la aplicación del prototipo de calificaciones




Antes de nada vamos a ver como creamos delegados y eventos
```c#
public struct Coffee
{
   public EventArgs e;																/* defnico los eventsargs */
   public delegate void OutOfBeansHandler(Coffee coffee, EventArgs args);           /* defino el delegado (clase o estructura, eventargs) */
   public event OutOfBeansHandler OutOfBeans;										/* defino el evento nombredeldelgado evento evento OutOfBeans asociado a OutOfBeansHandler*/
}
  
```
Provocando eventos
1. Comprobar si el evento es nulo (si no hay ningún código suscrito actualmente).
2.- Invocar al evento si se cumple alguna condición.
```c#
public struct Coffee
{
   // Declare the event and the delegate. ******************** Paso anterior 
   public EventArgs e = null;
   public delegate void OutOfBeansHandler(Coffee coffee, EventArgs args);
   public event OutOfBeansHandler OutOfBeans;
  
   int currentStockLevel;
   int minimumStockLevel;

   public void MakeCoffee() /// ****************************** funcion que decrementa el cafe 
   {
      // Decrement the stock level.
      currentStockLevel--;
      // If the stock level drops below the minimum, raise the event.
      if (currentStockLevel < minimumStockLevel) /// ******************* si no hy existencias
      {
         // Check whether the event is null. // verifico si hay codigo subscrito y lo lanzo
         if (OutOfBeans != null)
         {
            // Raise the event.
            OutOfBeans(this, e);   //  evento (instancia actual , argumentos)
         }
      }
   }
}
''''

Por último si queremos que haya código que haga algo debo crear un método que coincia con la firma del delgado
y subscribirme


````xaml

public class Inventory
{
  public void HandleOutOfBeans(Coffee sender, EventArgs args)
   {
      string coffeeBean = sender.Bean;
      // Reorder the coffee bean.
   }
   public void SubscribeToEvent()
   {
      coffee1.OutOfBeans += HandleOutOfBeans;
   }
      public void DeSubscribeToEvent()
   {
      coffee1.OutOfBeans -= HandleOutOfBeans;
   }

}
````





Ejercicio 1: Adición de lógica de navegación a la aplicación de prototipo de calificaciones

. Revisar las siguientes vistas:
        LogonPage.xaml
        StudentProfile.xaml
        StudentsPage.xaml

Definir el evento LogonSuccess y agregar código ficticio para el evento Logon_Click

En la vista LogonPage 
Defnir el controlador de eventos LogonSuccess
Implementar el controlador de eventos Logon_Click para la tarea del botón Logon
Añadir el evento al onclick del boton

```c#
public event EventHandler LogonSuccess;


 private void Logon_Click(object sender, RoutedEventArgs e)
 {
     // Save the username and role (type of user) specified on the form in the   global context
     SessionContext.UserName = username.Text;
     SessionContext.UserRole = (bool)userrole.IsChecked ? Role.Teacher : Role.Student;

     // If the role is Student, set the CurrentStudent property in the global    context to a dummy student; Eric Gruber
     if (SessionContext.UserRole == Role.Student)
     {
         SessionContext.CurrentStudent = "Eric Gruber";
     }

     // Raise the LogonSuccess event
     if (LogonSuccess != null)
     {
         LogonSuccess(this, null);
     }
 }

'''
'''xaml
<Button Grid.Row="3" Grid.ColumnSpan="2" VerticalAlignment="Center" HorizontalAlignment="Center" Content="Log on" FontSize="24" 
Click="Logon_Click" />
Click="Logon_Click"
'''
