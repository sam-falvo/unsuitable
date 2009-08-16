variable h
: open    r/o open-file throw h ! ;
: close   h @ close-file throw ;
: grab    begin here 65536 h @ read-file throw dup allot 0= until ;
: slurp   open grab close ;

