variable h
create b   	4096 allot

: chunk		b 4096 h @ read-file throw
		dup if b swap type else r> 2drop then ;
: copy 		begin chunk again ;
: contents	r/o open-file throw h ! copy h @ close-file throw ;

