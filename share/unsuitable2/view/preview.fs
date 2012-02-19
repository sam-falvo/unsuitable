variable titlePtr
variable titleLen
variable absPtr
variable absLen
variable bodyPtr
variable bodyLen
variable chlPtr
variable chlLen
variable rspPtr
variable rspLen

variable outp
variable ptr
variable len
variable src
variable endsrc
variable dst

create challengeBuf	16 allot

: .status		." 200" ;
: .blog-title           ." Sam's All New, New and Improved, New News News" ;
defer .article-error
: .article-title        titlePtr @ titleLen @ type ;
: .article-abstract     absPtr @ absLen @ type ;
: .article-body         bodyPtr @ bodyLen @ type ;
: .challenge		challengeBuf 16 type ;

: -abody        2dup s" article-body" compare if exit then
                2drop bodyLen ! bodyPtr ! r> drop ;
: -aabs         2dup s" article-abstract" compare if exit then
                2drop absLen ! absPtr ! r> drop ;
: -atitle       2dup s" article-title" compare if exit then
                2drop titleLen ! titlePtr ! r> drop ;
: -chl		2dup s" chl" compare if exit then
		2drop chlLen ! chlPtr ! r> drop ;
: -rsp		2dup s" rsp" compare if exit then
		2drop rspLen ! rspPtr ! r> drop ;
: k=v           -atitle -aabs -abody -chl -rsp 2drop 2drop ;

include ../lib/config.fs
include ../lib/rng.fs
include ../lib/permuter.fs
include ../lib/contents.fs
include ../lib/template.fs
include ../lib/status-pages.fs
include ../lib/urldecode.fs
include ../lib/kvparse-substr.fs
include ../lib/kvparse.fs
include ../lib/articles-db.fs
include ../lib/xspace.fs
include ../lib/metadata.fs
include ../lib/gos-space.fs
include ../lib/gos-handles.fs

: chrs 			s" 0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ~!" drop ;
: rndchr		probability 63 and chrs + c@ ;
: rc			rndchr over c! 1+ ;
: 16rc			rc rc rc rc  rc rc rc rc  rc rc rc rc  rc rc rc rc ;
: newChallenge		challengeBuf 16rc drop ;

: (titleMissing) 	." You need to provide a title." ;
: (absMissing) 		." You need to provide an abstract." ;
: (noMoreArticles)	." Article database too small to fit article." ;
: (noMoreRoom)		." Out of GOS space; cannot record article." ;
: (noMoreHandles) 	." Out of GOS handles; cannot record article." ;
: (noAccess)		." Post rejected; incorrect response to challenge." ;
: (no-error)		;
: msg 			create , does> @ is .article-error ;
' (titleMissing) 	msg titleMissing
' (absMissing) 		msg absMissing
' (noMoreArticles) 	msg noMoreArticles
' (noMoreRoom) 		msg noMoreRoom
' (noMoreHandles) 	msg noMoreHandles
' (noAccess)		msg noAccess
' (no-error)		msg ok

create buf      4096 allot
: pl            dup if dup >r here swap move r> allot then ;
: stream        buf 4096 stdin read-file throw buf over pl ;
: fileIn        begin stream 0= until ;
: paramString   here ptr ! fileIn here ptr @ - len ! ;
: form          here src !  S" theme/PreviewPage" contents  src @ here over - len !
                here outp !  expand  here outp @ - type ;
: +title 	titleLen @ if exit then  titleMissing form  r> r> 2drop ;
: +abs          absLen @ if exit then  absMissing form  r> r> 2drop ;
: +artDb	articlesFree if exit then  noMoreArticles form r> r> 2drop ;
: +gosSpace	titleLen @ absLen @ + bodyLen @ +  gosSpaceAvailable?
		if exit then  noMoreRoom form  r> r> 2drop ;
: +gosHandles	3 bodyLen @ 0= + gosHandlesAvailable?
		if exit then  noMoreHandles form  r> r> 2drop ;
: +|chl|=16	chlLen @ 16 = if exit then noAccess form r> r> r> 2drop drop ;
: +|rsp|=8  	rspLen @ 8 = if exit then noAccess form r> r> r> 2drop drop ;
: +auth		+|chl|=16 +|rsp|=8 chlPtr @ src ! authKey permute
		here 8 - 8 rspPtr @ rspLen @ compare if
		noAccess form r> r> 2drop then ;
: +valid 	+auth +title +abs +artDb +gosSpace +gosHandles ;
: POST          paramString kvparse +valid ok form ;
: GET           0 titleLen !  0 absLen !  0 bodyLen !  form ;
: requestMethod s" REQUEST_METHOD" getenv ;
: -POST         requestMethod s" POST" compare if exit then  POST r> drop ;
: -GET          requestMethod s" GET" compare if exit then  GET r> drop ;
: preview       -GET -POST 404Page ;

time&date * * * * * seeded
newChallenge preview

