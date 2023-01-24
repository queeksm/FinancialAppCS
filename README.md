Este proyecto fue desarrollado siguiendo las pautas dadas por la prueba tecnica del equipo de Quind.

Es un RESTFUL API con arquitectura hexagonal de una aplicacion financiera.

Fue desarrollada en C# y con .Net 6.0

Nugets usados:
    -EntityFrameworkCore
    -EntityFrameworkCore.SqlServer
    -Extensions.Configurations
    -Extensions.Configurations.Json

Se probo con Postman y con Swagger UI.

Database:
    -SqlServer.

Instrucciones:

    -Primero debemos entrar a FinanceApp.Infrastructure.Data
    -Luego Buscamos el archivo appconfig.Json
    -Editamos "DefaultConnectionString" agregando nuestra connection string.
    -Ejecutamos Program.cs para inicializar la base de datos y las tablas.

API:

/api/Client POST:
    Crea un nuevo cliente con el siguiente formato JSON;

{
    "idType": "string",
    "numberId": int,
    "nameClient": "string",
    "surnameClient": "string",
    "clientEmail": "string",
    "birthDate" : yyyy-mm-ddThh:mm:ss // Debe ser mayor a 18 para crear un cliente.   

}

El resto de los campos se crearan automaticamente y se actualizaran al ejecutar otras

/api/Client GET:

    Muestra una lista de todos los clientes.

/api/Client/{id} GET:
    Muestra un Cliente especificamente por su ID.

/api/Client/{id} PUT:
    Edita un cliente por su ID

{
    "idType": "string",
    "numberId": int,
    "nameClient": "string",
    "surnameClient": "string",
    "clientEmail": "string",
    "birthDate" : yyyy-mm-ddThh:mm:ss // Debe ser mayor a 18 para crear un cliente.   

}

/api/Client/{id} Delete:
    Elimina un cliente.


/api/Account GET:
    Muestra todas las transacciones existentes.

/api/Account Post:

    Requiere de un clientId como parametro para crearse.

{
    "accountType": int // 0 para ahorros, 1 para corriente
} 

/api/Account/{id} GET:
    Muestra una Cuenta por id.

/api/Account/{id} PUT:
    habilita o inhabilita la cuenta por id.

/api/Account/{id} Delete:
    Cancela la cuenta.

/api/Transactions GET:
    Obtiene una lista de todas las transacciones

/api/Transactions POST:
    Crea una nueva transaccion usando "account" como parametro, este es un GUID que se obtiene de las accounts en ID.
Parameter Account : "Guid"
{ 
  "transactionType": "string",
  "amount": 0,
  "receiverAccount": "GUID",  
}

Existen solo 3 tipos de transacciones, "Deposit", "Whitdrawal", "Transfer"
Tanto para deposit y withdrawal el metodo es el mismo, tanto en parameter como en receiverAccount ponemos el mismo GUID.
Para transfer ponemos La cuenta desde la que deseamos enviar el dinero en Parameter, y la que debe recibir en receiverAccount.




/api/Transactions/{id} GET:
    Muestra una transaccion por id