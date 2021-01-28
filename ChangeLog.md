# eCommerce Project Changelog

### 069f97244bab3d4d6b851b8058246ca5531f7872

- One order per user because the orders are bound to user email

### 8406905277ecef25c69d8af6e8398802f3d55815

- One basket per order
- One basket per user login
- The user can only checkout another basket after the previous basket status is **PaymentSuccess**
- After the successful payment operation, the correspondent basket must be deleted from cache database 
