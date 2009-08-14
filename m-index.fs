#! /usr/bin/env gforth

." Content-type: text/html" cr cr

require mappings.fs
require general.fs
require articles.fs
require time.fs

: respond   here swap dup allot move ;
require latest-5.fs
: last-five-posts   scan latest ;

variable h
: open  S" theme/index.html" r/o open-file throw h ! ;
: close h @ close-file throw ;
: grab  begin here 65536 h @ read-file throw dup allot 0= until ;
: slurp open grab close ;

variable s
variable end
here s ! slurp here end !
include response.fs
bye

