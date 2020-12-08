/*
	2019-04-17	Created.	https://www.openmymind.net/assets/go/go.pdf
	2019-04-17	https://stackoverflow.com/questions/26159416/init-array-of-structs-in-go
*/	
package main

import (
    "fmt"
//	"strings"
)

func main() {
	var bibleBooks = []bibleBook { 
		bibleBook {
			ID: 1, 
			Title: "Genesis",
		},
		bibleBook {
			ID: 2, 
			Title: "Exodus",
		},
	}
	length := len(bibleBooks)
	for index := 0; index < length; index++ {
		fmt.Println(bibleBooks[index].ID, bibleBooks[index].Title)
	}
}

type bibleBook struct {
	ID int
	Title string
}
