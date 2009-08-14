#! /usr/bin/env gforth

S" PATH_INFO" getenv constant /path-info constant &path-info

: |url|>=2  /path-info 2 u< if s" m-index.fs" included bye then ;
|url|>=2

&path-info /path-info + constant end-of-url
&path-info 1+ constant module

: -eou   dup end-of-url >= if r> drop then ;
: -/     dup c@ [char] / = if r> drop then ;
: slash  begin -eou -/ char+ again ;
module slash constant &parameters

: path        [char] m c, [char] - c, ;
: base        module &parameters over - here swap dup allot move ;
: extension   S" .fs" here swap dup allot move ;
: filename    path base extension ;
: dispatch    here filename here over - included ;
dispatch bye

