: gosAddrs   gosAddrsBlock 1024 * ;
: addrsEnd   gosAddrsBlock /column + 1024 * ;
: -free      dup x@32 $FFFFFFFF xor if exit then  gosAddrs - r> r> 2drop ;
: -end       dup addrsEnd u< if exit then  r> drop ;
: used       begin -end -free 4 + again ;
: full       gosAddrs used drop ;
: alloc      full -1 abort" Out of GOS handles" ;

