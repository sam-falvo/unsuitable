warnings off
marker done

: blocks        2* ;
: articleIds    0 ;
: titles        16 ;
: abstracts     32 ;
: bodies        48 ;
: timestamps    64 ;
: /artDbColumn  16 ;

create testBuf
        1 , 2 , 3 , 4 ,
        -1 , -1 , -1 , -1 ,
        -1 , -1 , -1 , -1 ,
        -1 , -1 , -1 , -1 ,
: x@32          testBuf + @ $FFFFFFFF and ;
: x!32		testBuf + ! ;

: artDbId@ 	drop 1 ;
: artDbId!	drop ;
include ../lib/articles-db.fs

: t110.0        3 search 0= abort" t110.0" ;
: t110.1        6 search abort" t110.1" ;
: t110.2        -1 search 0= abort" t110.2" ;
: t110.3        3 search drop offset @ 8 xor abort" t110.3" ;
: t110.4        -1 search drop offset @ 16 xor abort" t110.4" ;
: t110.5	articlesFree 12 xor abort" t110.5" ;
: t110          t110.0 ( t110.1 ( t110.2 ( t110.3 ( t110.4 ( t110.5 ( ) ;
t110

done marker done

create buf	8 cells allot

8 cells constant /artDbColumn
: blocks ;
buf constant articleIds
: x@32 		@ $FFFFFFFF and ;
: x 		2dup c!  1+ swap 8 rshift swap ;
: x!32		x x x x 2drop ;
: reset 	buf 8 cells $FF fill  1 8 buf + x!32 2 16 buf + x!32 4 20 buf + x!32 ;
: artDbId@ 	;
: artDbId!	drop ;

1 constant titles
1 constant abstracts
1 constant bodies
1 constant timestamps

include ../lib/articles-db.fs

variable v
variable c
: testproc	v @ or v !  1 c +! ;
: s		0 v ! 0 c ! reset ['] testproc perform allArticles ;
: t130.0	s c @ 3 xor abort" t130.0" ;
: t130.1	s v @ 7 xor abort" t130.1" ;
: t130 		t130.0 t130.1 ;
t130

done


