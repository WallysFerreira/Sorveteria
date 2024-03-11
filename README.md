# Sorveteria

A study about the microservices architecture.

## Stack

- C# (.NET)
- Java (Spring)
- NextJS
- RabbitMQ
- Redis
- MariaDB

## Services

![System diagram](https://github.com/WallysFerreira/Sorveteria/assets/105322824/fb746c95-a00a-4fb4-8fa0-7cc4e5b07048)

### Purchases

Stores all purchases made on the website.

All requests to this service must: 

- have an userID cookie
- have an authToken cookie

The session must be validated with the Auth service before doing anything.

#### Purchase object

```json
{
    "ID": ID of purchase,
    "products": [list of products],
    "created-at": time,
    "userID": ID of user who made the purchase,
}
```

#### getUserPurchases(userID)

Fetches purchases from an specific user by it's ID.

#### createPurchase(purchase)

Stores a new purchase in the database.

#### deletePuchase(purchaseID)

Deletes a purchase from the database.

### Products

Deals with all products displayed on the products page of the website.

All requests to this service must: 

- have an userID cookie
- have an authToken cookie

The session must be validated with the Auth service before doing anything.

#### Product object

```json
{
    "ID": ID of product,
    "name": string,
    "price": float,
    "category": string, 
}
```

#### getProducts()

Fetches all products from the database.

#### createProduct(product)

Stores a new product in the database.

#### deleteProduct(productID)

Deletes a product from the database.

### Accounts

Mainly takes care of user signup and login.

#### Account object

```json
{
    "ID": account ID,
    "name": string,
    "password": string,
}
```

#### createAccount(account)

Stores a new account in the database. Used for signup

#### getAccount(account)

Retrieves an account from the database if an account with the name exists and passwords match.

Used for login.

The value of ID in the object will be null.

#### deleteAccount(accountID)

Deletes an account from the database.

Used to delete the account that is logged in.

Requests must have:

- A valid token in the authToken cookie.
- An ID in the userID cookie that is the same as the account ID being deleted.

### Auth

## Equipe
- Aira Soares
- Gleice Santos
- Hugo Davi
- Thayssa Alexandre
- Wallys Ferreira
