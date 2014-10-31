# contest #

Because we all have a lot of free time ;)

## Guidelines ##

Each solution should provide a Makefile with two targets:
* compile (that should be the default target): prepares your solution to be run
* clean: cleans up your directory
* run: runs your solution against the *LARGE* input file

Example
```makefile
compile:
        gcc -o solution solution.c

clean:
        -rm solution

run:
        ./solution < ../A-large-practice.in

.PHONY: clean
.PHONY: run
```

## check_output.coffee ##

Checks to see if a solution output file is correct or not.  Requires
installed phantomjs.

Example
```shell
$ (cd 2014/45/abozhilov && make)
$ ./2014/45/abozhilov/alien_numbers < ./2014/45/A-small-practice.in > output
$ ./check_output.coffee https://code.google.com/codejam/contest/32003/dashboard output
Judged response for input A-small: Correct!
```

## Recent ##

w45: 2~8 November 2014: https://code.google.com/codejam/contest/32003/dashboard [A]
