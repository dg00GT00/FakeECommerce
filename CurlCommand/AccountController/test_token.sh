#!/bin/sh

input=$(dirname $0)/user_login.json

curl \
-H 'Content-Type: application/json; charset=UTF-8' \
-H 'Authorization: Bearer eyJhbGciOiJIUzUxMiIsInR5cCI6IkpXVCJ9.eyJlbWFpbCI6ImJvYkB0ZXN0LmNvbSIsImdpdmVuX25hbWUiOiJCb2IiLCJuYmYiOjE2MDU2NTEyNjcsImV4cCI6MTYwNTY1ODQ2NywiaWF0IjoxNjA1NjUxMjY3LCJpc3MiOiJodHRwczovL2xvY2FsaG9zdDo1MDAxIn0.Z5jp939LTF323iVS8V_Z-MzH-IMAKv64Whd9LIa0cmNelLYHbfT6jlEsObiKE3suo6y63YfStzxrQaDXXRqB_Q' \
--cacert $HOME/CA/sub-ca/certs/sub-ca.crt \
--http2 -v "https://localhost:5001/api/buggy/testauth" | python3 -m json.tool