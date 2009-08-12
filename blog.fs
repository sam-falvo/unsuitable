#! /usr/bin/env gforth

S" PATH_INFO" getenv constant /path-info constant &path-info

: default   S" index.fs" included bye ;
: chk  /path-info 2 u< if default then ;
chk

&path-info /path-info + constant end
&path-info 1+ constant token
: path   dup end >= if r> drop then ;
: slash  dup c@ [char] / = if r> drop then ;
: name   begin path slash char+ again ;
: base   token dup name over - here swap dup allot move ;
: extension   S" .fs" here swap dup allot move ;
: filename   base extension ;
: module   here filename here over - included ;
module bye

