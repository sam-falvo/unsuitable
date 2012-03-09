warnings off
marker done

\ --- insertion
100 constant N
create buf  	N cells allot

include ../lib/insertion-sort.fs

: init 		dup 1+ over cells buf + ! ;
: s		0 begin dup N u>= if drop exit then  init 1+ again ;
: /=n		dup 1+ over cells buf + @ xor if r> drop then ;
: 1..24/=1..24  0 begin dup 24 u>= if r> 2drop exit then  /=n 1+ again ;
: 25/=empty     24 cells buf + @ $FFFFFFFF = if r> drop then ;
: /=n-1 	dup dup cells buf + @ xor if r> drop then ;
: 26..N/=25..N-1   25 begin dup N u>= if r> 2drop exit then  /=n-1 1+ again ;

: t120.0	s 24 vacate  1..24/=1..24  -1 abort" t120.0" ;
: t120.1	s 24 vacate  25/=empty  -1 abort" t120.1" ;
: t120.2	s 24 vacate  26..N/=25..N-1  -1 abort" t120.2" ;

: t120		t120.0 t120.1 t120.2 ;
t120

: 1..N-2/=1..N-2  0 begin dup N 2 - u>= if r> 2drop exit then  /=n 1+ again ;
: N-1/=empty	N 1- cells buf + @ $FFFFFFFF = if r> drop then ;

: t121.0	s N 1- vacate  1..N-2/=1..N-2  -1 abort" t121.0" ;
: t121.1	s N 1- vacate  N-1/=empty  -1 abort" t121.1" ;
: t121  	t121.0 t121.1 ;
t121

\ --- insertion sort

done

