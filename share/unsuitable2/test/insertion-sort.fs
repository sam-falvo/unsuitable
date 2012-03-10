warnings off
marker done

\ --- vacate
100 constant N
create buf  	N cells allot

variable tss \ unused for this test
variable ids \ unused for this test

include ../lib/insertion-sort.fs

: init 		dup 1+ over cells buf + ! ;
: s		0 begin dup N u>= if drop exit then  init 1+ again ;
: /=n		dup 1+ over cells buf + @ xor if r> drop then ;
: 1..24/=1..24  0 begin dup 24 u>= if r> 2drop exit then  /=n 1+ again ;
: 25/=empty     24 cells buf + @ $FFFFFFFF = if r> drop then ;
: /=n-1 	dup dup cells buf + @ xor if r> drop then ;
: 26..N/=25..N-1   25 begin dup N u>= if r> 2drop exit then  /=n-1 1+ again ;

: t120.0	s 24 buf vacate  1..24/=1..24  -1 abort" t120.0" ;
: t120.1	s 24 buf vacate  25/=empty  -1 abort" t120.1" ;
: t120.2	s 24 buf vacate  26..N/=25..N-1  -1 abort" t120.2" ;

: t120		t120.0 t120.1 t120.2 ;
t120

: 1..N-2/=1..N-2  0 begin dup N 2 - u>= if r> 2drop exit then  /=n 1+ again ;
: N-1/=empty	N 1- cells buf + @ $FFFFFFFF = if r> drop then ;

: t121.0	s N 1- buf vacate  1..N-2/=1..N-2  -1 abort" t121.0" ;
: t121.1	s N 1- buf vacate  N-1/=empty  -1 abort" t121.1" ;
: t121  	t121.0 t121.1 ;
t121

done

\ --- insertion sort

marker done

5 constant N
create ids 	N cells allot
create tss 	N cells allot

create emptyBuf
	$FFFFFFFF , $FFFFFFFF , $FFFFFFFF , $FFFFFFFF , $FFFFFFFF ,

create ids-exp
	1000 , $FFFFFFFF , $FFFFFFFF , $FFFFFFFF , $FFFFFFFF ,
create tss-exp
	9 , $FFFFFFFF , $FFFFFFFF , $FFFFFFFF , $FFFFFFFF ,

: clr   	emptyBuf ids N cells move  emptyBuf tss N cells move ;

include ../lib/insertion-sort.fs

: s		clr 1000 9 insert ;
: t122.0	s ids N cells ids-exp N cells compare abort" t122.0" ;
: t122.1	s tss N cells tss-exp N cells compare abort" t122.1" ;
: t122		t122.0 t122.1 ;
t122

done marker done

5 constant N
create ids	N cells allot
create tss	N cells allot

create ids-m
	100 , 90 , 80 , 70 , 60 ,
create tss-m
	10 , 9 , 8 , 7 , 6 ,

create ids-exp1
	100 , 90 , 1000 , 80 , 70 ,
create tss-exp1
	10 , 9 , 9 , 8 , 7 ,

create ids-exp2
	100 , 90 , 80 , 70 , 60 ,
create tss-exp2
	10 , 9 , 8 , 7 , 6 ,

include ../lib/insertion-sort.fs

: reset 	ids-m ids N cells move  tss-m tss N cells move ;
: s1		reset 1000 9 insert ;
: t123.0	s1 ids N cells ids-exp1 N cells compare abort" t123.0" ;
: t123.1	s1 tss N cells tss-exp1 N cells compare abort" t123.1" ;
: t123		t123.0 t123.1 ;
t123

: s2		reset 1000 2 insert ;
: t124.0	s2 ids N cells ids-exp2 N cells compare abort" t124.0" ;
: t124.1 	s2 tss N cells tss-exp2 N cells compare abort" t124.1" ;
: t124		t124.0 t124.1 ;
t124

done

