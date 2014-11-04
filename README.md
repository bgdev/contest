# contest #

Because we all have a lot of free time ;)

## Guidelines ##

Each solution should provide a Makefile with three targets:
* build (that should be the default target): prepares your solution to be run
* run: runs your solution
* clean: cleans up your directory

Example
```makefile
compile:
        gcc -o solution solution.c

run:
        ./solution
        
clean:
        -rm solution

.PHONY: run
.PHONY: clean
```

## check_output.coffee ##

Checks to see if a solution output file is correct or not.  Requires
installed phantomjs.

Example
```shell
$ (cd 2014/45/abozhilov && make)
$ ./2014/45/abozhilov/alien_numbers < ./2014/45/A-small-practice.in > /tmp/output
$ ./check_output.coffee https://code.google.com/codejam/contest/32003/dashboard /tmp/output
Judged response for input A-small: Correct!
```

## Recent ##

w45: 3~9 November 2014: https://code.google.com/codejam/contest/32003/dashboard [A]
w46: 10~16 November 2014: https://code.google.com/codejam/contest/32003/dashboard#s=p1 [B]
