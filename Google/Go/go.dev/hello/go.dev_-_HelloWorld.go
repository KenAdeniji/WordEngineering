/*
	2026-06-29T14:50:00	Created. http://go.dev/doc/tutorial/getting-started
*/	
package main

import (
    "fmt"
    "os"
)

func main() {
	length := len(os.Args)
	if length <= 1 {
		fmt.Println("Hello, World!")
		os.Exit(1)
	}	
	for i := 1; i < length; i++ {
		fmt.Println(i, os.Args[i])
	}
}
