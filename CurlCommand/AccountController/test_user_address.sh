#!/bin/sh

curl \
-H 'Content-Type: application/json; charset=UTF-8' \
-H 'Authorization: Bearer eyJhbGciOiJIUzUxMiIsInR5cCI6IkpXVCJ9.eyJlbWFpbCI6ImJvYkB0ZXN0LmNvbSIsImdpdmVuX25hbWUiOiJCb2IiLCJuYmYiOjE2MDU2NTg4MjQsImV4cCI6MTYwNTY2NjAyNCwiaWF0IjoxNjA1NjU4ODI0LCJpc3MiOiJodHRwczovL2xvY2FsaG9zdDo1MDAxIn0.pWm51YqhQ0gwhkx3mgcjwlrHDZ7sQUOQGsSXVVckzqh-olPuU4JeDgQxI6V-QKPbly9nnpDbFNWFqvZE5vC9og' \
--cacert $HOME/CA/sub-ca/certs/sub-ca.crt \
--http2 -v "https://localhost:5001/api/account/address" | python3 -m json.tool