#!/usr/bin/env python3.3
import unittest

from alien_numbers import *


class InputParsing(unittest.TestCase):
  def test_input_parsing(self):
    translations = parse_input(["2",
                                "a ab cd",
                                "w wx yz"])
    self.assertEqual(2, len(translations))
    t0 = translations[0]
    self.assertEqual("a", t0.number.value)
    self.assertEqual("ab", t0.source.alphabet)
    self.assertEqual("cd", t0.target.alphabet)
    t1 = translations[1]
    self.assertEqual("w", t1.number.value)
    self.assertEqual("wx", t1.source.alphabet)
    self.assertEqual("yz", t1.target.alphabet)


if __name__ == '__main__':
  unittest.main()
