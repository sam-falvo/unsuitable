variable titlePtr
variable titleLen
variable absPtr
variable absLen
variable bodyPtr
variable bodyLen

variable outp
variable ptr
variable len
variable src
variable endsrc

: .status		." 200" ;
: .blog-title           ." Sam's All New, New and Improved, New News News" ;
: .article-error        ;
: .article-title        titlePtr @ titleLen @ type ;
: .article-abstract     absPtr @ absLen @ type ;
: .article-body         bodyPtr @ bodyLen @ type ;

: -abody        2dup s" article-body" compare if exit then
                2drop bodyLen ! bodyPtr ! r> drop ;
: -aabs         2dup s" article-abstract" compare if exit then
                2drop absLen ! absPtr ! r> drop ;
: -atitle       2dup s" article-title" compare if exit then
                2drop titleLen ! titlePtr ! r> drop ;
: k=v           -atitle -aabs -abody 2drop 2drop ;

include ../lib/contents.fs
include ../lib/template.fs
include ../lib/status-pages.fs
include ../lib/urldecode.fs
include ../lib/kvparse-substr.fs
include ../lib/kvparse.fs

create buf      4096 allot
: pl            dup if dup >r here swap move r> allot then ;
: stream        buf 4096 stdin read-file throw buf over pl ;
: fileIn        begin stream 0= until ;
: paramString   here ptr ! fileIn here ptr @ - len ! ;
: form          here src !  S" theme/PreviewPage" contents  src @ here over - len !
                here outp !  expand  here outp @ - type ;
: POST          paramString kvparse form ;
: GET           0 titleLen !  0 absLen !  0 bodyLen !  form ;
: requestMethod s" REQUEST_METHOD" getenv ;
: -POST         requestMethod s" POST" compare if exit then  POST r> drop ;
: -GET          requestMethod s" GET" compare if exit then  GET r> drop ;
: preview       -GET -POST 404Page ;
preview

