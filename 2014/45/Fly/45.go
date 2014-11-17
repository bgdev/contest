package main

import (
	"bufio"
	"fmt"
	"io"
	"os"
	"strings"
)

func convert_number(line string) string {
	parsed_line := strings.Split(line, " ")
	source := "0"
	target := "0"
	number := parsed_line[0]

	if len(parsed_line) == 3 {
		source = parsed_line[1]
		target = parsed_line[2]
	}

	to_decimal := 0
	var result []string

	for i := 0; i < len(number); i++ {
		to_decimal = to_decimal*len(source) + strings.Index(source, string(number[i]))
	}

	for to_decimal > 0 {
		result = append(result, string(target[to_decimal%len(target)]))
		to_decimal = to_decimal / len(target)
	}
	return reverse_string(strings.Join(result, ""))

}

func reverse_string(s string) string {
	n := len(s)
	runes := make([]rune, n)
	for _, rune := range s {
		n--
		runes[n] = rune
	}
	return string(runes[n:])
}

func main() {
	if len(os.Args) > 1 {
		in, _ := os.Open(os.Args[1])
		out, _ := os.OpenFile("results.out", os.O_WRONLY|os.O_APPEND|os.O_CREATE, 0666)
		count := 0

		scanner := bufio.NewScanner(in)
		for scanner.Scan() {
			text := fmt.Sprintf("Case #%d: %s\n", count, convert_number(scanner.Text()))
			io.WriteString(out, text)
			count += 1
		}

		fmt.Println("Output written in: results.out")

		defer in.Close()
		defer out.Close()
	} else {
		fmt.Println("USAGE: 45 filename.in")
	}
}
