: mo          4 lshift or ;
: dy          5 lshift or ;
: hr          5 lshift or ;
: mn          6 lshift or ;
: now         time&date ( yr ) mo dy hr mn nip ;

: months      S"    JanFebMarAprMayJunJulAugSepOctNovDec" drop ;
: .y          20 rshift . ;
: .m          16 rshift $F and 3 * months + 3 type space ;
: .d          11 rshift $1F and s>d <# # # #> type space ;
: .ymd        dup .y dup .m .d ;
: .h          6 rshift $1F and s>d <# # # #> type ;
: .m          $3F and s>d <# # # #> type ;
: .hm         dup .h [char] : emit .m ;
: .time       dup .ymd .hm ;

