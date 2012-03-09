: bytes 	cells >r cells buf + >r cells buf + r> r> ;
: shift 	dup 1+ N over - bytes move ;
: empty 	cells buf + $FFFFFFFF swap ! ;
: -bounds 	dup N u< if dup shift empty r> drop then ;
: vacate 	-bounds -1 abort" E020 Attempt to vacate beyond buffer bounds" ;

