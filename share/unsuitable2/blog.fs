\ use /home/lighttpd/WWW/falvotech.com/htdocs/blog3/blocks.fb
use ./blocks.fb

variable len
variable src
variable dst
variable ptr

require lib/config.fs
require lib/xspace.fs
require lib/metadata.fs
require lib/articles-db.fs
require lib/gos-space.fs
require lib/gos-handles.fs
require lib/article.fs
  require lib/views.fs
require lib/contents.fs

variable src
variable len

require lib/template.fs
require lib/status-pages.fs
require lib/pathinfo.fs
require lib/dispatch.fs

blog bye

