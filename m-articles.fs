require mappings.fs
require general.fs
require articles.fs
require slurp.fs
require time.fs
require respond.fs

end-of-url &parameters - constant /parameters
: oops              s" m-index.fs" included bye ;
: |parameters|>=2   /parameters 2 u< if oops then ;
|parameters|>=2

variable s
variable end
: mime   ." Content-type: text/html" cr cr ;
: valid   mime  here s ! s" theme/article.html" slurp here end ! s" response.fs" included bye ;


variable id   0 id !
: exists:     dup -1 = if r> 2drop then ;
: .f          id @ articleWithId! execute exists: gob! get, ;
: title       ['] title .f ;
: lead        ['] lead .f ;
: body        ['] body .f ;
: timestamp   >web id @ articleWithId! timestamp .time >con ;


&parameters 1+ constant &id
: -eon     dup end-of-url u>= if drop valid then ;
: -0-9     dup [char] 0 < swap [char] 9 > or ;
: *10+     dup c@ [char] 0 - id @ 10 * + dup . id ! ;
: digit    dup c@ -0-9 if drop oops then *10+ ;
: numeric  &id begin -eon digit char+ again ;
numeric

