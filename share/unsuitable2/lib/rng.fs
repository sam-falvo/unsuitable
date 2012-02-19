\ Implementation of Mersenne Twister as taken from
\ http://en.wikipedia.org/wiki/Mersenne_twister
\
\ I am aware of Wil Baden's sources, but I had difficulty
\ getting it to compile under SwiftForth out of the box.
\
\ This module exposes the following API:
\
\ seeded ( uSeed -- )
\   Seeds the random number generator with the provided 32-bit,
\   unsigned value.
\
\ probability ( -- u )
\   Returns a random value that falls in the range [0,
\   $FFFFFFFF].
\
\ All other definitions are safe to shadow/redefine elsewhere.
\
\ Copyright (c) 2010, Samuel A. Falvo II
\ All rights reserved.
\ 
\ Redistribution and use in source and binary forms, with or
\ without modification, are permitted provided that the following
\ conditions are met:
\ 
\ * Redistributions of source code must retain the above copyright
\   notice, this list of conditions and the following disclaimer.
\ 
\ * Redistributions in binary form must reproduce the above
\   copyright notice, this list of conditions and the following
\   disclaimer in the documentation and/or other materials
\   provided with the distribution.
\ 
\ * Neither the name of Samuel A. Falvo II, Falvo Technical
\   Solutions, nor the names of its contributors may be used to
\   endorse or promote products derived from this software
\   without specific prior written permission.
\ 
\ THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND
\ CONTRIBUTORS "AS IS" AND ANY EXPRESS OR IMPLIED WARRANTIES,
\ INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES OF
\ MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE
\ DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT HOLDER OR
\ CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL,
\ SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT
\ LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF
\ USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED
\ AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT
\ LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING
\ IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF
\ THE POSSIBILITY OF SUCH DAMAGE.

CREATE states
    624 CELLS ALLOT

VARIABLE index

: reset ( nIndex -- )
  states OVER 1- CELLS + DUP @ 30 RSHIFT SWAP @ XOR 1812433253 *
  OVER + $FFFFFFFF AND SWAP states SWAP CELLS + ! ;

: randomized ( -- )
  1 BEGIN DUP 624 < WHILE DUP reset 1+ REPEAT DROP ;

: seeded ( uSeed -- )
  states !  0 index !  randomized ;


: y ( nIndex -- y )
   DUP 1+ 624 MOD CELLS states + @ $7FFFFFFF AND
   SWAP CELLS states + @ 31 LSHIFT + ;

: altered ( nIndex -- )
  DUP y DUP 1 AND 2567483615 * >r 2/ OVER 397 + 624 MOD CELLS
  states + @ XOR r> XOR SWAP CELLS states + ! ;

: scrambled ( -- )
  0 BEGIN DUP 624 < WHILE DUP altered 1+ REPEAT DROP ;

: probability ( -- u )
  index @ 0= IF scrambled THEN index @ CELLS states + @
  DUP 11 RSHIFT XOR DUP 7 LSHIFT 2636928640 AND XOR DUP 15 LSHIFT
  4022730752 AND XOR DUP 18 RSHIFT XOR index @ 1+ 624 MOD index ! ;

