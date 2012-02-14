variable h
create b        4096 allot

: append        dup >r here swap move r> allot ;
: chunk         b 4096 h @ read-file throw
                dup if b swap append else r> 2drop then ;
: copy          begin chunk again ;
: contents      r/o open-file throw h ! copy h @ close-file throw ;

