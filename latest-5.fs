create e0  5 cells allot
e0 4 cells + constant e4
e4 cell+ constant e5
variable ep
variable r

: insert   ep @ dup cell+ over e4 swap - move ;
: nil      ep @ @ -1 = if r @ ep @ ! r> drop then ;
: eol      ep @ e5 >= if r> drop then ;
: Te<Tr    ep @ @ article! timestamp r @ article! timestamp <
           if insert r @ ep @ ! r> drop then ;
: Te>=Tr   [ 1 cells ] literal ep +! ;
: sort     e0 ep ! begin eol nil Te<Tr Te>=Tr again ;
: consider dup -1 xor if r ! sort then ;
: scan     articleIds dup /afields + begin 2dup < while
           over f@ consider swap cell+ swap repeat 2drop ;

