# Procedure for testing the eCommerce WebAPI

### Using Curl Commands:

#### Managing customer baskets and orders

- Logging as a user
- Get the JWT which came from the response body and paste in the share token bash script
- Create a basket without _deliveryMethodId_, _clientSecret_ and _paymentIntendId_ properties
- Post this modified basket to the correct route
- Post a payment indent with to the correspondent basket id
- If needed update a payment indent, head over to the response body receive from the payment intent request and post
  another basket with the _deliveryMethodId_, _clientSecret_ and _paymentIntendId_ fields populated with the received
  data from previous request
- Resend a payment intend with the updated basket data

#### Managing users

- Use curl commands at `CurlCommands/AccountController` to test the functionalities

#### Managing payment

- Testing the payment functionality should be done via client application. See for
  the [payment testing procedure](../eCommerce/Controllers/Testing Payment.md)