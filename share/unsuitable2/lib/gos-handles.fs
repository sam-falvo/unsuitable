\ Allocate a new GOS handle

: gosAddrs              gosAddrsBlock blocks ;
: addrsEnd              gosAddrsBlock /column + blocks ;
: >handle               2/ 2/ ;
: -free                 dup x@32 $FFFFFFFF xor if exit then  gosAddrs - >handle r> r> r> 2drop drop ;
: -end                  dup addrsEnd u< if exit then  r> drop ;
: used                  begin -end -free 4 + again ;
: full                  gosAddrs used drop ;
: alloc                 full -1 abort" E000: Out of GOS handles" ;

\ Set a GOS handle

: gosLens               gosLensBlock blocks ;
: offset!               gosAddrs + x!32 ;
: length!               gosLens + x!32 ;
: range                 dup /column blocks u>= abort" E002: Invalid GOS handle" ;
: handle>               2* 2* range ;
: 0<n<=/spc             dup 0= abort" E003: Invalid GOS blob length"
                        dup /gos-space u> abort" E004: Invalid GOS blob length" ;
: 0<=n</spc             dup /gos-space u< 0= abort" E005: Invalid GOS offset" ; 
: +len                  >r 0<n<=/spc r> ;
: +ofs                  >r >r 0<=n</spc r> r> ;
: +span                 >r 2dup + /gos-space u> abort" E006: Invalid GOS blob length" r> ;
: set                   +ofs +len +span handle> swap over length! offset! ;

\ Check to see if at least one open article slot exists.

: -free                         dup x@32 $FFFFFFFF = if swap 1+ swap then ;
: all                           begin -end -free 4 + again ;
: freeCount                     0 gosAddrs all drop ;
: gosHandlesAvailable?          freeCount u<= ;

