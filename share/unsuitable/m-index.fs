#! /usr/bin/env gforth

." Content-type: text/html" cr cr

require mappings.fs
require general.fs
require articles.fs
require slurp.fs
require time.fs
require respond.fs

require latest-5.fs
: last-five-posts   scan latest ;

variable s
variable end
here s ! S" ../theme/index.html" slurp here end !
include response.fs
bye

