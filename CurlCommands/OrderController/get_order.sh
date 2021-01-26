#!/usr/bin/env bash

source $HOME/Vscode/FakeECommerce/CurlCommands/shared_jwt_token.sh

curl \
-H "Content-Type: application/json; charset=UTF-8" \
-H "Authorization: Bearer $token" \
--cacert $HOME/CA/sub-ca/certs/sub-ca.crt \
--http2 -v "https://localhost:5001/api/orders/1" | python3 -m json.tool