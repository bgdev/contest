#!/usr/bin/env python3.3
import fileinput


class AlienLanguage(object):
  def __init__(self, alphabet):
    super().__init__()
    self.alphabet = alphabet

  def create_number(self, value):
    return AlienNumber(self, value)

  def index_of(self, digit):
    return self.alphabet.index(digit)

  def digit_at(self, index):
    return self.alphabet[index]

  def __eq__(self, other):
    return self.alphabet == other.alphabet


class AlienNumber(object):
  def __init__(self, language:AlienLanguage, value:str):
    self.language = language
    self.value = value

  def map_to(self, target_language):
    def map_digit(digit):
      index = self.language.index_of(digit)
      return target_language.digit_at(index)

    target_value = "".join([map_digit(digit) for digit in self.value])
    return AlienNumber(target_language, target_value)

  def __eq__(self, other):
    if self.language == other.language:
      if self.value == other.value:
        return True
    return False


class Translation(object):
  def __init__(self, source_number:AlienNumber, target_language:AlienLanguage):
    super().__init__()
    self.source_number = source_number
    self.target_language = target_language

  def translate(self):
    return self.source_number.map_to(self.target_language)


def parse_input(lines):
  # skip the first line
  lines = iter(lines)
  next(lines)

  def parse_line(line:str):
    tokens = line.split()
    target = AlienLanguage(tokens[2])
    source = AlienLanguage(tokens[1])
    number = source.create_number(tokens[0])
    return Translation(number, target)

  return [parse_line(line) for line in lines]


def solve_problem():
  # FIXME: complete implementation
  translations = parse_input(fileinput.input())
  for translation in translations:
    target_number = translation.translate()
    print(target_number.value)


if __name__ == "__main__":
  solve_problem()
