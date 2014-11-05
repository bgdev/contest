#!/usr/bin/env ruby


# Reads number X written in alien language described by LANG and returns
# its value
def alien_from(x, lang)
  digits = x.chars.map { |c| lang.index c }
  return digits.reverse.each_with_index.reduce(0) do |memo, (digit, i)|
    power = lang.length ** i
    value = digit * power
    memo + value
  end
end


def highest_power(x, b)
  return x >= b ? 1 + highest_power(x/b, b) : 0
end


# Converts value X to base BASE and returns a list of digit values
def to(x, base)
  highest = highest_power(x, base)
  powers = (0..highest).reverse_each.map { |p| base ** p }
  ans = []
  powers.reduce(x) do |remainder, power|
    digit = remainder / power
    ans << digit
    remainder % power
  end
  return ans
end


def alien_to(x, lang)
  conv = to(x, lang.length)
  return conv.map { |i| lang[i] }.join
end


def main
  STDIN.readline                # Skip number of test cases
  STDIN.each.with_index(1) do |line, lineno|
    num, source, dest = line.split
    value = alien_from(num, source)
    res = alien_to(value, dest)
    puts "Case ##{lineno}: #{res}"
  end
end


__FILE__ == $0 and main
