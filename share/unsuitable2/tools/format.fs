variable src
variable dst
variable len

include ../lib/config.fs
include ../lib/xspace.fs
include ../lib/metadata.fs
include ../lib/gos-space.fs
include ../lib/gos-handles.fs

: space 	gosBlobBlock blocks gosWofs! ;
: handles 	gosAddrsBlock blocks /column blocks $FF xfill ;
: gos0	 	handles space ;
: format 	gos0 ;

format
