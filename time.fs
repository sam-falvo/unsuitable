: mo          4 lshift or ;
: dy          5 lshift or ;
: hr          5 lshift or ;
: mn          6 lshift or ;
: pack        mo dy hr mn nip ;
: now         time&date pack ;

: yr          20 rshift ;
: mo          16 rshift 15 and ;
: dy          11 rshift 31 and ;
: hr          6 rshift 31 and ;
: mn          63 and ;

: months      S"    JanFebMarAprMayJunJulAugSepOctNovDec" drop ;
: .y          yr . ;
: .m          mo 3 * months + 3 type space ;
: .d          dy s>d <# # # #> type space ;
: .ymd        dup .y dup .m .d ;
: .dmy        dup .d dup .m .y ;
: .h          hr s>d <# # # #> type ;
: .m          mn s>d <# # # #> type ;
: .hm         dup .h [char] : emit .m ;
: .time       dup .ymd .hm ."  PDT" ;
: .time822    dup .dmy .hm ."  PDT" ;
