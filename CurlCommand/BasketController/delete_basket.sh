#!/bin/sh

# Test Basket controller delete method 

curl -X DELETE \
--cacert ~/LocalHostCertificate/myCA.pem \
--http2 -v "https://localhost:5001/api/basket?id=basket2" | python3 -m json.tool | echo