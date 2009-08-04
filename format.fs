include mappings.fs
: >>10  10 rshift ;
: call  >r ;
: eachBlock begin 2dup < while over >>10 block r@ call swap
            1024 + swap update repeat 2drop flush r> drop ;

: gos0      gorg gend eachBlock 1024 32 fill ;
: gosh0     addrs /hfields over + eachBlock 1024 -1 fill ;
: rows0     articleIds /afields over + eachBlock 1024 -1 fill ;
: articles0 rows0 a-nextId off update ;

: all0      gos0 gosh0 articles0 ;
