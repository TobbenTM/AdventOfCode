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

func main() {
  dat, err := ioutil.ReadFile("../src/github.com/tobbentm/AdventOfCode/2017/day1/input.txt")
  check(err)
  numss := strings.Split(string(dat), "")
  nums := Map(numss, func(num string) int {
    i, _ := strconv.Atoi(num);
    return i
  })
  
  sum := 0

  for index, num := range nums {
    if index < len(nums) - 1 {
      if num == nums[index + 1] {
        sum += num
      }
    } else {
      if num == nums[0] {
        sum += num
      }
    }
  }

  fmt.Printf("Solution 1: %d\n", sum)

  sum = 0
  step := len(nums) / 2

  for index, num := range nums {
    nextIndex := (index + step) % len(nums)
    if num == nums[nextIndex] {
      sum += num
    }
  }

  fmt.Printf("Solution 2: %d\n", sum)
}
