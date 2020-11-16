#!/bin/sh

input=$(dirname $0)/create_user.json

# Test Basket controller post method 

curl \
-d "@$input" \
-H 'Content-Type: application/json; charset=UTF-8' \
--cacert $HOME/CA/sub-ca/certs/sub-ca.crt \
--http2 -v "https://localhost:5001/api/account/register" | python3 -m json.tool