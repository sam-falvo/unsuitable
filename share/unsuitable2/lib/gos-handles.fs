\ Allocate a new GOS handle

: gosAddrs   gosAddrsBlock 1024 * ;
: addrsEnd   gosAddrsBlock /column + 1024 * ;
: -free      dup x@32 $FFFFFFFF xor if exit then  gosAddrs - r> r> 2drop ;
: -end       dup addrsEnd u< if exit then  r> drop ;
: used       begin -end -free 4 + again ;
: full       gosAddrs used drop ;
: alloc      full -1 abort" Out of GOS handles" ;

\ Set a GOS handle

: gosLens    gosLensBlock 1024 * ;
: offset!    gosAddrs + x!32 ;
: length!    gosLens + x!32 ;
: 4divisible dup 3 and abort" E001: Invalid GOS handle" ;
: range      dup /column u>= abort" E002: Invalid GOS handle" ;
: +hnd       4divisible range ;
: 0<n<=/spc  dup 0= abort" E003: Invalid GOS blob length"
             dup /gos-space u> abort" E004: Invalid GOS blob length" ;
: 0<=n</spc  dup /gos-space u< 0= abort" E005: Invalid GOS offset" ; 
: +len       >r 0<n<=/spc r> ;
: +ofs       >r >r 0<=n</spc r> r> ;
: set        +ofs +len +hnd swap over length! offset! ;

