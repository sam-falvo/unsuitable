create e0  5 cells allot
e0 5 cells -1 fill
e0 4 cells + constant en-1
en-1 cell+ constant en
variable ep
include latest.fs
include standard-macros.fs

: .gob     gob! get, ;
: .goblink S\" <a href=\"" respond path:code~ S\" /blog.fs/articles/" respond articleId s>d <# #s #> respond S\" \">" respond .gob S" </a>" respond ;
: div      respond execute s" </div>" respond ;
: t        title .goblink ;
: .title   ['] t S\" <div class=\"blogArticleIndexTitle\">" div ;
: >web     ['] respond is type ['] c, is emit ;
: >con     ['] (type) is type  ['] (emit) is emit ;
: t        >web timestamp .time ."  &mdash; Samuel A. Falvo II" >con ;
: .timestamp ['] t S\" <div class=\"blogArticleIndexTimestamp\">" div ;
: c        >web ." (continued...)" >con ;
: l        lead .gob  body 1+ if ['] c S\" <div class=\"blogArticleIndexContinued\">" div then ;
: .lead    ['] l S\" <div class=\"blogArticleIndexLead\">" div ;
: entry    .title .timestamp .lead ;
: e        dup @ -1 xor if dup @ article! entry then cell+ ;
: l5       e0 e e e e e drop ;
: latest   ['] l5 S\" <div class=\"blogArticleIndex\">" div ;

