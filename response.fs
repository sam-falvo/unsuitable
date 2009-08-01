\ PRECONDITIONS:
\   VARIABLE s -- points to beginning of source string buffer
\   VARIABLE end -- points just past last character of source buffer
\   Any template handlers must be defined prior to including this
\   code.
\
\ Builds a template expanded version of the contents of the source
\ buffer at HERE.  Template expansions start with the tilde character.
\ Template expansion names map directly to Forth word names.
\
\ POSTCONDITIONS:
\   VARIABLE response -- pointer to first character of response buffer
\   HERE -- points just past last character of response buffer
\   Contents of response buffer dumped to stdout for the web server.

: >string     over + end ! s ! ;
: c           s @ c@ ;
: -eos        s @ end @ < ;
: -eon        c 32 > -eos and ;
: name        s @ begin -eon while 1 s +! repeat s @ over - ;
: macro       1 s +! name sfind if execute then ;
: ch          c [char] ~ over xor if c, else drop macro then 1 s +! ;
: expand      begin -eos while ch repeat ;

variable response
here response !  expand  response @ here over - type

