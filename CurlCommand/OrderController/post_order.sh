#!/bin/sh

input=$(dirname $0)/post_order.json

curl \
-d "@$input" \
-H 'Content-Type: application/json; charset=UTF-8' \
-H 'Authorization: Bearer eyJhbGciOiJIUzUxMiIsInR5cCI6IkpXVCJ9.eyJlbWFpbCI6ImJvYkB0ZXN0LmNvbSIsImdpdmVuX25hbWUiOiJCb2IiLCJuYmYiOjE2MDU3ODg4MzIsImV4cCI6MTYwNTc5NjAzMiwiaWF0IjoxNjA1Nzg4ODMyLCJpc3MiOiJodHRwczovL2xvY2FsaG9zdDo1MDAxIn0.OAyiPaDApLP_T13mscl1O2KI-gQ4VF4YlPiRMsn7njfhskMpPF9-Z3NKvagZQ0M0ldbEyfEGYdZ-s_Q74g9IpQ' \
--cacert $HOME/CA/sub-ca/certs/sub-ca.crt \
--http2 -v "https://localhost:5001/api/orders" | python3 -m json.tool