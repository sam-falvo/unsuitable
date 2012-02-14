80 constant /wB
/wB 1 - constant /wB-1

create wordBuffer
  /wB allot

: bEmit    c, ;
: bType    begin dup while over c@ emit 1 /string repeat 2drop ;
: >buf     ['] bEmit is emit  ['] bType is type ;
: >con     ['] (emit) is emit  ['] (type) is type ;

: eat      len @ if 1 src +!  -1 len +! then ;
: -eoi     len @ if exit then  r> drop ;
: -ws      src @ c@ $21 u< if r> drop then ;
: nws      begin -eoi -ws eat again ;
: def      src @ nws src @ over - eat ;
: eoi      ." (( unexpected end of input ))" ;
: missing  ." (( macro " count type ."  not found ))" ;
: invoke   dup wordBuffer c!  wordBuffer 1+ swap /wB-1 min move
           wordBuffer find if execute else missing then ;
: macro    eat def dup if invoke else 2drop eoi then ;
: -'~'     dup [char] ~ xor if exit then  drop macro r> drop ;
: ch       src @ c@ -'~' emit eat ;
: expand   begin -eoi ch again ;

