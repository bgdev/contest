#!/usr/bin/env python3.3
import unittest

from alien_numbers import *


class InputParsing(unittest.TestCase):
  """
  Tests for the parsing of the input text into objects.
  """

  def test_input_parsing(self):
    translations = parse_input(["2",
                                "a ab cd",
                                "w wx yz"])
    self.assertEqual(2, len(translations))
    t0 = translations[0]
    self.assertEqual("a", t0.source_number.value)
    self.assertEqual("ab", t0.source_number.language.alphabet)
    self.assertEqual("cd", t0.target_language.alphabet)
    t1 = translations[1]
    self.assertEqual("w", t1.source_number.value)
    self.assertEqual("wx", t1.source_number.language.alphabet)
    self.assertEqual("yz", t1.target_language.alphabet)


class ObjectEquality(unittest.TestCase):
  def test_alien_language_equality(self):
    self.assertEqual(AlienLanguage("a"), AlienLanguage("a"))
    self.assertEqual(AlienLanguage("ab"), AlienLanguage("ab"))
    self.assertNotEqual(AlienLanguage("X"), AlienLanguage("x"))

  def test_alien_number_equality(self):
    self.assertEqual(AlienNumber(AlienLanguage("ab"), "a"),
                     AlienNumber(AlienLanguage("ab"), "a"))
    self.assertNotEqual(AlienNumber(AlienLanguage("ab"), "a"),
                        AlienNumber(AlienLanguage("ab"), "b"))
    self.assertNotEqual(AlienNumber(AlienLanguage("ab"), "a"),
                        AlienNumber(AlienLanguage("ax"), "a"))


class TranslationAlgorithm(unittest.TestCase):
  """
  Tests for the translation algorithm, which maps a number
  from one language in another number in another language.
  """

  def test_identity_for_same_languages(self):
    def translate(value:str):
      return Translation(AlienLanguage("ab").create_number(value),
                         AlienLanguage("ab")).translate()

    self.assertEqual("a", translate("a").value)
    self.assertEqual("b", translate("b").value)
    self.assertEqual("ab", translate("ab").value)

  def test_mapping_for_equivalent_languages(self):
    def translate(value:str):
      return Translation(AlienLanguage("ab").create_number(value),
                         AlienLanguage("AB")).translate()

    self.assertEqual("A", translate("a").value)
    self.assertEqual("B", translate("b").value)
    self.assertEqual("AB", translate("ab").value)


if __name__ == '__main__':
  unittest.main()
