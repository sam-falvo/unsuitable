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

done

