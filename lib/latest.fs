: insert   ep @ dup cell+ over en-1 swap - move ;
: nil      ep @ @ -1 = if article ep @ ! r> drop then ;
: eol      ep @ en >= if r> drop then ;
: Te<Tr    article ep @ @ article! timestamp swap article! timestamp <
           if insert article ep @ ! r> drop then ;
: Te>=Tr   [ 1 cells ] literal ep +! ;
: sort     e0 ep ! begin eol nil Te<Tr Te>=Tr again ;
: consider articleId -1 xor if sort then ;
: scan     articleIds dup /afields + begin 2dup < while
           over articleIds - article! consider swap cell+ swap repeat 2drop ;

