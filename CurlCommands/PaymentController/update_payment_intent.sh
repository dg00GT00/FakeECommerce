#!/bin/sh

input=$(dirname $0)/update_payment_intent.json

curl \
  -X POST \
  -d "@$input" \
  -H 'Content-Type: application/json; charset=UTF-8' \
  --cacert $HOME/CA/sub-ca/certs/sub-ca.crt \
  --http2 -v "https://localhost:5001/api/basket" | python3 -m json.tool
