#! /usr/bin/env gforth

." Content-type: text/html" cr cr

variable h
: open  S" blog-templates/index.html" r/o open-file throw h ! ;
: close h @ close-file throw ;
: grab  begin here 65536 h @ read-file throw dup allot 0= until ;
: slurp open grab close ;

variable out
variable #out
here out ! slurp here out @ - #out !
out @ #out @ type

bye

