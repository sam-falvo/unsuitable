: >core      dup 10 rshift block swap 1023 and + ;
: blocks     1024 * ;


2 blocks constant org
org 3 blocks + constant end
: fencepost  1 block ;
: fence      fencepost @ org + ;
: reserve    dup fence + end > abort" Out of general storage space" fencepost +! update ;
: place      >r fence >core r@ move update r> reserve ;
: partial    1024 fence 1023 and - min ;
: part       2dup partial dup >r place r> /string ;
: archive    begin dup while part repeat 2drop ;


1 blocks constant /hfields
end constant addrs
addrs /hfields + constant lens
: @f         >core @ ;
: !f         >core ! update ;
variable lrn
: addr       addrs lrn @ + @f ;
: length     lens lrn @ + @f ;
: addr!      addrs lrn @ + !f ;
: length!    lens lrn @ + !f ;
: gob        lrn @ ;
: gob!       lrn ! ;
: available  addrs lens begin 2dup < while over @f -1 = if
             drop addrs - exit then swap cell+ swap repeat
             0= abort" Out of GOB handles." ;
: put        available gob! fence -rot dup length! archive addr! ;

