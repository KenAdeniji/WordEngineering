package main //2022-02-11T06:30:00 https://gobyexample.com/for
import "fmt"
import "os"
import "text/tabwriter"
func main() {
	w := tabwriter.NewWriter(os.Stdout, 1, 1, 1, ' ', 0)
	fmt.Fprintln(w, "Celsuis\tFahrenheit")
	fahrenheit := 0.0
	for celsuis := 0.0; celsuis <= 100; celsuis += 5 { //May contain the break and continue keywords
        fahrenheit = celsuis * 1.8 + 32
		//fmt.Fprintln(w, celsuis, fahrenheit)
		fmt.Printf("%f %f\n", celsuis, fahrenheit);
    }
}
