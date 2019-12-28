# AfipCert
 Genera y convierte de manera fácil certificados SSL para el uso en AFIP. La idea es permitir que usuarios no técnicos de Windows puedan generar sus certificados sin problemas y sin necesidad de ingresar comandos en la terminal. El programa es una automatización del proceso de [generación de certificados](http://www.afip.gov.ar/ws/WSAA/cert-req-howto.txt) para la [utilización en Webservices](https://www.afip.gob.ar/ws/WSAA/WSAA.ObtenerCertificado.pdf).

## Uso.

- Ejecutar AfipCert.exe
- Para generar un certificado:
  - Seleccionar la pestaña Generar.
  - Seleccionar el directorio donde se van a guardar los certificados (clave privada y CSR).
  - Rellenar la información de todos los campos.
  - Hacer click en el botón "Generar".
- Para convertir un certificado CRT a formato PFX:
  - Seleccionar la pestaña Convertir.
  - Seleccionar el directorio donde se va a guardar el archivo convertido.
  - Seleccionar el archivo CRT.
  - Completar y confirmar la contraseña que va a utilzar el certificado PFX.
  - Hacer click en el botón "Convertir"

## Contacto.

Para ideas o sugerencias pueden visitarnos en [logico](https://logico.ar).
