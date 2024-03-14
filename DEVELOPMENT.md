# Design 

![System diagram](https://github.com/WallysFerreira/Sorveteria/assets/105322824/b667f228-4ceb-47d5-994d-546e1bc9c821)

## Services

### Purchases

Stores all purchases made on the website.

All requests to this service must: 

- have an userID cookie
- have an authToken cookie

The session must be validated with the Auth service before doing anything.

#### Purchase object

```json
{
    "ID": string,
    "products": [Product],
    "created-at": time,
    "userID": string,
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
    "ID": string,
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
    "ID": string,
    "name": string,
    "password": string,
}
```

#### createAccount(account)

Stores a new account in the database. Used for signup

#### validateAccount(account)

Checks if an account with matching name and password exists on the database.

Used for login.

The value of ID in the object will be null.

#### deleteAccount()

Deletes an account from the database.

Used to delete the account that is logged in.

Requests must have:

- A valid token in the authToken cookie.
- An ID in the userID cookie that is the same as the account ID being deleted.

### Auth

Used to guarantee authenticity for users.

Uses a Redis database to store 6 characters long random string as key and the accountID as value.

#### Token object

```json
{
    "authToken": string,
    "accountID": string,
}
```

#### generateToken(token)

Generates a 6 characters long random string and stores it as key on a key-value database with the accountID as value.

Used on login.

authToken on request token object is null.

#### validateToken(token)

Checks if the token is currently on the database and the accountID is the same.

#### deleteToken(token)

Checks that the accountID matches and then deletes the token from the database.

## Action examples

### User login

![Login diagram](https://github.com/WallysFerreira/Sorveteria/assets/105322824/84106c26-7e24-4d9c-8f05-f0123e61f7d2)

### Accessing pages

![Accessing_pages diagram](https://github.com/WallysFerreira/Sorveteria/assets/105322824/1423e802-b480-47c0-a0ba-1c274e3f79c1)

