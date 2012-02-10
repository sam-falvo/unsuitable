: core   dup 10 rshift block swap 1023 and + ;
: x      8 lshift over c@ 255 and or swap -1 + swap ;
: x@32   core 3 + 0 x x x x nip ;
: y      2dup c! 1+ swap 8 rshift swap ;
: x!32   core y y y y 2drop update ;
