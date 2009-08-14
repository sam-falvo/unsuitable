#! /usr/bin/env gforth

S" PATH_INFO" getenv constant /path-info constant &path-info

: |url|>=2  /path-info 2 u< if s" index.fs" included bye then ;
|url|>=2

&path-info /path-info + constant end-of-url
&path-info 1+ constant module

: -eou   dup end-of-url >= if r> drop then ;
: -/     dup c@ [char] / = if r> drop then ;
: slash  begin -eou -/ char+ again ;
module slash constant &parameters

: base        module &parameters over - here swap dup allot move ;
: extension   S" .fs" here swap dup allot move ;
: filename    base extension ;
: dispatch    here filename here over - included ;
dispatch bye

