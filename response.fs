: c           s @ c@ ;
: -eos        s @ end @ < ;
: -eon        c 32 > -eos and ;
: name        s @ begin -eon while 1 s +! repeat s @ over - ;
: macro       1 s +! name sfind if execute then ;
: ch          c [char] ~ over xor if c, else drop macro then 1 s +! ;
: expand      begin -eos while ch repeat ;

variable response
here response !  expand  response @ here over - type

