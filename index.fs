#! /usr/bin/env gforth

." Content-type: text/html" cr cr

: respond         over + begin 2dup < while over c@ c, swap char+ swap repeat 2drop ;
: last-five-posts S" No posts exist in the database." respond ;

variable h
: open  S" blog-templates/index.html" r/o open-file throw h ! ;
: close h @ close-file throw ;
: grab  begin here 65536 h @ read-file throw dup allot 0= until ;
: slurp open grab close ;

variable s
variable end
here s ! slurp here end !

: >string     over + end ! s ! ;
: c           s @ c@ ;
: -eos        s @ end @ < ;
: -eon        c 32 > -eos and ;
: name        s @ begin -eon while 1 s +! repeat s @ over - ;
: macro       1 s +! name sfind if execute then ;
: ch          c [char] ~ over xor if c, else drop macro then 1 s +! ;
: expand      begin -eos while ch repeat ;

variable response
here response !  expand  response @ here over - type

bye

