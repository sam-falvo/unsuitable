#! /usr/bin/env gforth

." Content-type: text/html" cr cr

: respond         over + begin 2dup < while over c@ c, swap char+ swap repeat 2drop ;
: last-five-posts S" No posts exist in the database." respond ;

variable h
: open  S" blog-templates/index.html" r/o open-file throw h ! ;
: close h @ close-file throw ;
: grab  begin here 65536 h @ read-file throw dup allot 0= until ;
: slurp open grab close ;

variable template
variable #template
here template ! slurp here template @ - #template !

variable end
variable s
: >string     over + end ! s ! ;
: c           s @ c@ ;
: -eos        s @ end @ < ;
: -eon        c 32 > -eos and ;
: name        s @ begin -eon while 1 s +! repeat s @ over - ;
: macro       1 s +! name sfind if execute then ;
: ch          c [char] ~ over xor if c, else macro then 1 s +! ;
: expand      >string ( s <= end ) begin -eos while ch repeat ( s = end ) ;

variable response
variable #response
here response !
template @ #template @ expand
here response @ - #response !

response @ #response @ type

bye

