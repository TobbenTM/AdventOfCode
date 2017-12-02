package main

import (
  "fmt"
  "strings"
  "strconv"
  "io/ioutil"
)

func check(e error) {
  if e != nil {
    panic(e)
  }
}

func Map(vs []string, f func(string) int) []int {
  vsm := make([]int, len(vs))
  for i, v := range vs {
    vsm[i] = f(v)
  }
  return vsm
}

func SArrayToInt(vs []string) []int {
  return Map(vs, func(num string) int {
    i, err := strconv.Atoi(strings.Replace(num, "\r", "", -1))
    check(err)
    return i
  })
}

func main() {
  dat, err := ioutil.ReadFile("../src/github.com/tobbentm/AdventOfCode/2017/day2/input.txt")
  check(err)
  rows := strings.Split(string(dat), "\n")

  checksum := 0

  for _, row := range rows {
    min := 0
    max := 0
    parsedRow := SArrayToInt(strings.Split(string(row), "\t"))
    for _, num := range parsedRow {
      if num < min || min == 0 {
        min = num
      }
      if num > max {
        max = num
      }
    }
    checksum += max - min
  }

  fmt.Printf("\nChecksum 1: %d", checksum)
  
  checksum = 0

  for _, row := range rows {
    parsedRow := SArrayToInt(strings.Split(string(row), "\t"))
    for index, num := range parsedRow {
      done := false
      for _, inum := range parsedRow[(index + 1):] {
        var divident int
        var divisor int
        if num > inum {
          divident = num
          divisor = inum
        } else {
          divident = inum
          divisor = num
        }
        if divident % divisor == 0 {
          checksum += divident / divisor
          done = true
          break;
        }
      }
      if done {
        break;
      }
    }
  }

  fmt.Printf("\nChecksum 2: %d", checksum)
}
