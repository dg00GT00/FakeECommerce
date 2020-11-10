#!/bin/sh

input=$(dirname $0)/post_basket.json

# Test Basket controller post method 

curl \
-d "@$input" \
-H 'Content-Type: application/json; charset=UTF-8' \
--cacert ~/LocalHostCertificate/myCA.pem \
--http2 -v "https://localhost:5001/api/basket" | python3 -m json.tool | echo