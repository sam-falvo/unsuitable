require mappings.fs
require general.fs
require articles.fs
require slurp.fs
require time.fs
require respond.fs
require standard-macros.fs

.( Content-type: application/rss+xml) cr cr

create e0   16 cells allot
e0 16 cells -1 fill
e0 15 cells + constant en-1
en-1 cell+ constant en
variable ep
include latest.fs
scan


create p0   17 cells allot
variable pp
: exists  ep @ @ article! lead gob! get, ;
: c       ep @ @ -1 xor if exists then [ 1 cells ] literal dup pp +! ep +! here pp @ ! ;
: 16c     c c c c  c c c c  c c c c  c c c c ;
: cache   e0 ep ! p0 pp ! here p0 ! 16c ;
cache


: -"          dup [char] " = if drop ." &quot;" r> drop then ;
: -&          dup [char] & = if drop ." &amp;" r> drop then ;
: -<          dup [char] < = if drop ." &lt;" r> drop then ;
: ->          dup [char] > = if drop ." &gt;" r> drop then ;
: convert     -" -& -< -> emit ;
: translate   begin 2dup < while over c@ convert swap char+ swap repeat 2drop ;
: encode      pp @ dup @ swap cell+ @ translate [ 1 cells ] literal pp +! ;

: title         ." <title>" title gob! get, ." </title>" ;
: (link)        ." http://" *domain* type ." /" *path* type ." /blog.fs/articles/" articleId . ;
: link          ." <link>" (link) ." </link>" ;
: ?more         body -1 xor if ." &lt;p&gt;&lt;i&gt;(continued . . .)&lt;/i&gt;&lt;/p&gt;" then ;
: description   ." <description>" encode ?more ." </description>" ;
: author        ." <author>kc5tja@arrl.net (Samuel A. Falvo II)</author>" ;
: guid          ." <guid>" (link) ." </guid>" ;
: pubDate       ." <pubDate>" timestamp .time822 ." </pubDate>" ;
: item          ." <item>" title link description author guid pubDate ." </item>" ;
: i             ep @ @ -1 xor if ep @ @ article! item then [ 1 cells ] literal ep +! ;
: 16items       i i i i  i i i i  i i i i  i i i i ;

: 16items       >web e0 ep ! p0 pp ! 16items >con ;
: pubDate       >web now .time822 >con ;

variable s
variable end
here s !  s" theme/rss.xml" slurp  here end !
include response.fs
bye

