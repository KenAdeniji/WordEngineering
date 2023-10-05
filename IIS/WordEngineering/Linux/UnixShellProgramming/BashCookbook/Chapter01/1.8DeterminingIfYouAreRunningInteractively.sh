#!/usr/bin/env bash
#2021-07-08 Interactive shell?
case "$-" in
*i*)  # Code for interactive shell here
	echo 'interactive shell'
*)    # Code for non-interactive shell here
	echo 'non-interactive shell'
esac
