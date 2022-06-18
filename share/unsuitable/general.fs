: fence      g-fencepost @ gorg + ;
: reserve    dup fence + gend > abort" Out of general storage space" g-fencepost +! update ;
: place      >r fence >core r@ move update r> reserve ;
: partial    1024 fence 1023 and - min ;
: part       2dup partial dup >r place r> /string ;
: archive    begin dup while part repeat 2drop ;

: remaining  over 1023 and 1024 swap - min ;
: obtain     swap >core swap here swap dup >r move r> allot ;
: part       2dup remaining dup >r obtain r> /string ;
: retrieve,  begin dup while part repeat 2drop ;


variable lrn
: addr       addrs lrn @ + @f32 ;
: length     lens lrn @ + @f32 ;
: addr!      addrs lrn @ + !f32 ;
: length!    lens lrn @ + !f32 ;
: gob        lrn @ ;
: gob!       lrn ! ;
: available  addrs lens begin 2dup < while over @f32 -1 = if
             drop addrs - exit then swap word+ swap repeat
             abort" Out of GOB handles." ;
: put        available gob! fence -rot dup length! archive addr! ;
: get,       addr length retrieve, ;

