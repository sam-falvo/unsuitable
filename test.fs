#! /usr/bin/env gforth

." Content-type: text/html" cr cr
.\" <html><head><title>HI!</title></head><body><table width=\"100%\"><tr><th>ENV VAR NAME</th><th>ENV VAR VALUE</th><th>ENV VAR LEN</th></tr>"
: r ." <tr><td>" type ." </td><td>" 2dup type ." </td><td>" . drop ." </td></tr>" ;
S" REQUEST_METHOD" getenv S" REQUEST_METHOD" r
S" REMOTE_ADDR" getenv S" REMOTE_ADDR" r
S" SCRIPT_NAME" getenv S" SCRIPT_NAME" r
S" PATH_INFO" getenv S" PATH_INFO" r
S" SERVER_PROTOCOL" getenv S" SERVER_PROTOCOL" r
S" QUERY_STRING" getenv S" QUERY_STRING" r
." </table></body></html>"

bye

