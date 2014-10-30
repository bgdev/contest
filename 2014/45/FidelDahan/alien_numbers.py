#!/usr/bin/env python3.3
import fileinput


class AlienLanguage(object):
  def __init__(self, alphabet):
    super().__init__()
    self.alphabet = alphabet


class AlienNumber(object):
  def __init__(self, value:str, language:AlienLanguage):
    self.value = value
    self.language = language


class Conversion(object):
  def __init__(self,
               number:AlienNumber,
               source:AlienLanguage,
               target:AlienLanguage):
    super().__init__()
    self.number = number
    self.source = source
    self.target = target


class InputParser(object):
  def __init__(self, lines):
    super().__init__()
    lines = iter(lines)
    next(lines)
    self.conversions = [self.parse(line) for line in lines]

  @staticmethod
  def parse(line):
    tokens = line.split()
    target = AlienLanguage(tokens[2])
    source = AlienLanguage(tokens[1])
    number = AlienNumber(tokens[0], source)
    return Conversion(number, source, target)


if __name__ == "__main__":
  reader = InputParser(fileinput.input())
