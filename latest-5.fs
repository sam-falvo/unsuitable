create e0  5 cells allot
e0 5 cells -1 fill
e0 4 cells + constant e4
e4 cell+ constant e5
variable ep

: insert   ep @ dup cell+ over e4 swap - move ;
: nil      ep @ @ -1 = if article ep @ ! r> drop then ;
: eol      ep @ e5 >= if r> drop then ;
: Te<Tr    article ep @ @ article! timestamp swap article! timestamp <
           if insert article ep @ ! r> drop then ;
: Te>=Tr   [ 1 cells ] literal ep +! ;
: sort     e0 ep ! begin eol nil Te<Tr Te>=Tr again ;
: consider articleId -1 xor if sort then ;
: scan     articleIds dup /afields + begin 2dup < while
           over articleIds - article! consider swap cell+ swap repeat 2drop ;


: .gob     gob! here get, here over - respond ;
: div      respond execute s" </div>" respond ;
: t        title .gob ;
: .title   ['] t S\" <div id=\"blog-article-index-title\">" div ;
: >resp    ['] respond is type ['] c, is emit ;
: >con     ['] (type) is type  ['] (emit) is emit ;
: t        >resp timestamp .time >con ;
: .timestamp ['] t S\" <div id=\"blog-article-index-ts\">" div ;
: l        lead .gob ;
: .lead    ['] l S\" <div id=\"blog-article-index-lead\">" div ;
: entry    .title .timestamp .lead ;
: e        dup @ -1 xor if dup @ article! entry then cell+ ;
: l5       e0 e e e e e drop ;
: latest   ['] l5 S\" <div id=\"blog-article-index\">" div ;

