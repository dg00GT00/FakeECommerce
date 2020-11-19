#!/bin/sh

input=$(dirname $0)/post_order.json

curl \
-d "@$input" \
-H 'Content-Type: application/json; charset=UTF-8' \
-H 'Authorization: Bearer eyJhbGciOiJIUzUxMiIsInR5cCI6IkpXVCJ9.eyJlbWFpbCI6ImJvYkB0ZXN0LmNvbSIsImdpdmVuX25hbWUiOiJCb2IiLCJuYmYiOjE2MDU3MzkyODMsImV4cCI6MTYwNTc0NjQ4MywiaWF0IjoxNjA1NzM5MjgzLCJpc3MiOiJodHRwczovL2xvY2FsaG9zdDo1MDAxIn0.RUwQE5Up8F5lpWZJVfR5PdESN74OTFZCVYHE2j4FdmlMqbLLgRWeen6pXKEyHIxEPLb7ZwyXgGSJG7d6y6yAwQ' \
--cacert $HOME/CA/sub-ca/certs/sub-ca.crt \
--http2 -v "https://localhost:5001/api/orders" | python3 -m json.tool