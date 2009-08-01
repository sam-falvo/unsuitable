#! /usr/bin/env gforth

." Content-type: text/html" cr cr

: respond         2dup here swap move  allot drop ;
: last-five-posts S" No posts exist in the database." respond ;

variable h
: open  S" blog-templates/index.html" r/o open-file throw h ! ;
: close h @ close-file throw ;
: grab  begin here 65536 h @ read-file throw dup allot 0= until ;
: slurp open grab close ;

variable s
variable end
here s ! slurp here end !
include response.fs
bye

