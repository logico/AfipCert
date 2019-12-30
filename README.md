# AfipCert
Genera y convierte de manera fácil certificados SSL para el uso en AFIP. La idea es permitir que usuarios no técnicos de Windows puedan generar sus certificados sin problemas y sin necesidad de ingresar comandos en la terminal. El programa es una automatización del proceso de [generación de certificados](http://www.afip.gov.ar/ws/WSAA/cert-req-howto.txt) para la [utilización en Webservices](https://www.afip.gob.ar/ws/WSAA/WSAA.ObtenerCertificado.pdf).

Visita el micrositio en [afipcert.logico.ar](https://afipcert.logico.ar)


## Uso.

- Ejecutar AfipCert.exe
- Para generar un certificado:
  - Seleccionar la pestaña Generar.
  - Seleccionar el directorio donde se van a guardar los certificados (clave privada y CSR) haciendo click en el botón "..." de la sección **Carpeta de salida**.
  - Rellenar la información de todos los campos.
  - Hacer click en el botón "Generar".
- Para convertir un certificado CRT o PEM a formato PFX:
  - Seleccionar la pestaña Convertir.
  - Seleccionar la ubicación de la clave privada haciendo click en el botón "..." de la sección **Clave privada**.
  - Seleccionar la ubicación del certificado CRT o PEM haciendo click en el botón "..." de la sección **Certificado AFIP**.
  - Seleccionar la ubicación de donde se va a guardar el certificado exportado haciendo click en el botón "..." de la sección **Carpeta de salida**.
  - Ingresar el nombre del certificado PFX.
  - Completar y confirmar la contraseña que va a utilzar el certificado PFX.
  - Hacer click en el botón "Convertir"

## Información para desarrolladores.

La aplicación es un frontend de OpenSSL. Para evitar tener que instalarlo y/o tener que elevar los permisos para su ejecución, AfipCert utiliza los [binarios de OpenSSL](https://bintray.com/vszakats/generic/openssl) que son llamados desde dos archivos batch (generar.bat y convertir.bat) con los parametros recopilados. Estos archivos batch deben estar en el mismo directorio que AfipCert, openssl.exe y openssl.cnf para funcionar.

## Contacto.

Por ideas o sugerencias pueden visitarnos en [logico](https://logico.ar/contacto).
