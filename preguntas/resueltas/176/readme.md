### QUESTION 176 

##### excepcciones

You are developing an application in C#.  
The application uses exception handling on a method that is used to execute mathematical calculations by using integer numbers.  
You write the following catch blocks for the method (line numbers are included for reference only):  
 

```c#
01
02 catch (ArithmeticException e) {Console.WriteLine("Arithmetic Error");}
03
04 catch (ArgumentException e) {Console.WriteLine("Bad Argument");}
05
06 catch (Exception e) {Console.WriteLine("General Error");}
07
````

You need to add the following code to the method:
 catch (DivideByZeroException e) {Console.WriteLine("Divide By Zero");}

At which line should you insert the code?
A. 01   
B. 03  
C. 05  
D. 07  





Respuesta: A 01



Si quieres controlar DivideByZero debes ponerla delante de ArithmeticException ya que sino el manejador de ArithmeticException atrapará dicha excepcion
De hecho daría el siguiennte error de compilación  
Program.cs(34,20): error CS0160: Una cláusula catch previa ya detecta todas las excepciones de este tipo o de tipo superior ('DivideByZeroException') [D:\20_610\20483\20483_TAREAS\preguntas\pendientes\176\176.csproj]


````c#
 public void division(decimal divisor, decimal dividendo)
        {

            try
            {
                Console.WriteLine(divisor / dividendo);
            }
            catch (DivideByZeroException e) { Console.WriteLine("Divide By Zero" + e.Message); }
            catch (ArithmeticException e) { Console.WriteLine("Arithmetic Error " + e.Message); }
            catch (ArgumentException e) { Console.WriteLine("Bad Argument" + e.Message); }
            catch (Exception e) { Console.WriteLine("General Erro" + e.Message); }
        }
    }
}
````
