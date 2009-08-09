- Purpose:
  - Provide a means of encoding and decoding timestamps.
- Comments
  - Timestamps are ordinals, and may be compared with Forth's built-in relational operators.
  - Bit-packed structure
    - Year: 12 bits
    - Month: 4 bits (1..12)
    - Day: 5 bits (1..31)
    - Hour: 5 bits (0..23)
    - Minute: 6 bits (0..59)

    3            2    1     1
    2            0    6     1     6      0
    +------------+----+-----+-----+------+
    |    Yr      | Mo | Dy  |  Hr |  Mn  |
    +------------+----+-----+-----+------+

