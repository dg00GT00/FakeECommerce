# Procedure for testing the Payment Controller

- Set up the stripe webhook cli with the following command, replacing the $SECRET_TEST_KEY with your stripe secret test
  key:

```bash
docker run --network host --rm -it stripe/stripe-cli listen -f https://localhost:5001/api/payments/webhook --skip-verify --api-key $SECRET_TEST_KEY
```

- Make requests from client application