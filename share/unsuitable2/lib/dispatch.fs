variable mname
variable mlen

: /=0           dup if exit then  2drop s" index" ;
: eat           1 piPtr +!  -1 piLen +! ;
: pl            dup >r here swap move r> allot ;
: mname,        mname @ mlen @ /=0 pl ;
: .fs,          s" .fs" pl ;
: view/,        s" view/" pl ;
: filename      view/, mname, .fs, ;
: inc           here filename here over - included ;
: +exception    ['] inc catch 0= if r> drop then ;
: run           +exception 404Page ;
: -/            piPtr @ c@ [char] / = if r> drop then ;
: -end          piLen @ 0= if r> drop then ;
: skipTo/       begin -end -/ eat again ;
: module        piPtr @ mname ! skipTo/ piPtr @ mname @ - mlen ! ;
: +/            piPtr @ c@ [char] / xor if r> drop then ;
: skip/         -end +/ eat ;
: blog          getPathInfo skip/ module run ;

