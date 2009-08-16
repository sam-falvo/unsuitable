require mappings.fs
require general.fs
require articles.fs
require slurp.fs
require time.fs
require respond.fs

.( Content-type: application/rss+xml) cr cr

: pubDate    >web now .time822 >con ;

create e0   16 cells allot
e0 16 cells -1 fill
e0 15 cells + constant en-1
en-1 cell+ constant en
variable ep
include latest.fs
scan

: title         ." <title>" title gob! get, ." </title>" ;
: (link)        ." http://www.falvotech.com/blog2/blog.fs/articles/" articleId . ;
: link          ." <link>" (link) ." </link>" ;
: description   ." <description>Bogus content here.</description>" ;
: author        ." <author>kc5tja@arrl.net (Samuel A. Falvo II)</author>" ;
: guid          ." <guid>" (link) ." </guid>" ;
: timestamp     ." <pubDate>" timestamp .time822 ." </pubDate>" ;
: item          ." <item>" title link description author guid timestamp ." </item>" ;
: i             ep @ @ -1 xor if ep @ @ article! item then [ 1 cells ] literal ep +! ;
: 4items        i i i i ;
: 16items       >web e0 ep ! 4items 4items 4items 4items >con ;

variable s
variable end
here s !  s" theme/rss.xml" slurp  here end !
include response.fs
bye

