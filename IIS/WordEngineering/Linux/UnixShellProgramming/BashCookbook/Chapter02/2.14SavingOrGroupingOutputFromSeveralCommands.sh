#!/bin/bash
{ pwd; ls; } > outfile #2021-07-09 Saving or Grouping Output from Several Commands
( pwd; ls ) > outfile #2021-07-09 Saving or Grouping Output from Several Commands, run the commands in a sub-shell
