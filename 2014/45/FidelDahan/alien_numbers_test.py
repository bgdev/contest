#!/usr/bin/env python3.3
import unittest

from alien_numbers import *


class InputParserTest(unittest.TestCase):
  def test_input_parsing(self):
    conversions = parse_input(["2",
                               "a ab cd",
                               "w wx yz"])
    self.assertEqual(2, len(conversions))
    c0 = conversions[0]
    self.assertEqual("a", c0.number.value)
    self.assertEqual("ab", c0.source.alphabet)
    self.assertEqual("cd", c0.target.alphabet)
    c1 = conversions[1]
    self.assertEqual("w", c1.number.value)
    self.assertEqual("wx", c1.source.alphabet)
    self.assertEqual("yz", c1.target.alphabet)


if __name__ == '__main__':
  unittest.main()
