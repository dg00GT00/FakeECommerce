#!/usr/bin/env bash

curl \
-H 'Content-Type: application/json; charset=UTF-8' \
--cacert $HOME/CA/sub-ca/certs/sub-ca.crt \
--http2 -v "https://localhost:5001/api/account/emailexists?email=bob@test.com" | python3 -m json.tool