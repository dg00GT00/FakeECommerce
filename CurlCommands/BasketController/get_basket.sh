#!/bin/sh

curl \
  -H 'Content-Type: application/json; charset=UTF-8' \
  --cacert $HOME/CA/sub-ca/certs/sub-ca.crt \
  --http2 -v "https://localhost:5001/api/basket?id=basket1" | python3 -m json.tool
