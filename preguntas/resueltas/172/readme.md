### QUESTION 172 

##### Hash  OJO __ES UNA ERRATA__

You are developing a method named GetHash that will return a hash value for a file. The method includes the
following code. (Line numbers are included for reference only.)

```c#
01  public static byte[] GetHashA(string filename, string algorithmType)
02  {
03    var hasher = HashAlgorithm.Create(algorithmType);
04    var fileBytes = System.IO.File.ReadAllBytes(filename);
05
06  }

````
You need to return the cryptographic hash of the bytes contained in the fileBytes variable.
Which code segment should you insert at line 05?


Opcion A
```c#
var outputBuffer = new byte[fileBytes.Length];
hasher.TransformBlock(fileBytes, 0, fileBytes.Length, outputBuffer, 0);
hasher.TransformFinalBlock(fileBytes, fileBytes.Length - 1, fileBytes.Length);
return outputBuffer;
````
Opcion B
```c#
hasher.ComputeHash(fileBytes);
return hasher.GetHashCode();
````
Opcion C
```c#
var outputBuffer = new byte[fileBytes.Length];
hasher.TransformBlock(fileBytes, 0, fileBytes.Length, outputBuffer, 0);
return (outputBuffer);
````
Opcion D
```c#
hasher.ComputeHash(fileBytes);
return (hasher.Hash);
````

Respuesta: A INCORRECTA!!!!!!!!!!!!!!!!!!   

La Respuesta Correcta es la __D__  (puedes verificarlo con el codigo (FrameWork4.8 Visual Strudio)   
__Opcion D__  

__hasher.ComputeHash(fileBytes);__  
__return (hasher.Hash);__  


Explicación:  
La A da error en TransformFinalBlock (filebytes, desplazamiento, cantidaddebytes ) ya que desplazimiento + cantidaddebytes se nos va de longitud.  
De todas formas sin el código TransformFinalBlock la salida outputBuffer no ha sido hasheada.  

La B da error ya que el return de hasher.GetHashCode(); es un entero  devuelve Código hash para el objeto actual.  


La C es erronea ya que la salida outputBuffer no ha sido hasheada.  

La D es la correcta lo que pasa es que no se que seguro es ya que utilza como secret key cadena vacia.  





Recordemos como el método Hash  
```` c#
public byte[] ComputeHash(byte[] dataToHash, byte[] secretKey)
{
   using (var hashAlgorithm = new HMACSHA1(secretKey))
   {
      using (var bufferStream = new MemoryStream(dataToHash))
      {
         return hashAlgorithm.ComputeHash(bufferStream);
      }
   }
}
````




![errata text](errata.PNG)


nota: public static Item FindItem (int ? id); significa que id puede ser un entero o nulo

