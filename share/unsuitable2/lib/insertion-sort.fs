\ Predefined words expected:
\ N	( - n )		Number of cells in the column buffer(s)
\ tss	( - addr ) 	Buffer at least N cells long, holding timestamps
\ ids	( - addr )	Buffer at least N cells long, holding article IDs

variable b

: bytes 	cells >r cells b @ + >r cells b @ + r> r> ;
: shift 	dup 1+ N over - bytes move ;
: empty 	cells b @ + $FFFFFFFF swap ! ;
: -bounds 	dup N u< if dup shift empty r> drop then ;
: vacate 	b ! -bounds -1 abort" E020 Attempt to vacate beyond buffer bounds" ;

variable ts
variable id

: @tss		cells tss + @ ;
: !tss		cells tss + ! ;
: @ids		cells ids + @ ;
: !ids		cells ids + ! ;

: -end		dup N u>= if r> drop then ;
: ins		ts @ over !tss  id @ swap !ids ;
: -empty	dup @ids $FFFFFFFF xor if exit then ins r> drop ;
: hole		dup tss vacate  dup ids vacate ;
: -less		dup @tss ts @ u>= if exit then hole ins r> drop ;
: i0 		0 begin -end -empty -less 1+ again ;
: insert 	ts ! id ! i0 ;

