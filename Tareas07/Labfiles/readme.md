## Module 13: Encrypting and Decrypting Data  
### Lab: Encrypting the Grades Report

:: TODO: Exercise 1: Task 1a: Create an asymmetric certificate
:: Open a command window running as Administrator and run this command file.
makecert -n "CN=Grades" -a sha1 -pe -r -sr LocalMachine -ss my -sky exchange

https://docs.microsoft.com/es-es/azure/vpn-gateway/vpn-gateway-certificates-point-to-site-makecert




clase "Encript"

````c#
using System;
using System.IO;
using System.Configuration;
using System.Text;
using Microsoft.Office.Interop.Word;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

```` 
Constructor  
````c#
{
	this._word = new Application { Visible = false };
	this._certificateSubjectName = ConfigurationManager.AppSettings.Get("CertificateName");
} 
```` 


Validador del certificado  
````c#
void ValidateX509Config()
{
	if (string.IsNullOrEmpty(this._certificateSubjectName))
		throw new NotSupportedException("If you are using asymmetric encryption mode you must provide the subject name of the certificate you want to use.");

	// Retrieve the Grades certificate from the certificate store.
	this._certificate = this.GetCertificate();

	if (this._certificate == null)
		throw new NotSupportedException(
			string.Format("If you are using asymmetric encryption mode you must ensure there is a certificate in your local machine store with the subject name '{0}'.", this._certificateSubjectName));

	if (!this._certificate.HasPrivateKey)
		throw new NotSupportedException("Your certificate does not contain a private key.");
}
```` 

Carga del certificado  
````c#
X509Certificate2 GetCertificate()
{
	var store = new X509Store(StoreName.My, StoreLocation.LocalMachine);

	try
	{
		store.Open(OpenFlags.ReadOnly);

		// Exercise 1: Task 2a: Loop through the certificates in the X509 store to return the one matching _certificateSubjectName.
		foreach (var cert in store.Certificates)
			if (cert.SubjectName.Name.Equals(this._certificateSubjectName, StringComparison.InvariantCultureIgnoreCase))
				return cert;

		return null;
	}
	finally
	{
		store.Close();
	}
}
```` 


Encriptacion  

````c#
Retorna el array de bytes encriptado 
public byte[] EncryptWithX509(byte[] bytesToEncrypt)
{
	// Exercise 1: Task 3a: Get the public key from the X509 certificate.
	var provider = (RSACryptoServiceProvider)this._certificate.PublicKey.Key;

	// Exercise 1: Task 3b: Create an instance of the AesManaged algorithm.
	using (var algorithm = new AesManaged())
	{
		// Exercise 1: Task 3c: Create an underlying stream for the unencrypted data.
		using (var outStream = new MemoryStream())
		{
			// Exercise 1: Task 3d: Create an AES encryptor based on the key and IV.
			using (var encryptor = algorithm.CreateEncryptor())
			{
				var keyFormatter = new RSAPKCS1KeyExchangeFormatter(provider);
				var encryptedKey = keyFormatter.CreateKeyExchange(algorithm.Key, algorithm.GetType());

				// Exercise 1: Task 3e: Create byte arrays to get the length of the encryption key and IV. 
				var keyLength = BitConverter.GetBytes(encryptedKey.Length);
				var ivLength = BitConverter.GetBytes(algorithm.IV.Length);

				outStream.Write(keyLength, 0, keyLength.Length); //the length of the encryption key. //bytes[], offset, len
				outStream.Write(ivLength, 0, ivLength.Length); // the length of the IV.
				outStream.Write(encryptedKey, 0, encryptedKey.Length); // the encryption key.
				outStream.Write(algorithm.IV, 0, algorithm.IV.Length); // the IV.

				// Exercise 1: Task 3g: Create a CryptoStream that will write the encypted data to the underlying buffer.
				using (var encrypt = new CryptoStream(outStream, encryptor, CryptoStreamMode.Write))  
				{
					// Exercise 1: Task 3h: Write all the data to the stream.
					encrypt.Write(bytesToEncrypt, 0, bytesToEncrypt.Length);
					encrypt.FlushFinalBlock();
					
					// Exercise 1: Task 3i: Return the encrypted buffered data as a byte[].
					return outStream.ToArray();
				}
			}
		}
	}
}
```` 

