: >core     dup 10 rshift block swap 1023 and + ;
: blocks    1024 * ;

( block 1 = meta-block )
: g-fencepost   1 block ;

( blocks 2 .. 65 = general object store )
2 blocks constant gorg
gorg 64 blocks + constant gend

( blocks 66 .. 67 = handle table for general object store )
1 blocks constant /hfields
66 blocks constant addrs
addrs /hfields + constant lens

