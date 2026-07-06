/*
	2026-06-29T14:50:00	Created. http://go.dev/doc/tutorial/getting-started
	go mod init go.dev_-_rsc.io_-_quote
	go mod tidy
*/	
package main

import "fmt"

import "rsc.io/quote"

func main() {
	fmt.Println(quote.Go())
}
