include mappings.fs
: >>10  10 rshift ;

: gos0      gorg gend begin 2dup < while over >>10 block 1024 32
            fill update swap 1024 + swap repeat 2drop flush ;

: gosh0     addrs lens begin 2dup < while over >>10 block 1024
            -1 fill update swap 1024 + swap repeat 2drop flush ;

: all0      gos0 gosh0 ;
