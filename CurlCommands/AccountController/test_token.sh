#!/usr/bin/env bash

input=$(dirname $0)/user_login.json

source $HOME/RiderProjects/eCommerce/CurlCommands/shared_jwt_token.sh

curl \
-H 'Content-Type: application/json; charset=UTF-8' \
-H "Authorization: Bearer $token" \
--cacert $HOME/CA/sub-ca/certs/sub-ca.crt \
--http2 -v "https://localhost:5001/api/account" | python3 -m json.tool