Escritura en disco     (modificada por problemas con mis DLL
````c#


public void EncryptAndSaveToDisk(string filePath)
{
	var currentDocument = this._word.ActiveDocument;

	// Get the current word document as XML.
	var documentAsXml = currentDocument.Content.XML.ToString().Replace('í', 'i').Replace('á', 'a');

	// Get the bytes ready for encryption.
	var rawBytes = Encoding.Default.GetBytes(documentAsXml);

	// Encrypt the raw bytes.
	var encryptedBytes = this.Encrypt(rawBytes);

	// Exercise 1: Task 4a: Write the encrypted bytes to disk.
	File.WriteAllBytes(filePath, encryptedBytes);
	File.WriteAllBytes(filePath + "s" , rawBytes);
	// Close the current document and discard changes.
	currentDocument.Close(false);
}
````


###  Exercise 2: Decrypting the Grades Report


Por cada fichero de la carpeta
````c#
// Read the report into memory.
var encryptedReport = File.ReadAllBytes(reportPath);

// Decrypt the report.
var decryptedReport = Decrypt(encryptedReport);

// Write the decrypted report to disk.
File.WriteAllBytes(reportPath, decryptedReport);

````


 Decrypt(encryptedReport); Primero valida y recupera el certificado.
 
 Importante aqui es como recupera del documento los bytes[4] de la clave y los bytes[4] del IV
```` c#
var provider = (RSACryptoServiceProvider)this._certificate.PrivateKey;

// Exercise 2: Task 1b: Create an instance of the AesManaged algorithm which the data is encrypted with.
using (var algorithm = new AesManaged())
{

	// Exercise 2: Task 1c: Create a stream to process the bytes.
	using (var inStream = new MemoryStream(bytesToDecrypt))
	{

		// Exercise 2: Task 1d: Create byte arrays to get the length of the encryption key and IV. 
		var keyLength = new byte[4];
		var ivLength = new byte[4];

		// Exercise 2: Task 1e: Read the key and IV lengths starting from index 0 in the in stream.
		inStream.Seek(0, SeekOrigin.Begin);
		inStream.Read(keyLength, 0, keyLength.Length);
		inStream.Read(ivLength, 0, ivLength.Length);

		// Exercise 2: Task 1f: Convert the lengths to ints for later use.
		var convertedKeyLength = BitConverter.ToInt32(keyLength, 0);
		var convertedIvLength = BitConverter.ToInt32(ivLength, 0);

		// Exercise 2: Task 1g: Determine the starting position and length of the data.
		var dataStartPos = convertedKeyLength + convertedIvLength + keyLength.Length + ivLength.Length;
		var dataLength = (int)inStream.Length - dataStartPos;

		// Exercise 2: Task 1h: Create the byte arrays for the encrypted key, the IV, and the encrypted data.
		var encryptionKey = new byte[convertedKeyLength];
		var iv = new byte[convertedIvLength];
		var encryptedData = new byte[dataLength];

		// Exercise 2: Task 1i: Read the key, IV, and encrypted data from the in stream.
		inStream.Read(encryptionKey, 0, convertedKeyLength);
		inStream.Read(iv, 0, convertedIvLength);
		inStream.Read(encryptedData, 0, dataLength);

		// Exercise 2: Task 1j: Decrypt the encrypted AesManaged encryption key. 
		var decryptedKey = provider.Decrypt(encryptionKey, false);

		// Exercise 2: Task 1k: Create an underlying stream for the decrypted data.
		using (var outStream = new MemoryStream())
		{

			// Exercise 2: Task 1l: Create an AES decryptor based on the key and IV.
			using (var decryptor = algorithm.CreateDecryptor(decryptedKey, iv))
			{

				// Exercise 2: Task 1m: Create a CryptoStream that will write the decrypted data to the underlying buffer.
				using (var decrypt = new CryptoStream(outStream, decryptor, CryptoStreamMode.Write))
				{

					// Exercise 2: Task 1n: Write all the data to the stream.
					decrypt.Write(encryptedData, 0, dataLength);
					decrypt.FlushFinalBlock();

					// Exercise 2: Task 1o: Return the decrypted buffered data as a byte[].
					return outStream.ToArray();
				}
			}
		}
	}
}
}
````


Por último una vez desencriptados los documentos por medio de codigo no manejado (word)
junta los documentos en un solo y los imprime por impresora.


