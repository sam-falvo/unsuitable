1 constant meta ( block for the blog state)

: blocks     1024 * ;
: gosWofs@   meta blocks x@32 ;
: gosWofs!   meta blocks x!32 ;

: artDbId@   meta blocks 4 + x@32 ;
: artDbId!   meta blocks 4 + x!32 ;

