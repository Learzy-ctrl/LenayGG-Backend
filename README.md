# Gestor de Gastos - API

Esta es una API para gestionar gastos personales utilizando una arquitectura limpia. La API permite realizar operaciones de autenticación, gestión de transacciones, gestión de usuarios y de wallets.

**URL de la API**: [https://lenaygg-backend.onrender.com/](https://lenaygg-backend.onrender.com/)

## Tabla de Contenidos

- [Características](#características)
- [Arquitectura](#arquitectura)
- [Uso](#uso)
- [Endpoints](#endpoints)
  - [Login](#login)
  - [Transaction](#transaction)
  - [User](#user)
  - [Wallet](#wallet)
- [Contribuciones](#contribuciones)
- [Licencia](#licencia)

## Características

- Registro e inicio de sesión de usuarios.
- Gestión de transacciones (ingresos, gastos y transferencias).
- Creación y administración de wallets.
- Cambios de email y contraseña de usuarios.
- Recuperación de contraseña.

## Arquitectura

Este proyecto utiliza **Arquitectura Limpia** para facilitar la escalabilidad y el mantenimiento del código. La estructura principal del código se divide en varias capas:

- **Domain**: Contiene las entidades de negocio y las interfaces.
- **Application**: Incluye los casos de uso y la lógica de negocio.
- **Infrastructure**: Implementa las interfaces y maneja las conexiones con la base de datos y otros servicios externos.
- **API**: Define los controladores y los endpoints expuestos.

## Uso

La API expone endpoints para realizar diversas operaciones, agrupadas en las siguientes categorías: Login, Transaction, User y Wallet. A continuación, se detallan los endpoints disponibles.

## Endpoints

### Login

- `POST /api/Login/SignUp`: Registra un nuevo usuario.
- `POST /api/Login/SignIn`: Inicia sesión para un usuario existente.
- `POST /api/Login/ResetPassword`: Recupera la contraseña de un usuario.

### Transaction

- `POST /api/Transaction/AddGasto`: Agrega una nueva transacción de gasto.
- `POST /api/Transaction/AddIngreso`: Agrega una nueva transacción de ingreso.
- `POST /api/Transaction/AddTransferencia`: Agrega una transferencia entre wallets.
- `POST /api/Transaction/GetTransaccionesByIdWallet`: Obtiene las transacciones de un wallet específico.
- `POST /api/Transaction/GetTransaccionesByIdUsuario`: Obtiene todas las transacciones de un usuario.
- `POST /api/Transaction/GetCategorias`: Obtiene las categorías de transacciones.

### User

- `POST /api/User/UploadImage`: Sube una imagen de perfil de usuario.
- `POST /api/User/UpdateUser`: Actualiza la información del usuario.
- `POST /api/User/GetUser`: Obtiene la información de un usuario.
- `POST /api/User/DeleteUser`: Elimina un usuario.
- `POST /api/User/ChangeUserEmail`: Cambia el email de un usuario.
- `POST /api/User/ChangeUserPassword`: Cambia la contraseña de un usuario.

### Wallet

- `POST /api/Wallet/AddWallet`: Agrega un nuevo wallet.
- `POST /api/Wallet/GetWallets`: Obtiene los wallets de un usuario.
- `POST /api/Wallet/GetWalletById`: Obtiene un wallet específico por su ID.
- `POST /api/Wallet/UpdateWallet`: Actualiza un wallet existente.
- `POST /api/Wallet/DeleteWallet`: Elimina un wallet.


