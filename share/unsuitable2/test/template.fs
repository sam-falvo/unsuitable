marker done

variable src
variable len

include ../lib/template.fs

variable dst
variable dlen

: srcText   S" A sample text without any macro expansions." ;
: s         srcText len ! src !  here dst !  >buf expand >con here dst @ - dlen ! ;
: t50.0     s dlen @ srcText nip xor abort" t50.0" ;
: t50.1     s srcText dst @ dlen @ compare abort" t50.1" ;
: t50       t50.0 t50.1 ;
t50

variable macros-called
: mymacro   1 macros-called +!  ." YAY!" >con cr cr .s cr cr >buf ;

: srcText   S" A sample text with ~mymacro , a macro expansion!" ;
: expText   S" A sample text with YAY!, a macro expansion!" ;
: init      0 macros-called !  srcText len ! src ! here dst ! ;
: s         init >buf expand >con here dst @ - dlen ! ;
: t51.0     s macros-called @ 0= abort" t51.0" ;
: t51       t51.0 ;
t51

done

