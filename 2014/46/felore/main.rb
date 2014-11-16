#!/usr/bin/env ruby

class Block

  def initialize
    # ? :)
    # @sides = [:north, :south, :west, :east].map { |s| [s, false] }.to_h
    # @sides[:north] = @sides[:south] = @sides[:west] = @sides[:east] = false
    @sides = {
      north: false,
      south: false,
      west: false,
      east: false
    }
  end

  def pprint
    n = @sides[:north] ? ' ' : '-'
    s = @sides[:south] ? ' ' : '-'
    w = @sides[:west] ? ' ' : '|'
    e = @sides[:east] ? ' ' : '|'
    puts(".#{n}.\n#{w} #{e}\n.#{s}.")
  end

  def set_side(side, open)
    @sides[side] = open
  end

end


class Maze

  def initialize(rows, cols)
    @m = Array.new(rows) { Array.new(cols, Block.new) }
  end

end


def main
  b = Block.new
  m = Maze.new(10, 10)
  m.pprint
end


if __FILE__ == $0
  main
end
