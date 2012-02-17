: upper         dup $61 u>= over $67 u< and if $20 xor then ;
: value         upper [char] 0 - dup 9 u> if 7 - then ;
: eat           1- swap 1+ swap ;
: hexdgt        over c@ value >r eat r> ;
: hexchr        hexdgt 4 lshift >r hexdgt r> or ;
: -%            dup [char] % = if drop eat hexchr r> drop then ;
: -+            dup [char] + = if drop eat $20 r> drop then ;
: translate     -+ -% >r eat r> ;
: ch            over c@ translate c, ;
: decode        begin dup while ch repeat 2drop ;
: urldecode     here -rot  decode   here over - ;

