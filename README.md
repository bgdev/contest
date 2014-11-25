# Толкова ли е трудно писането на български ?

# Задачки #

Всяка седмица пускаме нова задача, желаещите (и можещите) я решават.
Виж по-долу списъка. ;)

## Насоки ##

Всяко решение трябва да предоставя и Мейкфайл със следните три цели:
* build (да е първа цел и съответно по подразбиране): подготвя/построява решението
* run: пуска решението
* clean: трие всички генерирани от решението файлове

Example
```makefile
compile:
        gcc -o solution solution.c

run:
        @./solution
        
clean:
        -rm solution

.PHONY: run
.PHONY: clean
```

## check_output.coffee ##

Проверява чрез сайта на Гугъл Код Джам дали изхода от дадено
решение е коректно или не. В момента работи само за първа задача (А).
Необходим е инсталиран phantomjs, за да работи.

Пример
```shell
$ (cd 2014/45/abozhilov && make)
$ ./2014/45/abozhilov/alien_numbers < ./2014/45/A-small-practice.in > /tmp/output
$ ./check_output.coffee https://code.google.com/codejam/contest/32003/dashboard /tmp/output
Judged response for input A-small: Correct!
```

## Задачки ##

w45: 3~9 November 2014: https://code.google.com/codejam/contest/32003/dashboard [A]  
w46: 10~16 November 2014: https://code.google.com/codejam/contest/32003/dashboard#s=p1 [B]
w47: 17~23 November 2014: https://code.google.com/codejam/contest/32003/dashboard#s=p2 [C]
w48: 24~30 November 2014: https://code.google.com/codejam/contest/32003/dashboard#s=p3 [D]
