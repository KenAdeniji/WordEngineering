/*
	2026-06-29T16:46:00	Created. http://go.dev/doc/tutorial/create-module
	go mod init go.dev_-_greetings
	go mod tidy
*/	
package greetings

import "fmt"

// Hello returns a greeting for the named person.
func Hello(name string) string {
    // Return a greeting that embeds the name in a message.
    message := fmt.Sprintf("Hi, %v. Welcome!", name)
    return message
}