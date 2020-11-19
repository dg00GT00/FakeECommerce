#!/usr/bin/env bash

input=$(dirname $0)/register_user.json

curl \
-d "@$input" \
-H 'Content-Type: application/json; charset=UTF-8' \
--cacert $HOME/CA/sub-ca/certs/sub-ca.crt \
--http2 -v "https://localhost:5001/api/account/register" | python3 -m json.tool