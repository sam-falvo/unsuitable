: h! ( h a -- )   2dup c! 1+ swap 8 rshift swap c! ;
: w! ( h a -- )   2dup h! 2 + swap 16 rshift swap h! ;

: h@ ( a -- h )   dup c@ swap 1+ c@ 8 lshift or ;
: w@ ( a -- w )   dup h@ swap 2 + h@ 16 lshift or ;

: >core     dup 10 rshift block swap 1023 and + ;
: blocks    1024 * ;
: sx32      dup $80000000 and 0= 0= -$80000000 and or ;
: @f32	    >core w@ sx32 ;
: !f32      >core w! update ;
: word+     4 + ;

( block 1 = meta-block )
: g-fencepost   1 block ;
: a-nextId      1 block [ 1 cells ] literal + ;

( blocks 2 .. 65 = 64K unused space -- formerly general object store )

\ /hfields determines the total number of articles that can be stored in the GOS.
\     1 blocks constant /hfields
\     ^-- 1 blocks == 1024 bytes.  Each GOS address is 4 bytes wide.  Thus,
\	  1024 bytes / 4 bytes/addr = 256 addresses.
\ Thus, a 1KB addrs column only supports up to 256 articles in the blog.

1 blocks constant /hfields

( blocks 66, 67 = handle table for general object store )
66 blocks constant addrs
addrs /hfields + constant lens

( blocks 68 .. 77 = article table columns )
2 blocks constant /afields
68 blocks constant articleIds
articleIds /afields + constant titles
titles /afields + constant leads
leads /afields + constant bodies
bodies /afields + constant timestamps

( blocks 256 .. 511 = General Object Store [256K version] )
256 blocks constant gorg
gorg 512 blocks + constant gend


( Static Configuration Parameters )
: *domain*      S" localhost" ;
: *path:code*   S" /cgi-bin" ;
: *path:theme*  S" /theme" ;

