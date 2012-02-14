warnings off
marker done

: string        S" Hello world!" ;
: open-file     2drop drop 1 0 ;
: close-file    drop 0 ;
defer read-file
: read-file1    2drop drop 0 0 ;
: read-file0    2drop string >r swap r> move  string nip 0  ['] read-file1 is read-file ;
include ../lib/contents.fs

variable h0
: s             ['] read-file0 is read-file  here h0 !  s" unused-filename" contents ;
: t60.0         s  here h0 @ - 12 xor abort" t60.0" ;
: t60.1         s  h0 @ 12 string compare abort" t60.1" ;
: t60           t60.0 t60.1 ;
t60

done

