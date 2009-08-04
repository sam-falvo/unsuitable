: >core     dup 10 rshift block swap 1023 and + ;
: blocks    1024 * ;
: @f        >core @ ;
: !f        >core ! update ;

( block 1 = meta-block )
: g-fencepost   1 block ;
: a-nextId      1 block [ 1 cells ] literal + ;

( blocks 2 .. 65 = general object store )
2 blocks constant gorg
gorg 64 blocks + constant gend

( blocks 66 .. 67 = handle table for general object store )
1 blocks constant /hfields
66 blocks constant addrs
addrs /hfields + constant lens

( blocks 68 .. = article table columns )
2 blocks constant /afields
68 blocks constant articleIds
articleIds /afields + constant titles
titles /afields + constant leads
leads /afields + constant bodies
bodies /afields + constant timestamps

